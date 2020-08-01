using System;
using System.Collections.Generic;
using XRL.World.AI.GoalHandlers;
using XRL.World.Effects;

namespace XRL.World.Parts.Mutation
{
    [Serializable]
    public class Unphasing : BaseMutation
    {
        public Guid UnphaseActivatedAbilityID = Guid.Empty;
        public ActivatedAbilityEntry UnphaseActivatedAbility;

        public Unphasing()
        {
            this.DisplayName = "Astral Walker";
        }

        public override void Register(GameObject Object)
        {
            Object.RegisterPartEvent((IPart)this, "BeginTakeAction");
            Object.RegisterPartEvent((IPart)this, "EnteredCespinll");
            Object.RegisterPartEvent((IPart)this, "CommandUnphase");
            Object.RegisterPartEvent((IPart)this, "AIGetOffensiveMutationList");
            base.Register(Object);
        }

        public override string GetDescription()
        {
            return "You live in an alternate reality, but may phase into reality for brief periods of time.";
        }

        public override string GetLevelText(int Level)
        {
            return "Cooldown: " + (object)(103 - 3 * Level) + " rounds\n" + "Duration: " + (object)(6 + Level) + " rounds";
        }

        public override bool FireEvent(Event E)
        {
            if ((E.ID == "BeginTakeAction" || E.ID == "EnteredCespinll") && (!this.ParentObject.HasEffect("Phased") && !this.ParentObject.HasEffect("RealityStabilized") && !this.ParentObject.HasEffect("Unphased")))
            {
                this.ParentObject.ApplyEffect((Effect)new Phased(9999));
                return true;
            }
            if (E.ID == "CommandUnphase")
            {
                if (!this.ParentObject.FireEvent(Event.New("InitiateRealityDistortionLocal", "Object", (object)this.ParentObject, "Mutation", (object)this), E))
                    return true;
                this.ParentObject.ApplyEffect((Effect)new Unphased(6 + this.Level + 1));
                this.UnphaseActivatedAbility.Cooldown = 1040 - 30 * this.Level;
            }
            if (!(E.ID == "AIGetOffensiveMutationList"))
                return base.FireEvent(E);
            int parameter1 = (int)E.GetParameter("Distance");
            List<AICommandList> parameter2 = (List<AICommandList>)E.GetParameter("List");
            if (this.UnphaseActivatedAbility != null && this.UnphaseActivatedAbility.Cooldown <= 0 && (parameter1 > 1 && parameter1 < 6 + this.Level - 1) && this.ParentObject.FireEvent(Event.New("CheckRealityDistortionAdvisability", "Mutation", (object)this)))
                parameter2.Add(new AICommandList("CommandPhase", 1));
            return true;
        }

        public override bool ChangeLevel(int NewLevel)
        {
            return base.ChangeLevel(NewLevel);
        }

        public override bool Mutate(GameObject GO, int Level)
        {
            this.ParentObject.ApplyEffect((Effect)new Phased(9999));
            ActivatedAbilities part = GO.GetPart("ActivatedAbilities") as ActivatedAbilities;
            if (part != null)
            {
                this.UnphaseActivatedAbilityID = part.AddAbility(
                    Name: "Unphase", 
                    Command: "CommandUnphase", 
                    Class: "Physical Mutation", 
                    Description: "Peer behind the curtain from the other side.",
                    IsRealityDistortionBased: true
                );
                this.UnphaseActivatedAbility = part.AbilityByGuid[this.UnphaseActivatedAbilityID];
            }
            this.ChangeLevel(Level);
            return base.Mutate(GO, Level);
        }

        public override bool Unmutate(GameObject GO)
        {
            if (this.UnphaseActivatedAbilityID != Guid.Empty)
            {
                (GO.GetPart("ActivatedAbilities") as ActivatedAbilities).RemoveAbility(this.UnphaseActivatedAbilityID);
                this.UnphaseActivatedAbilityID = Guid.Empty;
            }
            return base.Unmutate(GO);
        }
    }
}

using System;
using System.Collections.Generic;
using XRL.Core;
using XRL.Language;
using XRL.Rules;
using XRL.World.Capabilities;

namespace XRL.World.Effects
{
    [Serializable]
    public class Unphased : Effect
    {
        public string RenderString = "a";
        public string Tile;

        public Unphased()
        {
        }

        public Unphased(int _Duration)
          : this()
        {
            this.Duration = _Duration;
        }

        public override bool SameAs(Effect e)
        {
            Unphased unphased = e as Unphased;
            if (unphased.Tile != this.Tile || unphased.RenderString != this.RenderString)
                return false;
            return base.SameAs(e);
        }

        public override string GetDetails()
        {
            return "Temporarily able to interact with creatures and objects unless they're phased.\nCan no longer pass through solids.";
        }

        public override bool Apply(GameObject Object)
        {
            Object.RemoveEffect("Phased", false);
            return true;
        }

        public override void Remove(GameObject Object)
        {
            Object.ApplyEffect((Effect)new Phased(9999));
            base.Remove(Object);
        }

        public override void Register(GameObject Object)
        {
            this.Tile = Object.pRender.Tile;
            this.RenderString = Object.pRender.RenderString;
            Object.RegisterEffectEvent((Effect)this, "EndTurn");
            base.Register(Object);
        }

        public override void Unregister(GameObject Object)
        {
            Object.UnregisterEffectEvent((Effect)this, "EndTurn");
            base.Unregister(Object);
        }

        public override bool Render(RenderEvent E)
        {
            return true;
        }

        public override bool FireEvent(Event E)
        {
            if (E.ID == "EndTurn" && this.Duration > 0)
            {
                if (this.Duration > 1 && this.Object.IsPlayer() && this.Duration != 9999)
                    Effect.AddPlayerMessage("You will phase back out in " + Grammar.Cardinal(this.Duration - 1) + " " + (this.Duration - 1 != 1 ? "turns" : "turn") + ".");
                if (this.Duration != 9999)
                    --this.Duration;
            }
            return base.FireEvent(E);
        }
    }
}

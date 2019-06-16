using XRL.World.Parts;
using UnityEngine;

namespace XRL.World.PartBuilders
{
  public class BodyKittyAstral : IPartBuilder
  {
    public void BuildPart(IPart iPart, string Context = null)
    {
      Body body1 = iPart as Body;
      if (body1 == null)
        return;
      BodyPart body2 = body1.GetBody();
      body2.AddPart("Head", 0, "Kitty_Astral_Bite", (string) null, (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?()).AddPart("Face", 0, (string) null, (string) null, (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Back", 0, (string) null, (string) null, (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Foot", 18, "Kitty_Astral_Claw", "Forefeet", (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Foot", 17, "Kitty_Astral_Claw", "Forefeet", (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Foot", 66, (string) null, "Hindfeet", (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Foot", 65, (string) null, "Hindfeet", (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Missile Weapon", 2, (string) null, (string) null, (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Missile Weapon", 1, (string) null, (string) null, (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Feet", 16, (string) null, (string) null, "Forefeet", (string) null, new int?(), new int?(), new int?(0), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Feet", 64, (string) null, (string) null, "Hindfeet", (string) null, new int?(), new int?(), new int?(0), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Tail", 0, (string) null, (string) null, (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Thrown Weapon", 0, (string) null, (string) null, (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body2.AddPart("Floating Nearby", 0, (string) null, (string) null, (string) null, (string) null, new int?(), new int?(), new int?(), new bool?(), new bool?(), new bool?(), new bool?(), new bool?());
      body1.FinishBuild();
    }
  }
}

using UnityEngine;
using System.Collections.Generic;
using System;
using RoR2;
using BepInEx.Logging;

namespace ExampleNameSpace.ExampleExtension
{
  public class ExampleManager
  {
    public ManualLogSource InstanceLogger;

    public void PrintNumber(int i)
    {
      Debug.Log("Number: " + i);
    }

    internal void SkinDefApply(Action<SkinDef, GameObject> orig, SkinDef self, GameObject modelObject)
    {
      orig(self, modelObject);

      Debug.Log("Example Extension: Skin Def Apply");
    }
  }
}
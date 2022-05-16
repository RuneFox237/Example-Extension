using UnityEngine;
using RoRSkinBuilder.Data;
using System.Collections.Generic;

namespace ExampleNameSpace.ExampleExtension
{

  [AddComponentMenu("RoR Skins/Example Extension")]
  public class ExampleExtensionInfo : MonoBehaviour
  {
    public SkinModInfo modInfo;
    public AssetsInfo assetInfo;

    //Put Extension Info here
    public int ExampleNumber = 1;

    public ExampleExtensionInfo(ExampleExtensionInfo info)
    {
      modInfo = info.modInfo;
      InitializeAssetInfo();
    }
    public void InitializeAssetInfo()
    {
      assetInfo = new AssetsInfo(modInfo);
    }

  }

}
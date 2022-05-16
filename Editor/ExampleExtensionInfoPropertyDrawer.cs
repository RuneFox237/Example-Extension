using UnityEngine;
using UnityEditor;
using System.IO;


namespace ExampleNameSpace.ExampleExtension
{
  [CustomEditor(typeof(ExampleExtensionInfo))]
  public class ExampleExtensionInfoPropertyDrawer : Editor
  {

    public override void OnInspectorGUI()
    {
      base.OnInspectorGUI();

      if (GUILayout.Button("Build"))
      {
        Build(serializedObject.targetObject as ExampleExtensionInfo);  
      }
    }


    //TODO: DaisyChain the DynamicSkins and CustomItemDisplay stuff on build
    private void Build(ExampleExtensionInfo info)
    {
      if (info.assetInfo == null) info.InitializeAssetInfo();

      //Generate file from template
      var path = Path.Combine(info.assetInfo.modFolder, info.modInfo.name + "ExampleExtension.cs");
      var ExtensionCode = new ExampleExtensionTemplate(info);
      File.WriteAllText(path, ExtensionCode.TransformText());

      //copy files from Copy Path
      //com.exampleauthor.examplename is the package name in package.json
      string filename = "ExampleExtension.cs";
      File.Copy("Packages/com.exampleauthor.examplename/Editor/CopyPath/" + filename, info.assetInfo.modFolder + "/" + filename, true);

      //Add Assets to Unity's asset database so that they appear in the project window
      AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);
      AssetDatabase.ImportAsset(info.assetInfo.modFolder + "/" + filename, ImportAssetOptions.ForceUpdate);

      Debug.Log("Example Extension Finished");
    }
  }
}

#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class CustomBuildProcessor  : IPreprocessBuildWithReport
{
    public int callbackOrder { get { return 0; } }


    public void OnPreprocessBuild(BuildReport report)
    {
        if(report.summary.platform == BuildTarget.WebGL)
        {
            string buildPath = report.summary.outputPath;
            //find and open index.html
            string indexFilePath = buildPath + "\\index.html";
            //open file
            if (File.Exists(indexFilePath))
            {
                string content = File.ReadAllText(indexFilePath);
                //content = content.Replace("var buildUrl = \"Build\";", "var buildUrl = \"UnityBuild/Build\";");
                File.WriteAllText(indexFilePath, content);
            }


        }
        
    }
}

#endif

using UnityEditor;
using System;

class Builder {
    static void iOSProductionBuild() {
        // ... your code here, validations, flag changes, etc.

        // Build the player.\
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/summon.unity" };
        buildPlayerOptions.locationPathName = "C:\\Users\\Justin\\Documents\\UnityBuilds\\Summon\\summoning.app";
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    static void AndroidProductionBuild() {
        // ... your code here, validations, flag changes, etc.

        // Build the player.\
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/summon.unity" };
        buildPlayerOptions.locationPathName = "C:\\Users\\Justin\\Documents\\UnityBuilds\\Summon\\summoning.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }

    static void AndroidTestBuild() {
        // ... your code here, validations, flag changes, etc.

        // Build the player.\
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/summon.unity" };
        buildPlayerOptions.locationPathName = "C:\\Users\\Justin\\Documents\\UnityBuilds\\Summon\\summoning-test.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }


    static void Build() {
        string[] arguments = Environment.GetCommandLineArgs();
        switch (arguments[1]) {
            case "Android":
                AndroidProductionBuild();
                break;
            case "AndroidTest":
                AndroidTestBuild();
                break;
            case "iOS":
                iOSProductionBuild();
                break;
            default:
                AndroidProductionBuild();
                break;
        }
    }
}
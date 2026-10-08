using BepInEx;
using BepInEx.Logging;
using ExampleModSliderUI.Patches;
using HarmonyLib;
using UnityEngine;

namespace ExampleModMinitrainSpeedUnlimit;

[BepInPlugin(LCMPluginInfo.PLUGIN_GUID, LCMPluginInfo.PLUGIN_NAME, LCMPluginInfo.PLUGIN_VERSION)]
public class ExampleModMinitrainSpeedUnlimit : BaseUnityPlugin
{
    internal static ManualLogSource Log = null!;
    public static float minitrainSpeedLimit = 3.3f;

    private bool showPanel = false;

    private void Awake()
    {
        Log = Logger;
        Log.LogInfo($"Plugin {LCMPluginInfo.PLUGIN_NAME} version {LCMPluginInfo.PLUGIN_VERSION} is loaded!");

        Harmony myHarmony = new(LCMPluginInfo.PLUGIN_GUID);
        myHarmony.PatchAll(typeof(TrackTrainSpeedRelayPatches));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            showPanel = !showPanel;
        }
    }

    private void OnGUI()
    {
        if (!showPanel)
        {
            return;
        }

        GUI.Box(new Rect(250, 250, 400, 75), "Minitrain Speed Unlimiter.");
        minitrainSpeedLimit = GUI.HorizontalSlider(new Rect(275, 275, 250, 25), minitrainSpeedLimit, 0.0f, 10.0f);
        GUI.Label(new Rect(525, 275, 75, 25), $"{(minitrainSpeedLimit * 3.6f).ToString("N1")} km/h");
    }
}

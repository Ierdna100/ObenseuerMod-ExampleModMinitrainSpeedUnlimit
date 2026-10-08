using HarmonyLib;
using Outputs;
using UnityEngine;

namespace ExampleModSliderUI.Patches;

public class TrackTrainSpeedRelayPatches
{
    [HarmonyPatch(typeof(TrackTrainSpeedRelay), nameof(TrackTrainSpeedRelay.OnTrainPassed))]
    [HarmonyPrefix]
    public static bool TrackTrainSpeedRelayPrefix(TrackTrainSpeedRelay __instance)
    {
        if (!__instance.active || __instance.segment == null)
        {
            return false;
        }
        Debug.Log("TrackTrainSpeedRelay: ON TRAIN PASSED");
        TrackTrain trackTrain = null;
        if (__instance.segment.occupiedBy)
        {
            trackTrain = __instance.segment.occupiedBy;
        }
        else if (__instance.segment.previousSegment.occupiedBy)
        {
            trackTrain = __instance.segment.previousSegment.occupiedBy;
        }
        if (trackTrain == null)
        {
            return false;
        }
        float absoluteTrainSpeed = Mathf.Abs(trackTrain.currentSpeed);

        // Modified code
        if (absoluteTrainSpeed > ExampleModMinitrainSpeedUnlimit.ExampleModMinitrainSpeedUnlimit.minitrainSpeedLimit)
        // End of modified code
        {
            if (__instance.requirePlayer)
            {
                Minitrain componentInChildren = trackTrain.GetComponentInChildren<Minitrain>();
                if (componentInChildren == null || !componentInChildren.isOn)
                {
                    return false;
                }
            }
            foreach (output output in __instance.outputs)
            {
                if (!__instance.ignoreArgument)
                {
                    output?.Fire(absoluteTrainSpeed);
                }
                else
                {
                    output?.Fire();
                }
            }
        }

        // Do not run the original method.
        return false;
    }
}

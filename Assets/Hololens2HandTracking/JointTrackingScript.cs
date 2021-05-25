using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JointTrackingScript : MonoBehaviour, IMixedRealityHandJointHandler
{
    // Start is called before the first frame update
    GameObject jointsText;
    void Start()
    {
        jointsText = GameObject.Find("jointsText");
        jointsText.GetComponent<TextMeshPro>().text = "start";
    }
    private void OnEnable()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealityHandJointHandler>(this);
    }

    private void OnDisable()
    {
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealityHandJointHandler>(this);
    }

    // Update is called once per frame
    void Update()
    {
        //if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose pose))
        //{
        //    text.GetComponent<TextMeshPro>().text = pose.Position.ToString();
        //}
    }
    public void OnHandJointsUpdated(InputEventData<IDictionary<TrackedHandJoint, MixedRealityPose>> eventData)
    {
        jointsText.GetComponent<TextMeshPro>().text = "Hand: " + eventData.Handedness + "\n";
        int i = 0;
        foreach (TrackedHandJoint joint in eventData.InputData.Keys)
        {
            MixedRealityPose pose;
            eventData.InputData.TryGetValue(joint, out pose);
            jointsText.GetComponent<TextMeshPro>().text += "joint " + (i++).ToString() + "  " + joint.ToString().Trim().PadRight(25) + "  Position: " + pose.Position.ToString() + "  Rotation: " + pose.Rotation.ToString() + "\n";
        }

    }
}

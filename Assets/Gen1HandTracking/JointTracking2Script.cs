using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JointTracking2Script : MonoBehaviour, IMixedRealityHandJointHandler
{
    // Start is called before the first frame update
    GameObject jointsText;
    GameObject handsText;
    void Start()
    {
        jointsText = GameObject.Find("jointsText");
        jointsText.GetComponent<TextMeshPro>().text = "start";
        handsText = GameObject.Find("handsText");
        handsText .GetComponent<TextMeshPro>().text = "start";

        //CoreServices.InputSystem.RegisterHandler<IMixedRealityHandJointHandler>(this);
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

    public void OnSourceDetected(SourceStateEventData eventData)
    {
        var hand = eventData.Controller as IMixedRealityHand;
        if (hand != null)
        {
            if (hand.TryGetJoint(TrackedHandJoint.IndexTip, out MixedRealityPose jointPose))
            {
                handsText.GetComponent<TextMeshPro>().text = "got joint " + jointPose.ToString(); 
            }
        }
        else
        {
                handsText.GetComponent<TextMeshPro>().text = "hand null"; 
        }
    }

    public void OnHandJointsUpdated(InputEventData<IDictionary<TrackedHandJoint, MixedRealityPose>> eventData)
    {
        jointsText.GetComponent<TextMeshPro>().text = "";
        int i = 0;
        foreach(TrackedHandJoint joint in eventData.InputData.Keys)
        {
            MixedRealityPose pose;
            eventData.InputData.TryGetValue(joint,out pose);
            jointsText.GetComponent<TextMeshPro>().text += "joint " + (i++).ToString()  + "  "+ joint.ToString().Trim().PadRight(25) + "  Position: " + pose.Position.ToString() + "  Rotation: " +  pose.Rotation.ToString() + "\n";
        }

    }
}

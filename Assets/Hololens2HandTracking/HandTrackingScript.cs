using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandTrackingScript : MonoBehaviour, IMixedRealitySourceStateHandler
{

    GameObject handsText;
    IMixedRealityHand hand;
    // Start is called before the first frame update
    void Start()
    {
        handsText = GameObject.Find("handsText");
        handsText.GetComponent<TextMeshPro>().text = "start";

    }
    void Update()
    {
        if (hand != null)
        {
            handsText.GetComponent<TextMeshPro>().text = "Source detected: " + hand.ControllerHandedness + "\n";
            handsText.GetComponent<TextMeshPro>().text += "Velocity " + hand.Velocity + "\n";
            handsText.GetComponent<TextMeshPro>().text += "is pointing? " + hand.IsInPointingPose + "\n";

            if (hand.TryGetJoint(TrackedHandJoint.IndexTip, out MixedRealityPose jointPose))
            {
                handsText.GetComponent<TextMeshPro>().text += "Got joint " + jointPose.ToString(); 
            }
        }
    }
    private void OnEnable()
    {
        CoreServices.InputSystem?.RegisterHandler<IMixedRealitySourceStateHandler>(this);
    }

    private void OnDisable()
    {
        CoreServices.InputSystem?.UnregisterHandler<IMixedRealitySourceStateHandler>(this);
    }


    public void OnSourceDetected(SourceStateEventData eventData)
    {
        hand = eventData.Controller as IMixedRealityHand;
    }

    public void OnSourceLost(SourceStateEventData eventData)
    {
        // Only react to articulated hand input sources
        if (hand != null)
        {
            handsText.GetComponent<TextMeshPro>().text = "Source lost: " + hand.ControllerHandedness;
        }
        hand = null;
    }



}

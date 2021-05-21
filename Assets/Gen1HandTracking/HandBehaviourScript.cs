using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandBehaviourScript : MonoBehaviour, IMixedRealityHandJointHandler
{

    GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("handText");

        text.GetComponent<TextMeshPro>().text = "start" ;
    }


    public void OnSourceDetected(SourceStateEventData eventData)
    {
        var hand = eventData.Controller as IMixedRealityHand;
        if (hand != null)
        {
            if (hand.TryGetJoint(TrackedHandJoint.IndexTip, out MixedRealityPose jointPose))
            {
                print("got joint " + jointPose.ToString());
                text.GetComponent<TextMeshPro>().text = "got joint " + jointPose.ToString(); 
            }

                text.GetComponent<TextMeshPro>().text = "cannot get joint. The hand velocity: " + hand.Velocity.ToString(); 
        }

                text.GetComponent<TextMeshPro>().text = "hand = null!"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHandJointsUpdated(InputEventData<IDictionary<TrackedHandJoint, MixedRealityPose>> eventData)
    {
        print(eventData.ToString());
        //text.GetComponent<TextMeshPro>().text = eventData.ToString();
        //if(eventData.Handedness != 0)
        //{
        //    text.GetComponent<TextMeshPro>().text = eventData.ToString();
        //}
        MixedRealityPose pose;
        eventData.InputData.TryGetValue(TrackedHandJoint.Palm, out pose);
        text.GetComponent<TextMeshPro>().text = eventData.Handedness + pose.Position.ToString() ;
    }
}

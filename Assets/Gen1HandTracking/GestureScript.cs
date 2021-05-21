using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestureScript : MonoBehaviour,IMixedRealityGestureHandler
{
    public void OnGestureCanceled(InputEventData eventData)
    {
        text.GetComponent<TextMeshPro>().text = "OnGestureCanceled" ;
    }

    public void OnGestureCompleted(InputEventData eventData)
    {
        text.GetComponent<TextMeshPro>().text = "OnGestureCompleted" ;
    }

    public void OnGestureStarted(InputEventData eventData)
    {
        text.GetComponent<TextMeshPro>().text = "OnGestureStarted" ;
    }

    public void OnGestureUpdated(InputEventData eventData)
    {
        text.GetComponent<TextMeshPro>().text = "OnGestureUpdated" ;
    }

    GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("handText");
        text.GetComponent<TextMeshPro>().text = "start" ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

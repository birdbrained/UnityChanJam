using UnityEngine;
using System.Collections;

public class AttachToObj : MonoBehaviour 
{
    private GameObject attachToMe;

    // Use this for initialization
    void Start () 
    {
        attachToMe = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate () 
    {
        transform.localPosition = attachToMe.transform.localPosition;
    }
}

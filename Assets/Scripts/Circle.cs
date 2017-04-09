using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour 
{
    [SerializeField]
    private float speed;

    // Use this for initialization
    void Start () 
    {
        if (speed == 0f)
            speed = 1f;
    }

    // Update is called once per frame
    void FixedUpdate () 
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * Time.deltaTime * speed * 3f, Space.World);
    }
}

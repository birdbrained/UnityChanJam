using UnityEngine;
using System.Collections;

public class NitroAtom : MonoBehaviour 
{

    // Use this for initialization
    void Start () 
    {
        
    }

    // Update is called once per frame
    void Update () 
    {
        
    }

    void GiveNitro()
    {
        GameManager.Instance.NitroNum++;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider, tag: " + other.gameObject.tag + ", name: " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            GiveNitro();
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class NitroAtom : MonoBehaviour 
{
    [SerializeField]
    private GameObject sound;

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
            if (sound != null)
                Instantiate(sound, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }
}

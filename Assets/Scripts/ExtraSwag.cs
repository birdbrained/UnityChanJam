using UnityEngine;
using System.Collections;

public class ExtraSwag : MonoBehaviour 
{
    public static bool hasSwag;
    private GameObject swag;

    // Use this for initialization
    void Start () 
    {
        swag = GameObject.Find("glasses");
    }

    // Update is called once per frame
    void Update () 
    {
        if (swag != null)
        {
            if (hasSwag)
                swag.SetActive(true);
            else
                swag.SetActive(false);
        }
    }

    public void ChangeSwag()
    {
        hasSwag = !hasSwag;
    }
}

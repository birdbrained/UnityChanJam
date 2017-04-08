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
        if (swag != null)
        {
            if (hasSwag)
                swag.SetActive(true);
            else
                swag.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () 
    {

    }

    public void ChangeSwag()
    {
        hasSwag = !hasSwag;
        if (swag != null)
        {
            if (hasSwag)
                swag.SetActive(true);
            else
                swag.SetActive(false);
        }
    }
}

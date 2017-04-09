using UnityEngine;
using System.Collections;

public class ExtraSwag : MonoBehaviour 
{
    public static bool hasSwag;
    private GameObject swag;

    [SerializeField]
    private GameObject[] swagList;
    public static int swagIndex = 0;


    // Use this for initialization
    void Start () 
    {
        /*swag = GameObject.Find("glasses");
        if (swag != null)
        {
            if (hasSwag)
                swag.SetActive(true);
            else
                swag.SetActive(false);
        }*/

        foreach (GameObject sweg in swagList)
            if (sweg != null)
                sweg.SetActive(false);
        ChangeSwag();
    }

    // Update is called once per frame
    void Update () 
    {

    }

    public void ChangeSwag()
    {
        /*hasSwag = !hasSwag;
        if (swag != null)
        {
            if (hasSwag)
                swag.SetActive(true);
            else
                swag.SetActive(false);
        }*/

        foreach (GameObject sweg in swagList)
            if (sweg != null)
                sweg.SetActive(false);

        if (swagIndex < swagList.Length)
        {
            if (swagList[swagIndex] != null)
                swagList[swagIndex].SetActive(true);
        }
    }

    public void IncrementSwag()
    {
        swagIndex++;
        if (swagIndex > swagList.Length - 1)
            swagIndex = 0;
        ChangeSwag();
    }
}

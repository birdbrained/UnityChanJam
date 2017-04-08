using UnityEngine;
using System.Collections;

public class GameOverCar : MonoBehaviour 
{
    private Material blownupMaterial;

    // Use this for initialization
    void Start () 
    {
        SwapCar sc = GameManager.Instance.gameObject.GetComponent<SwapCar>();
        blownupMaterial = sc.carBlownupMaterials[SwapCar.index];
    }

    // Update is called once per frame
    void Update () 
    {
        if (blownupMaterial != null)
            GetComponentInChildren<Renderer>().material = blownupMaterial;
    }
}

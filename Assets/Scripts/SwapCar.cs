using UnityEngine;
using System.Collections;

public class SwapCar : MonoBehaviour 
{
    private GameObject car;
    //private Mesh carMesh;
    //private Material carMaterial;
    [SerializeField]
    private Mesh[] carMeshes;
    [SerializeField]
    private Material[] carMaterials;
    public Material[] carBlownupMaterials;
    [SerializeField]
    private Vector3[] carScales;

    private GameObject unitychan;
    [SerializeField]
    private Vector3[] driverSeats;

    public static int index;

    // Use this for initialization
    void Start () 
    {
        car = GameObject.Find("Player");
        unitychan = GameObject.Find("unitychan");
        //carMesh = car.GetComponentInChildren<Mesh>();
        //carMaterial = car.GetComponentInChildren<Material>();
        ChangeCar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ChangeCar()
    {
        //carMesh = carMeshes[index];
        //carMaterial = carMaterials[index];
        if (car != null)
        {
            car.GetComponentInChildren<MeshFilter>().mesh = carMeshes[index];
            car.GetComponentInChildren<Renderer>().material = carMaterials[index];
            car.transform.localScale = carScales[index];
            if (unitychan != null)
                unitychan.gameObject.transform.localPosition = driverSeats[index];
        }
    }

    public void ChangeIndex()
    {
        index++;
        if (index > carMeshes.Length - 1)
            index = 0;
        ChangeCar();
    }
}

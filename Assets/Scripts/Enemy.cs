using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    [SerializeField]
    private float health;

    [SerializeField]
    private GameObject explosionObj;
    private bool canExplode = true;
    [SerializeField]
    private Material blownupMaterial;

    public float getHealth()
    {
        return health;
    }

    public void setHealth(float f)
    {
        health = f;
    }

    // Use this for initialization
    void Start () 
    {

    }

    // Update is called once per frame
    void Update () 
    {
        if (health <= 0f && canExplode)
            Explode();
    }

    void Explode()
    {
        if (explosionObj != null)
            Instantiate(explosionObj, gameObject.transform.position, gameObject.transform.rotation);
        if (blownupMaterial != null)
            GetComponentInChildren<Renderer>().material = blownupMaterial;
        canExplode = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Object" || other.gameObject.tag == "Front")
        {
            health = 0f;
            GameManager.Instance.Score += 2500;
            GameManager.Instance.ThisLevelScore += 2500;
        }
    }

}

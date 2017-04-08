using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

public class PlayerController : MonoBehaviour 
{
    public float health;
    [SerializeField]
    private Text healthText;
    private Rigidbody rb;

    // Use this for initialization
	void Start () 
    {
        //GameManager.Instance.Health = health;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
	void Update () 
    {
        healthText.text = health.ToString("F2");
        //Debug.Log("Player velocity: " + rb.velocity.magnitude.ToString());
        if (health <= 0f)
        {
            Explode();
        }
	}

    public void Explode()
    {
        //CarUserControl.Instance.CanMove = false;
        CarUserControl car = GetComponent<CarUserControl>();
        car.CanMove = false;
        rb.velocity *= 0.9f;
    }

    void OnCollisionEnter(Collision c)
    {
        GameObject other = c.collider.gameObject;
        Debug.Log("HIT: " + other.gameObject.name + ", tag: " + other.gameObject.tag);
        float damage = 0;
        if (other.gameObject.tag == "Object")
        {
            damage = other.gameObject.GetComponent<Rigidbody>().mass * rb.velocity.magnitude;
        }
        else if (other.gameObject.tag == "Front")
        {
            if (rb.velocity.magnitude >= 20f)
                damage = health;
            else
                damage = other.gameObject.GetComponentInParent<Rigidbody>().mass * rb.velocity.magnitude;
        }
        Debug.Log("Damage: " + damage.ToString("F2"));
        health -= damage;
    }
}

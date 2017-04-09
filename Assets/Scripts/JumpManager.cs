using UnityEngine;
using System.Collections;

public class JumpManager : MonoBehaviour 
{
    private Rigidbody rb;
    private bool jumping = true;
    private AudioSource jumpSound;

    // Use this for initialization
    void Start () 
    {
        rb = GetComponentInParent<Rigidbody>();
        jumpSound = GetComponent<AudioSource>();
    }
	
    // Update is called once per frame
    void FixedUpdate () 
    {
        if (Input.GetAxisRaw("Jump1") != 0)
        {
            if (!jumping)
            {
                Jump();
                jumping = true;
            }
        }
    }

    private void Jump()
    {
        //transform.Translate(Vector3.up * 260 * Time.deltaTime, Space.World);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 10f, rb.velocity.z);
        jumpSound.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Untagged")
            jumping = false;
    }
}

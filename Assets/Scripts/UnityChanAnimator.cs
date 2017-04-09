using UnityEngine;
using System.Collections;

public class UnityChanAnimator : MonoBehaviour 
{
    private Animator ani;
    private PlayerController player;
    private bool animating = false;

    // Use this for initialization
    void Start () 
    {
        ani = GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
	
    // Update is called once per frame
    void Update () 
    {
        /*
        if (Input.GetAxis("Horizontal") < 0)
            ani.SetTrigger("left");
        else if (Input.GetAxis("Horizontal") > 0)
            ani.SetTrigger("right");
        else
            ani.SetTrigger("default");
        */

        /*
        if (Input.GetAxis("Horizontal") < 0)
        {
            ResetAnimations();
            ani.SetBool("left_b", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            ResetAnimations();
            ani.SetBool("right_b", true);
        }
        else
        {
            ResetAnimations();
            ani.SetBool("default_b", true);
        }*/

        if (player.health > 0f)
        {
            /*if (Input.GetAxis("Horizontal") < 0)
                ani.Play("myUnitychan_turnLeft");
            else if (Input.GetAxis("Horizontal") > 0)
                ani.Play("myUnitychan_turnRight");
            else if (Input.GetAxis("Vertical") > 0)
                ani.Play("myUnitychan_forward");
            else if (Input.GetAxis("Vertical") < 0)
                ani.Play("myUnitychan_backward");
            else
                ani.Play("myUnitychan_default");*/

            //Debug.Log(Input.GetAxisRaw("Horizontal"));
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                ani.SetFloat("hor", Input.GetAxis("Horizontal"));
                ani.SetFloat("ver", Input.GetAxis("Vertical"));
            }

        }
        else
        {
            //ani.Play("myUnitychan_death");
            if (!animating)
            {
                ani.SetTrigger("die");
                animating = true;
            }
        }
    }

    void ResetTriggers()
    {
        /*ani.ResetTrigger("left");
        ani.ResetTrigger("right");
        ani.ResetTrigger("forward");
        ani.ResetTrigger("backward");
        ani.ResetTrigger("die");*/
        ani.SetTrigger("default");
    }

    void ResetAnimations()
    {
        ani.SetBool("left_b", false);
        ani.SetBool("right_b", false);
        ani.SetBool("default_b", false);
    }
}

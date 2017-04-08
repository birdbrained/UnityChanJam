using UnityEngine;
using System.Collections;

public class UnityChanAnimator : MonoBehaviour 
{
    private Animator ani;
    private PlayerController player;

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
            if (Input.GetAxis("Horizontal") < 0)
                ani.Play("myUnitychan_turnLeft");
            else if (Input.GetAxis("Horizontal") > 0)
                ani.Play("myUnitychan_turnRight");
            else if (Input.GetAxis("Vertical") > 0)
                ani.Play("myUnitychan_forward");
            else if (Input.GetAxis("Vertical") < 0)
                ani.Play("myUnitychan_backward");
            else
                ani.Play("myUnitychan_default");
        }
        else
        {
            ani.Play("myUnitychan_death");
        }
    }

    void ResetAnimations()
    {
        ani.SetBool("left_b", false);
        ani.SetBool("right_b", false);
        ani.SetBool("default_b", false);
    }
}

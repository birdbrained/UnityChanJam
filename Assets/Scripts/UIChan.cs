using UnityEngine;
using System.Collections;

public class UIChan : MonoBehaviour 
{
    private Animator ani;
    private GameObject player;
    private PlayerController playerC;

    // Use this for initialization
    void Start () 
    {
        ani = GetComponent<Animator>();
        player = GameObject.Find("Player");
        if (player != null)
            playerC = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update () 
    {
        if (playerC != null)
        {
            //hurt
            //die
            //goal
            //default
            if (playerC.IsDead)
                ani.SetTrigger("die");
            else if (playerC.immortal)
                ani.SetTrigger("hurt");
            else if (GameManager.Instance.ThisLevelScore >= GameManager.Instance.thisLevelGoal)
                ani.SetTrigger("goal");
            else
                ani.SetTrigger("default");
        }
    }
}

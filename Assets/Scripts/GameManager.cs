using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    /*private static float health;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }*/

    //public Text healthText;

    // Use this for initialization
    void Start () {
        //healthText.text = health.ToString("F2");
    }

    // Update is called once per frame
    void Update () {
        //healthText.text = health.ToString("F2");
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    private static int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }
    [SerializeField]
    private Text scoreText;

    private static bool timerActive = false;
    public bool TimerActive
    {
        get
        {
            return timerActive;
        }
        set
        {
            timerActive = value;
        }
    }
    private float timer = 15f;
    [SerializeField]
    private Text timerText;

    private static int nitroNum;
    public int NitroNum
    {
        get
        {
            return nitroNum;
        }
        set
        {
            nitroNum = value;
        }
    }
    [SerializeField]
    private Text nitroText;

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



    string CashifyIt(int moneh)
    {
        string baseScore = moneh.ToString();
        string cashedScore = "";

        int commaPlace = 0;
        for (int i = baseScore.Length - 1; i >= 0; i--)
        {
            commaPlace++;
            cashedScore = cashedScore + baseScore[i];
            if (commaPlace == 3 && i > 0)
            {
                cashedScore = cashedScore + ",";
                commaPlace = 0;
            }
        }

        string fixedScore = "";
        for (int i = 1; i <= cashedScore.Length; i++)
        {
            fixedScore = fixedScore + cashedScore[cashedScore.Length - i];
        }

        return "$" + fixedScore;
    }

    // Use this for initialization
    void Start () 
    {
        //healthText.text = health.ToString("F2");
    }

    // Update is called once per frame
    void Update () 
    {
        //healthText.text = health.ToString("F2");
        if (scoreText != null)
            scoreText.text = CashifyIt(score);

        if (timerActive && timerText != null)
        {
            timerText.text = "0:" + timer.ToString("00");
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timerActive = false;
                Debug.Log("Time's up!");
                SceneManager.LoadScene("GameOver");
            }
        }
        else if (!timerActive && timerText != null)
            timerText.text = "";

        if (nitroText != null && nitroNum > 0)
            nitroText.text = "NITRO: x" + nitroNum.ToString();
        else if (nitroText != null)
            nitroText.text = "";
    }

    public void ResetScore()
    {
        score = 0;
    }
}

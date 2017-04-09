using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeSceneButton : MonoBehaviour 
{

    // Use this for initialization
    void Start () 
    {
        
    }

    // Update is called once per frame
    void Update () 
    {
        
    }

    public void ChangeScene(string s)
    {
        SceneManager.LoadScene(s);
    }

    public void DohQuitGame()
    {
        Application.Quit();
    }
}

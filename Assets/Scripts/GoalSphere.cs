using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalSphere : MonoBehaviour 
{
    [SerializeField]
    private string nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            SceneManager.LoadScene(nextLevel);
    }
}

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float health;

	// Use this for initialization
	void Start () 
    {
        GameManager.Instance.Health = health;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

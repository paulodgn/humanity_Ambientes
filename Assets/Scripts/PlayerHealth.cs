using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{

    public int playerHealth;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void PlayerTakeDamage()
    {
        if(playerHealth > 0)
        {
            playerHealth-=1;
        }
        else if(playerHealth <= 0)
        {
            Debug.Log("morreste");
        }
    }
}

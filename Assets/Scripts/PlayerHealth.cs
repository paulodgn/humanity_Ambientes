using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour 
{

    public int playerHealth;
    public Slider healthSlider;
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
            healthSlider.value = playerHealth;
        }
        else if(playerHealth <= 0)
        {
            Debug.Log("morreste");
        }
    }
}

using UnityEngine;
using System.Collections;

public class lanternaControl : MonoBehaviour {

    public Light lanterna;
    bool acender;
    playerControl player;
	// Use this for initialization
	void Start () 
    {
        player = GetComponentInParent<playerControl>();
        lanterna.enabled = false;
        acender = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	   

        if (player.isArmed)
            lanterna.enabled = true;
        else
            lanterna.enabled = false;

	}
}

using UnityEngine;
using System.Collections;

public class lanternaControl : MonoBehaviour {

    public Light lanterna;
    playerControl player;
	// Use this for initialization
	void Start () 
    {
        player = GetComponentInParent<playerControl>();
        lanterna.enabled = false;
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

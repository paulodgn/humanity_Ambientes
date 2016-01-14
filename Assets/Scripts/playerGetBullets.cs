using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerGetBullets : MonoBehaviour 
{

    GameObject player;
    playerControl playerControl;
    MeshRenderer bala;
    public Text textGetBullet;

	// Use this for initialization
	void Awake () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<playerControl>();
        bala = gameObject.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
            playerControl.hasBullets = true;
            bala.enabled = false;
            textGetBullet.color = Color.green;
        }
    }
       
}

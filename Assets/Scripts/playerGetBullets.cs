using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerGetBullets : MonoBehaviour 
{

    GameObject player;
    playerControl playerControl;
    MeshRenderer bala;
    public Text textGetBullet;
    AudioSource som;

	// Use this for initialization
	void Awake () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = player.GetComponent<playerControl>();
        som = gameObject.GetComponent<AudioSource>();
        bala = gameObject.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
            som.Play();
            playerControl.hasBullets = true;
            bala.enabled = false;
            textGetBullet.color = Color.green;
        }
    }
       
}

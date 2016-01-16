using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerGetsKey : MonoBehaviour {

    GameObject player;
    playerControl playerControl;
    MeshRenderer chave;
    EnemyHealth enemy;
    Collider colliderChave;
    bool enemyKilled;
    public Text textGetKey;
    AudioSource som;
	// Use this for initialization
	void Awake () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>();
        chave = GetComponent<MeshRenderer>();
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyHealth>();
        colliderChave = gameObject.GetComponent<Collider>();
        som = gameObject.GetComponent<AudioSource>();
        colliderChave.enabled = false;
        chave.enabled = false;
        enemyKilled = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(enemy.enemyHealth<=0 && !enemyKilled)
        {
            colliderChave.enabled = true;
            chave.enabled = true;
            enemyKilled = true;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
            som.Play();
            playerControl.hasKey = true;
            chave.enabled = false;
            textGetKey.color = Color.green;
        }
    }
}

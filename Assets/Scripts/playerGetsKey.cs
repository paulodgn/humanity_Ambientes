using UnityEngine;
using System.Collections;

public class playerGetsKey : MonoBehaviour {

    GameObject player;
    playerControl playerControl;
    MeshRenderer chave;
    EnemyHealth enemy;
    Collider colliderChave;
    bool enemyKilled;
	// Use this for initialization
	void Awake () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>();
        chave = GetComponent<MeshRenderer>();
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<EnemyHealth>();
        colliderChave = gameObject.GetComponent<Collider>();
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
            
            playerControl.hasKey = true;
            chave.enabled = false;
            Debug.Log("colidiu com chave");
        }
    }
}

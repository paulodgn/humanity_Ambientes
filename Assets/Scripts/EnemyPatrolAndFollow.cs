using UnityEngine;
using System.Collections;

public class EnemyPatrolAndFollow : MonoBehaviour {

    GameObject player;
    PlayerHealth playerHealth;
    public Transform[] patrolPoints;
    int patrolPointID;
    NavMeshAgent enemyAgent;
    DroneAlarm droneAlarm;
    Transform PlayerPosition;
    Animator anim;
    EnemyHealth enemyHealth;
    public AudioSource die;
    public AudioSource shoot;
	void Start () 
    {
        patrolPointID = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        enemyAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nextPatrolSpot();
        droneAlarm = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneAlarm>();
        anim.SetBool("Walk", true);
        enemyHealth = gameObject.GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //se inimigo esta morto desativa navAgent
        if (enemyAgent.enabled && enemyHealth.enemyHealth <= 0)
        {
            die.Play();
            enemyAgent.enabled = false;
            
        }
        //se inimigo esta vivo procura proximo alvo
        if (enemyAgent.enabled == true )
        {
            //se alarme esta desligado vai para o proximo ponto de patrulha
            if (enemyAgent.remainingDistance < 0.5f && !droneAlarm.alarm)
            {
                nextPatrolSpot();
            }
            //se alarme esta ligado vai de encontro ao player
            if (droneAlarm.alarm)
            {
                goToPlayer();
            }
        }

	}

    void nextPatrolSpot()
    {
        if (patrolPointID < patrolPoints.Length)
        {
            patrolPointID++;
        }
        else
        {
            patrolPointID = 0;
        }

        enemyAgent.destination = patrolPoints[patrolPointID].position;
    }
    //vai se encontro ao jogador
    void goToPlayer()
    {
        if (playerHealth.playerHealth > 0)
        {
            enemyAgent.destination = player.transform.position;
        }
        else
        {
            droneAlarm.alarm = false;
            patrolPointID = 0;
            nextPatrolSpot();
        }
    }
    //se encontrar o jogador
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player && playerHealth.playerHealth>0)
        {
            droneAlarm.alarm = true;
            
        }
    }
}

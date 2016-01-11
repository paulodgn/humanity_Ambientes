using UnityEngine;
using System.Collections;

public class EnemyPatrolAndFollow : MonoBehaviour {

    GameObject player;
    public Transform[] patrolPoints;
    int patrolPointID;
    NavMeshAgent enemyAgent;
    DroneAlarm droneAlarm;

    Transform PlayerPosition;

    Animator anim;
    EnemyHealth enemyHealth;
	void Start () 
    {
        patrolPointID = 0;
        player = GameObject.FindGameObjectWithTag("Player");
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
        if(enemyHealth.enemyHealth <= 0)
        {
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

    void goToPlayer()
    {
        enemyAgent.destination = player.transform.position;
    }
}

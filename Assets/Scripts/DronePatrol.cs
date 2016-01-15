using UnityEngine;
using System.Collections;

public class DronePatrol : MonoBehaviour {

    public Transform[] patrolPoints;
    NavMeshAgent droneAgent;
    int patrolPointID;
	void Awake () 
    {
        droneAgent = GetComponent<NavMeshAgent>();
        patrolPointID = 0;
        nextPatrolSpot();
	}
	
	
	void Update () 
    {
        //se a distancia para o ponto de patrulha for inferior a 0.5, passa para o proximo.
	    if(droneAgent.remainingDistance < 0.5f)
        {
            nextPatrolSpot();
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
        //define o destino do agent.
        droneAgent.destination = patrolPoints[patrolPointID].position;
    }

}

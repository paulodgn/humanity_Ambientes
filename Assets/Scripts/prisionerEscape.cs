using UnityEngine;
using System.Collections;

public class prisionerEscape : MonoBehaviour {

    public Transform[] escapePoints;
    int escapePointID;
    NavMeshAgent agent;
    public Animator anim;
    public bool free;
    public bool startEscape;

	// Use this for initialization
	void Start () 
    {
        escapePointID = -2;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        free = false;
        startEscape = false;
        //nextEscapePoint();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (startEscape)
        {
            nextEscapePoint();
            startEscape = false;
        }

	    if(free)
        {
            if (agent.remainingDistance < 0.5f)
            {
                nextEscapePoint();
            }
        }
       
	}

    void nextEscapePoint()
    {
        
            if (escapePointID < escapePoints.Length)
            {
                escapePointID++;
            }
            agent.destination = escapePoints[escapePointID].position;
        
    }


}

using UnityEngine;
using System.Collections;

public class prisionerEscape : MonoBehaviour {

    public Transform[] escapePoints;
    int escapePointID;
    NavMeshAgent agent;
    Animator anim;
    bool free;

	// Use this for initialization
	void Start () 
    {
        escapePointID = -1;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        free = true;
        anim.SetBool("Run", true);
        nextEscapePoint();
	}
	
	// Update is called once per frame
	void Update ()
    {
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
        if(escapePointID < escapePoints.Length)
        {
            escapePointID++;
        }
        agent.destination = escapePoints[escapePointID].position;
    }
}

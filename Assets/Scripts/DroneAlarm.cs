using UnityEngine;
using System.Collections;

public class DroneAlarm : MonoBehaviour 
{

    GameObject player;
    Light luzDrone;
    public bool alarm;
	
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        luzDrone = gameObject.GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            alarm = true;
            AlarmOn();
        }
    }

  
    void AlarmOn()
    {
        luzDrone.color = Color.red;
    }

    void AlarmOff()
    {
        luzDrone.color = Color.white;
    }
}

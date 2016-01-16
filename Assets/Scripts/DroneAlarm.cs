using UnityEngine;
using System.Collections;

public class DroneAlarm : MonoBehaviour 
{

    GameObject player;
    Light luzDrone;
    public bool alarm;
    AudioSource[] sounds;
	
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        luzDrone = gameObject.GetComponentInChildren<Light>();
        sounds = gameObject.GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            sounds[1].Play();
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

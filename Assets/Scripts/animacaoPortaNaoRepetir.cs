using UnityEngine;
using System.Collections;

public class animacaoPortaNaoRepetir : MonoBehaviour {

    Animation anim;
    Animator animator;
    float timer=0;
    GameObject player;
    prisionerEscape escape;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        escape = GameObject.FindGameObjectWithTag("prisioner").GetComponent<prisionerEscape>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        
        
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && Input.GetKeyDown(KeyCode.F))
        {
            
                anim = GetComponent<Animation>();
                anim.wrapMode = WrapMode.ClampForever;
                anim.Play();
                escape.startEscape = true;
                escape.free = true;
                escape.anim.SetBool("Run", true);
                
           
        }
    }
}

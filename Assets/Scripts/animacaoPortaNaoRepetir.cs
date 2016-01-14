using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class animacaoPortaNaoRepetir : MonoBehaviour {

    Animation anim;
    Animator animator;
    float timer=0;
    GameObject player;
    playerControl playerControl;
    prisionerEscape escape;
    public Text textSavePrisioner;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<playerControl>();
        escape = GameObject.FindGameObjectWithTag("prisioner").GetComponent<prisionerEscape>();
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        
        
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player && Input.GetKeyDown(KeyCode.F) && playerControl.hasKey)
        {
            
                anim = GetComponent<Animation>();
                anim.wrapMode = WrapMode.ClampForever;
                anim.Play();
                escape.startEscape = true;
                escape.free = true;
                escape.anim.SetBool("Run", true);
                textSavePrisioner.color = Color.green;
           
        }
    }
}

using UnityEngine;
using System.Collections;

public class animacaoPortaNaoRepetir : MonoBehaviour {

    Animation anim;
    Animator animator;
    float timer=0;
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.time;
        if(timer >= 100)
        {
            anim = GetComponent<Animation>();
            //animator = GetComponent<Animator>();
            //animator.SetBool("AbrirPorta", true);
            anim.wrapMode = WrapMode.ClampForever;
            anim.Play();
            timer = 0;
        }
        
        
	}
}

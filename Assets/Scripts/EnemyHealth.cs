using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int enemyHealth;
    Animator anim;


    // Use this for initialization
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyTakeDamage()
    {
        //se ainda esta vivo retira health
        if (enemyHealth > 0)
        {
            enemyHealth-=1;
            Debug.Log(enemyHealth);
        }
        //se health chegar a zero morre
        if (enemyHealth == 0)
        {
            
            Animation animation = GetComponent<Animation>();
            animation.wrapMode = WrapMode.ClampForever;
            
            //anim.SetBool("Walk", false);
            anim.enabled = false;
            animation.Play();
            Debug.Log("enemy morreu");
        }
    }
}

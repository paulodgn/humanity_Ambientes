using UnityEngine;
using System.Collections;

public class DisparaBala : MonoBehaviour {

    public int damage;
    public float timeBetwwenBullets;
    public float range;

    float displayTime = 0.02f;
    float timer;
    Ray shootRay;
    RaycastHit shootHit;

    LineRenderer shootLine;
    Light shootLuz;

    public GameObject player;
    playerControl playerControl;

	void Awake () 
    {
        shootLine = GetComponent<LineRenderer>();
        shootLuz = GetComponent<Light>();
        playerControl = player.GetComponent<playerControl>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        if(Input.GetButton("Fire1") && timer >= timeBetwwenBullets && playerControl.hasBullets && playerControl.isArmed)
        {
            shoot();
        }
        if(timer >= timeBetwwenBullets*displayTime)
        {
            shootLine.enabled = false;
            shootLuz.enabled = false;
        }

	}

    void shoot()
    {
        timer = 0f;
        shootLine.enabled = true;
        shootLuz.enabled = true;
        shootLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = player.transform.forward;
        //verifica onde atingiu o raycast
        if(Physics.Raycast(shootRay, out shootHit, range))
        {
            //se atingiu o inimigo retira lhe vida
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<Collider>().GetComponent<EnemyHealth>();
            if(enemyHealth!=null)
            {
                enemyHealth.EnemyTakeDamage();
            }
            shootLine.SetPosition(1, shootHit.point);
        }
        else
        {
            shootLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

    }
}

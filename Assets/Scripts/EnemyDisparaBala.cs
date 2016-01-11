using UnityEngine;
using System.Collections;

public class EnemyDisparaBala : MonoBehaviour
{

    public int damage;
    public float timeBetwwenBullets;
    public float range;

    float displayTime = 0.02f;
    float timer;
    Ray shootRay;
    RaycastHit shootHit;

    LineRenderer shootLine;
    Light shootLuz;

    GameObject player;
    Rigidbody enemy;
    NavMeshAgent enemyAgent;
    DroneAlarm droneAlarm;

    void Awake()
    {
        shootLine = GetComponent<LineRenderer>();
        shootLuz = GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = gameObject.GetComponentInParent<Rigidbody>();
        enemyAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        droneAlarm = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneAlarm>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (enemyAgent.enabled == true)
        {
            //se atingir distancia de disparo, dispara duh
            if (enemyAgent.remainingDistance < 20f && droneAlarm.alarm && timer >= timeBetwwenBullets)
            {
                shoot();
            }
            if (timer >= timeBetwwenBullets * displayTime)
            {
                shootLine.enabled = false;
                shootLuz.enabled = false;
            }
        }

    }

    void shoot()
    {
        timer = 0f;
        shootLine.enabled = true;
        shootLuz.enabled = true;
        shootLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = enemy.transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range))
        {
            //se raycast atingir player retira lhe dano
            PlayerHealth playerHealth = shootHit.collider.GetComponent<Collider>().GetComponent<PlayerHealth>();
            if(playerHealth!=null)
            {
                playerHealth.PlayerTakeDamage();
            }
            shootLine.SetPosition(1, shootHit.point);
        }
        else
        {
            shootLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

    }
}

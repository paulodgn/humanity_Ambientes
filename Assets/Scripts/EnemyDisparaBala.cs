﻿using UnityEngine;
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

    Rigidbody enemy;
    NavMeshAgent enemyAgent;
    DroneAlarm droneAlarm;
    AudioSource somDisparo; 

    void Awake()
    {
        shootLine = GetComponent<LineRenderer>();
        shootLuz = GetComponent<Light>();
        enemy = gameObject.GetComponentInParent<Rigidbody>();
        enemyAgent = gameObject.GetComponentInParent<NavMeshAgent>();
        droneAlarm = GameObject.FindGameObjectWithTag("Drone").GetComponent<DroneAlarm>();
        somDisparo = GameObject.FindGameObjectWithTag("enemy").GetComponent<AudioSource>();
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
        somDisparo.Play();
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

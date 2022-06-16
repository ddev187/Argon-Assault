using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int amountToIncrease = 20;
    [SerializeField] int enemyHP = 2;
    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        if(enemyHP < 1)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        scoreboard.IncreaseScore(amountToIncrease);
        enemyHP--;
        Instantiate(hitVFX, transform.position, Quaternion.identity);
    }

    void Update()
    {
        Debug.Log(enemyHP);
    }
}

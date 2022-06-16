using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int amountToIncrease = 20;

    float enemyHP = 3f;
    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        // if(enemyHP == 0)
        // {
        //     KillEnemy();
        // }
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
        enemyHP = enemyHP - 1;
        Instantiate(hitVFX, transform.position, Quaternion.identity);
        if(enemyHP >= 0)
        {
            KillEnemy();
        }
    }

    void Update()
    {
        Debug.Log(enemyHP);
    }
}

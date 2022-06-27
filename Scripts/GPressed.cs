using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GPressed : MonoBehaviour
{
    public MoveMaze innermaze;
    public EnemyController enemy;

    public PortedDeathScreen PortedDeathScreen;

    private int health;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            FindObjectOfType<EnemyController>().setDead();
            health = enemy.currentHealth;
            Debug.Log("The Player has taken " + health + " damage points.");
            Debug.Log("GAMEOVER");
            PortedDeathScreen.DisplayPortedDeath();
            innermaze.HideMaze();

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/**
 * EnemyController controls the enemy. It is supposed to be on the enemy Gameobject.
 **/
public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public float damageRadius = 4f;

    // will be filled with instaces of player & enemy:
    Transform target;
    NavMeshAgent agent;

    // health & exhaustion:
    public int damage;
    public Stat exhaustion;
    public int maxHealth = 100;
    public int currentHealth;

    // damage UI:
    public DamageScreen damageUI;
    public float displayTime = 1f;
    private float turnOff = 0f;

    // time delay:
    private float nextHitPossible = 0f;
    public float damagePause = 2f;

    // control variable:
    bool dead = false;

    public void setDead()
    {
        dead = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);  // throws a NonReference Problem!

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }

            if (distance <= damageRadius && nextHitPossible < Time.time && !dead)
            {
                // take damage UI:
                damageUI.DisplayDamageUI();
                turnOff = Time.time + displayTime;

                // take damage first:
                TakeDamage(damage);

                // calculate new hitTime:
                nextHitPossible = Time.time + damagePause;

            }

            // if time has passed, remove the damage UI again:
            if (Time.time >= turnOff)
            {
                damageUI.RemoveDamageUI();
            }

        }


    }

    void FaceTarget()
    {
        // get the direction of the target
        Vector3 direction = (target.position - transform.position).normalized;

        // calculate look-rotation
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        // update own rotation gradually (!)
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage * exhaustion.GetValue();
        Debug.Log("The Player has taken " + damage + " damage points.");

        if (currentHealth <= 0)
        {
            Die();
            dead = true;
        }
    }

    // this is supposed to be overwritten / customized:
    public virtual void Die()
    {
        // Debug.Log(transform.name + " died.");
        FindObjectOfType<GameManager>().GameOver();

    }

    public void ResetEnemy()
    {
        dead = false;
        Start();
        Awake();

    }
}

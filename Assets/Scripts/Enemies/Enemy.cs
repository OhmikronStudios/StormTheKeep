using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    [SerializeField] float moveSpeed;
    [SerializeField] int fundsOnKill;
    [SerializeField] int damageOnKeep;
    PathTile targetTile;
    [SerializeField] List<PathTile> path;
    int currentTile = 0;

    [SerializeField] int health;
    public Transform targetPoint;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        Pathfinder pf = FindObjectOfType<Pathfinder>();
        path = pf.GetPath();
        targetTile = path[currentTile];
    }

    protected virtual void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.LookAt(targetTile.transform);
        transform.position = Vector3.MoveTowards(transform.position, targetTile.transform.position, moveSpeed * Time.deltaTime);
        float distToTarget = Vector3.Distance(transform.position, targetTile.transform.position);
        if (distToTarget < 0.5f)
        {
            if (currentTile + 1 == path.Count)
            {
                DamageKeep();
                FindObjectOfType<EnemySpawner>().EnemyRemoved();
                Destroy(gameObject);
            }
            else
            {
                currentTile += 1;
                targetTile = path[currentTile];
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        ProcessHit(other.gameObject.GetComponent<Projectile>().getDamageAmount());
        Destroy(other.gameObject);
        if (health <= 0)
        {
            KillEnemy();
        }
    }



    void ProcessHit(int damage)
    {
        health -= damage;
    }

    private void KillEnemy()
    {
        FindObjectOfType<LevelManager>().AcquireFunds(fundsOnKill);
        FindObjectOfType<EnemySpawner>().EnemyRemoved();
        Destroy(gameObject);
    }

    private void DamageKeep()
    {
        FindObjectOfType<Keep>().TakeDamage(damageOnKeep);
    }


}

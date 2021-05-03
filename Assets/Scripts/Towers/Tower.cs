using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //Param
    [SerializeField] Transform objectToRotate;
    [SerializeField] float attackRange = 10f;

    AudioCue ac;
    [SerializeField] AudioCueSO build;
    [SerializeField] AudioCueSO fire;


    //State
    public GameObject targetEnemy;
    public bool canFire = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ac = GetComponent<AudioCue>();
        ac.PlayAudioCue(build);
    }


    // Update is called once per frame
    protected virtual void Update()
    {
        SetTargetEnemy();
        if(targetEnemy && canFire)
        {
            objectToRotate.LookAt(targetEnemy.transform);
            IsEnemyInRange();
        }
        else
        {

        }
        //Debug.DrawLine(transform.position, transform.position + Vector3.forward * attackRange);
        
    }

    private void IsEnemyInRange()
    {
        float distanceToTarget = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if(distanceToTarget <= attackRange && canFire)
        {
            Shoot();
        }   
    }

    protected virtual void Shoot()
    {
        ac.PlayAudioCue(fire);
    }

    private void SetTargetEnemy()
    {
        var enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length == 0) { return; }
        {
            Transform closestEnemy = enemies[0].transform;

            foreach(Enemy test in enemies)
            {
                closestEnemy = GetClosest(closestEnemy, test.transform);
            }

            targetEnemy = closestEnemy.gameObject;

        }
    }

    private Transform GetClosest(Transform e1, Transform e2)
    {
        float disToA = Vector3.Distance(e1.position, transform.position);
        float disToB = Vector3.Distance(e2.position, transform.position);

        if (disToA < disToB)
        {
            return e1;
        }
        else return e2;
    }

}

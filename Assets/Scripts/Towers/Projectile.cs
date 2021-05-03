using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    Rigidbody rb;
    public Transform target;

    public int damagePerHit;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            transform.LookAt(target.position);
            rb.MovePosition(Vector3.Lerp(transform.position, target.position, speed));
        }
        else
        {
            Destroy(gameObject);
        }   
    }

    public int getDamageAmount()
    {
        return damagePerHit;
    }
}

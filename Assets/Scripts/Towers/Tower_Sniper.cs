using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Sniper : Tower
{
    [SerializeField] float fireDelay = 0.5f;
    [SerializeField] [Range(0.1f, 1.0f)] float projSpeed = 0.3f;
    [SerializeField] int damage = 5;

    [SerializeField] Transform barrel1;
    [SerializeField] Projectile projectile;


    bool readyToFire = true;





    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Shoot()
    {
        if (readyToFire)
        {
            base.Shoot();
            readyToFire = false;
            Projectile b = Instantiate(projectile);

            b.transform.position = barrel1.position;
            b.speed = projSpeed;
            b.target = targetEnemy.GetComponent<Enemy>().targetPoint;
            b.damagePerHit = damage;

            StartCoroutine(DelayFire());
        }
    }

    IEnumerator DelayFire()
    {
        yield return new WaitForSeconds(fireDelay);
        readyToFire = true;
    }
}

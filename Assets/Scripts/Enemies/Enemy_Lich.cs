using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Lich : Enemy
{
    bool canFreezeTower = true;
    [SerializeField] float freezeTime = 5f;
    [SerializeField] GameObject Iceblock;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (canFreezeTower)
        {
            FreezeTower();
        }
    }

    private void FreezeTower()
    {
        Tower[] targetTowers = FindObjectsOfType<Tower>();
        foreach(Tower t in targetTowers)
        {
            if(t.canFire == true)
            {
                StartCoroutine(freezeCounter(t));
                StartCoroutine(freezeCooldown());
                Debug.Log("freezing " + t.name);
                break;
            }
            else
            {

            }
        }
    }

    IEnumerator freezeCounter(Tower t)
    {
        t.canFire = false;
        GameObject ice = Instantiate(Iceblock, t.transform.position, Quaternion.identity);
        //t.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        yield return new WaitForSeconds(freezeTime);
        t.canFire = true;
        Destroy(ice);
        //t.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;

    }

    IEnumerator freezeCooldown()
    {
        canFreezeTower = false;
        yield return new WaitForSeconds(freezeTime*3);
        canFreezeTower = true;
    }
}



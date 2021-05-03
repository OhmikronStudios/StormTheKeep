using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keep : MonoBehaviour
{
    [SerializeField] int keepHealth;
    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetHealth()
    {
        return keepHealth;
    }

    public void TakeDamage(int damage)
    {
        keepHealth -= damage;
        if(keepHealth <= 0)
        {
            lm.LevelComplete(false);
        }
        else
        {
           lm.UpdateHealth();
        }
    }
}

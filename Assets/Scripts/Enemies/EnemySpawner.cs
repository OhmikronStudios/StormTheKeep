using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float timeBetweenWaves = 15f;
    [SerializeField] List<WaveConfiguration> waves;
    int enemiesRemaining;
    PathTile spawnTile;
    LevelManager lm;
    int currentWave = 0; 
    bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnTile = FindObjectOfType<Pathfinder>().StartTile;
        lm = FindObjectOfType<LevelManager>();
        lm.maxWaves = waves.Count;
        SpawnNextWave();
    }

    private void Update()
    {
        
        if (enemiesRemaining <= 0 && !gameOver)
        {
            GameOverCheck();
        }
    }

    private void GameOverCheck()
    {
        if (currentWave == waves.Count)
        {
            gameOver = true;
            lm.LevelComplete(true);
        }
        else
        {
            Debug.Log("Preparing next wave");
            SpawnNextWave();
            
        }
    }

    private void SpawnNextWave()
    {
        Debug.Log("Starting Wave " + (currentWave + 1));
        StartCoroutine(SpawnWave(waves[currentWave].GetEnemyList()));
        
    }
    
    IEnumerator SpawnWave(Enemy[] enemies)
    {
        enemiesRemaining += enemies.Length;
        Debug.Log("enemies remaining: " + enemiesRemaining);
        foreach (Enemy enemy in enemies)
        {
            Instantiate(enemy, spawnTile.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
        currentWave += 1;
    }

    public void EnemyRemoved()
    {
        enemiesRemaining -= 1;
        Debug.Log("enemies remaining: " + enemiesRemaining);
    }

    public int GetWave()
    {
        return currentWave;
    }

    
    
}
    

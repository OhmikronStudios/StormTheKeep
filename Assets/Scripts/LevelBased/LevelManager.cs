using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class LevelManager : MonoBehaviour
{
    //Objects
    [SerializeField] GameObject gameHUD;
    [SerializeField] TMP_Text currency; 
    [SerializeField] TMP_Text waveCounter; 
    [SerializeField] Slider keepHealth;

    [SerializeField] GameObject missionCompletePanel;
    [SerializeField] GameObject PausePanel;
    [SerializeField] TMP_Text successText;


    //States
    [SerializeField] int currentMoney = 100;
    public Tower_SO currentTower;
    Keep keep;
    EnemySpawner eSpawn;

    public int wave;
    public int maxWaves;
    public bool overUI;
    public bool gamePaused = false;



    // Start is called before the first frame update
    void Start()
    {
        gameHUD.SetActive(true);
        missionCompletePanel.SetActive(false);
        keep = FindObjectOfType<Keep>();
        eSpawn = FindObjectOfType<EnemySpawner>();
        keepHealth.maxValue = keep.GetHealth();
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        currency.text = currentMoney.ToString();
        UpdateWaves();
        if(Input.GetMouseButtonDown(0))
        {
            if(!overUI)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 500))
                {

                    if(hit.collider.gameObject.tag == "TowerTile" && hit.collider.gameObject.GetComponent<TowerTile>().isPlaceable)
                    {
                        hit.collider.gameObject.GetComponent<TowerTile>().BuildTower(currentTower);
                        Debug.Log("Building Tower through LM");
                    }
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    private void OnLevelWasLoaded(int level)
    {
        ResumeGame();
    }

    public void ResumeGame()
    {
        gamePaused = false;
        Time.timeScale = 1.0f;
        PausePanel.SetActive(false);
        gameHUD.SetActive(true);
    }

    private void PauseGame()
    {
        gamePaused = true;
        Time.timeScale = 0.0f;
        PausePanel.SetActive(true);
        gameHUD.SetActive(false);
    }

    public int GetFunds()
    {
        return currentMoney;
    }

    public void DeductFunds(int funds)
    {
        currentMoney -= funds;
    }

    public void AcquireFunds(int funds)
    {
        currentMoney += funds;
    }

    public Tower_SO GetTower()
    {
        return currentTower;
    }

    public void UpdateHealth()
    {
        keepHealth.value = keep.GetHealth();
    }

    public void UpdateWaves()
    {
        waveCounter.text = "Wave " + eSpawn.GetWave() + " of " + maxWaves;
    }

    public void LevelComplete(bool wasSuccessful)
    {
        gameHUD.SetActive(false);
        missionCompletePanel.SetActive(true);
        if(wasSuccessful)
        {
            successText.text = "Mission Complete!";
        }
        else
        {
            successText.text = "Mission Failed";
        }
    }

}

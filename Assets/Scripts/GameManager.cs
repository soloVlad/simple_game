using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject titleScreen;
    private int score;
    private float spawnRangeX = 20f;
    private float spawnPosZ = 20f;
    private float spawnInterval = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }

    IEnumerator SpawnTarget(int amount)
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            for (int i = 0; i < amount; i++)
            {
                SpawnRandomAnimal();
            }
        }
    }
    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        int amountOfTargets = 1;
        isGameActive = true;
        score = 0;

        switch (difficulty)
        {
            case 1:
                spawnInterval = 1.8f;
                amountOfTargets = 1;
                break;
            case 2:
                spawnInterval = 1.6f;
                amountOfTargets = 1;
                break;
            case 3:
                spawnInterval = 1.7f;
                amountOfTargets = 2;
                break;
        }

        StartCoroutine(SpawnTarget(amountOfTargets));
        UpdateScore(0);
        
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}

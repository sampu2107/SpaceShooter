using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;
    public int score;
    private bool gameOver;
    private bool restart;

	// Use this for initialization
	void Start () {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine (SpawnWaves());	
	}
	
	// Update is called once per frame
	void Update () {
     if (restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(0);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    
     if (score > 100 && !(SceneManager.GetActiveScene().buildIndex == 2))
       {
          Initiate.Fade("Main2", Color.white, 0.8f);
       } 
	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait); //wait for the player to get ready by not instantiating the hazard for some time
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z); //Spawning the hazards at random x positions
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait); //wait till instantiating the next hazard
            }
            yield return new WaitForSeconds(waveWait); //wait till instantiating the next set of waves

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break; 
            }
        }
    }

    // Will be used by the hazard game object to inform controller
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true; 
    }
}

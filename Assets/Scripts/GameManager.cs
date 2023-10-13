using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GameObject rainPrefab;
    public GameObject gameOverPanel;

    int totalScore = 0;
    float timeLimit = 60.0f;
    public Text scoreText;
    public Text timeText;
    // Start is called before the first frame update
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }

    void Start()
    {
        InitGame();

        InvokeRepeating("SpawnRain", 0, 0.5f);
    }

    void InitGame()
    {
        totalScore = 0;
        timeLimit = 5.0f;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        timeText.text = string.Format("{0:#0.00}", timeLimit);

        if (timeLimit <= 0)
        {
            Time.timeScale = 0.0f;
            gameOverPanel.SetActive(true);
        }
    }

    /* Spawn Rain Prefab */
    void SpawnRain()
    {
        Instantiate(rainPrefab);
    }

    /* Add Score when Rain collider player */
    public void AddScore(int score)
    {
        this.totalScore += score;
        scoreText.text = this.totalScore.ToString();
    }

    /* Reload Main Scene to start new Game */
    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}

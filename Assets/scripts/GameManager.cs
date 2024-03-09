using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] TextMeshProUGUI scoreText, gameOverScoreTxt, gameOverHightScoreTxt, startGameHightScoreTxt;
    [SerializeField] GameObject gameStartedPanel, gameOverPanel;
    Player playerSrc;
    int score = 0;
    int loadedHightScore;

    bool hasGameStarted = false;
    bool hasGameOver = false;


    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("SpawnObstacle", 0f, 1.5f);
        playerSrc = FindObjectOfType<Player>();
        loadedHightScore = PlayerPrefs.GetInt("HighScore");
        startGameHightScoreTxt.text = loadedHightScore.ToString();
    }

    void SpawnObstacle()
    {
        if(hasGameStarted && !hasGameOver)
        {
            Vector2 playerPos = playerSrc.GetPosition();
            GameObject tmpObstacle = Instantiate(obstaclePrefab, new Vector2(playerPos.x + 15, Random.Range(-3f, 3f)), Quaternion.identity);
        }
    }

    public void ScorePoint()
    {
        score++;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(!hasGameStarted)
            {
                hasGameStarted = true;
                playerSrc.StartGame();
                gameStartedPanel.SetActive(false);
            }
            else if (hasGameOver)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void GameOver()
    {
        hasGameOver = true;
        gameOverPanel.SetActive(true);
        gameOverScoreTxt.text = score.ToString();
        int loadedHightScore= PlayerPrefs.GetInt("HighScore");
        if(score > loadedHightScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            gameOverHightScoreTxt.text = score.ToString();
        }
        else
        {
            gameOverHightScoreTxt.text = loadedHightScore.ToString();
        }
    }
}

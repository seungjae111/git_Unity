using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private StarSpawner starSpawner;

    private int score;
    private float currentTime;
    private float countdownTime = 60.0f;  // 60초 카운트다운 타이머

    public int Score
    {
        get { return score; }
        private set
        {
            score = Mathf.Max(0, value);
            Debug.Log("Score: " + score);
        }
    }

    void Start()
    {
        score = 0;
        currentTime = countdownTime;
        starSpawner.OnStarClicked += HandleStarClicked;
    }

    void Update()
    {
        // 카운트다운 업데이트
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0;
                GameOver();
            }
        }
    }

    private void HandleStarClicked()
    {
        Score += 1;
    }

    public void GameOver()
    {
        Debug.Log("Countdown ended!");

        // 스코어를 PlayerPrefs에 저장
        PlayerPrefs.SetInt("CurrentScore", score);

        // 타이머 종료 시 GameOver 씬으로 전환
        SceneManager.LoadScene("GameOver");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;  // UI 텍스트
    private int score = 0;  // 현재 점수

    void Start()
    {
        score = 0;          // 게임 시작 시 점수 초기화
        UpdateScoreText();  // UI 텍스트 업데이트
    }

    public void AddScore(int amount)
    {
        score += amount;    // 점수 처리

        // 음수 점수 방지
        //if (score < 0) score = 0;

        UpdateScoreText();  // UI 텍스트 업데이트
    }

    void UpdateScoreText()
    {
        // UI 텍스트 업데이트
        scoreText.text = "Score " + score;

        if (score >= 30)
            GameEnd();
    }

    void GameEnd()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void FindEco()
    {
        SceneManager.LoadScene("GameScene");
    }
}

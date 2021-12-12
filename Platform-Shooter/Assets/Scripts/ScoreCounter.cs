using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int currentScore;
    public Enemy enemyScore;
    public LevelController levelController;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        enemyScore = FindObjectOfType<Enemy>();
        levelController = FindObjectOfType<LevelController>();
    }

    public void Start()
    {
        currentScore = PlayerPrefs.GetInt("savedScore");
        scoreText.text = currentScore.ToString();
    }

    public void AddScore()
    {
        currentScore += enemyScore.points;
        scoreText.text = currentScore.ToString();
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("savedScore", currentScore);
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("savedScore", 0);
    }




}

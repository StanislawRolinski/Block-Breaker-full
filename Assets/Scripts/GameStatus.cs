using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gamespeed = 1f;
    [SerializeField] int gameScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 74;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoplayEnabled;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        scoreText.text = gameScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gamespeed;

    }

    public void AddToScore()
    {
        gameScore += pointsPerBlockDestroyed;
        scoreText.text = gameScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoplayEnabled()
    {
        return isAutoplayEnabled;
        
    }
}

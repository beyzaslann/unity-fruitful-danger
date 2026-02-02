using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private Dictionary<string, int> sceneScores = new Dictionary<string, int>();
    private Text scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject scoreObj = GameObject.Find("ScoreText");

        if (scoreObj != null)
        {
            scoreText = scoreObj.GetComponent<Text>();
            UpdateScoreUI();
        }
        else
        {
            if (scene.name.StartsWith("Level"))
            {
                Debug.LogWarning("ScoreText UI bulunamadý! Lütfen sahneye ScoreText ekleyin.");
            }
            scoreText = null; 
        }
    }

    public void AddScore(int amount)
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (!sceneScores.ContainsKey(sceneName))
            sceneScores[sceneName] = 0;

        sceneScores[sceneName] += amount;

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + GetTotalScore();
    }

    public int GetTotalScore()
    {
        int total = 0;
        foreach (var score in sceneScores.Values)
            total += score;

        return total;
    }

    public void ResetCurrentSceneScore()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneScores.ContainsKey(sceneName))
            sceneScores[sceneName] = 0;

        UpdateScoreUI();
    }

    public void ResetAllScores() 
    {
        sceneScores.Clear();
        UpdateScoreUI();
    }
}

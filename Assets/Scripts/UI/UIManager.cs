using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Level Label")]
    [SerializeField] private GameObject levelLabel;

    [Header ("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Win")]
    [SerializeField] private GameObject winScreen;
    [SerializeField] private AudioClip winSound;

    private void Awake()
    {
        if (winScreen != null)
            winScreen.SetActive(false);

        if (levelLabel != null)
            levelLabel.SetActive(true);

        if (gameOverScreen != null)
            gameOverScreen.SetActive(false);

        if (pauseScreen != null)
            pauseScreen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(!pauseScreen.activeInHierarchy);
        }
    }

    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

    #region Start
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    #endregion

    #region Game Over
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }
    #endregion

    #region Restart
    public void Restart()
    {
        ScoreManager.Instance.ResetCurrentSceneScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    #region MainMenu
    public void MainMenu()
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.ResetAllScores(); 

        SceneManager.LoadScene(0);
    }
    #endregion

    #region Quit
    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    #endregion

    #region Win
    public void Win()
    {
        if (winScreen == null)
            return;

        winScreen.SetActive(true);
        SoundManager.instance.PlaySound(winSound);

        SoundManager.instance.StopMusic();

        Time.timeScale = 0;

        if (levelLabel != null)
            levelLabel.SetActive(false);
    }
    #endregion
}


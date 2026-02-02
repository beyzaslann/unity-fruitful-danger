using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    public string nextLevelName;
    public bool isFinalLevel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
            {
                if (isFinalLevel)
                {
                    UIManager ui = FindObjectOfType<UIManager>();
                    if (ui != null)
                        ui.Win();
                    else
                        Debug.LogWarning("UIManager bulunamadý!");
                }
                else
                {
                    SceneManager.LoadScene(nextLevelName);
                }
            }
            else
            {
                Debug.Log("Tüm düþmanlarý öldürmeden geçemezsin!");
            }
        }
    }
}

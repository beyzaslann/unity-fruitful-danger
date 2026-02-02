using UnityEngine;


public class Collectibles : MonoBehaviour
{
    public int scoreValue = 1;
    public AudioClip collectSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = GetComponentInChildren<AudioSource>();
            if (audioSource == null)
                Debug.LogWarning("AudioSource bulunamadý! Lütfen prefab'a ekleyin.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (collectSound != null)
            {
                if (audioSource != null)
                {
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);
                    Destroy(gameObject); 
                }
                else
                {
                    AudioSource.PlayClipAtPoint(collectSound, transform.position);
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.LogWarning("CollectSound atanmamýþ!");
                Destroy(gameObject);
            }

            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(scoreValue);
            else
                Debug.LogWarning("ScoreManager.Instance bulunamadý!");
        }
    }
}

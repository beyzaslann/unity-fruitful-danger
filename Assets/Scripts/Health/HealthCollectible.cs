using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.CompareTag("Player"))
            {
                Health playerHealth = collision.GetComponent<Health>();
                if (playerHealth != null)
                    playerHealth.AddHealth(healthValue);

                if (pickupSound != null)
                    SoundManager.instance.PlaySound(pickupSound);

                Destroy(gameObject);
            }
        }
    }
}
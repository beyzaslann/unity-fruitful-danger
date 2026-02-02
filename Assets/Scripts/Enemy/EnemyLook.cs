using UnityEngine;
using System.Collections;

public class EnemyLook : MonoBehaviour
{
    public Transform player;
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float fireRate = 2f; 

    private void Start()
    {
        StartCoroutine(FireRoutine()); 
    }

    void Update()
    {
        if (player != null)
        {
            if (player.position.x < transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator FireRoutine()
    {
        while (true) 
        {
            if (player != null)
                Fire();
            yield return new WaitForSeconds(fireRate);
        }
    }

    void Fire()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Vector2 direction = (player.position - firePoint.position).normalized;
        fireball.GetComponent<Rigidbody2D>().velocity = direction * 5f;
    }
}

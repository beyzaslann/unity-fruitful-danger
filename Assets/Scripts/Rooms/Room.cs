using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    private Vector3[] initialPosition;

    private void Awake()
    {
        initialPosition = new Vector3[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] != null)
                initialPosition[i] = objects[i].transform.position;
        }

        if (transform.GetSiblingIndex() != 0)
            ActivateRoom(false);
    }

    public void ActivateRoom(bool _status)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] == null)
                continue;

            Health health = objects[i].GetComponent<Health>();
            if (health != null && health.isDead && _status)
                continue;

            objects[i].SetActive(_status);
            objects[i].transform.position = initialPosition[i];
        }
    }
}
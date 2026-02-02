using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform respawnPoint;
    public Room room;

    public void ActivateCheckpoint()
    {
        Room[] allRooms = FindObjectsOfType<Room>();
        foreach (Room r in allRooms)
        {
            bool isThisRoom = r == room;
            r.ActivateRoom(isThisRoom);
        }
    }
}

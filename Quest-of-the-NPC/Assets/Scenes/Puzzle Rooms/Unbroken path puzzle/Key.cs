using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private LockedDoorObject lockedDoorObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        lockedDoorObject.HasKey = true;
        Destroy(gameObject);
    }
}

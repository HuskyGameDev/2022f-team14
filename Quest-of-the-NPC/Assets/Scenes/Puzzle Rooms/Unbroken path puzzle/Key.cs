using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private LockedDoorObject lockedDoorObject;
    [SerializeField] private GameObject pickup_ps;

    private void OnTriggerEnter2D(Collider2D other)
    {
        lockedDoorObject.HasKey = true;
        Instantiate(pickup_ps, transform.position, quaternion.identity);
        Destroy(gameObject);
    }
}

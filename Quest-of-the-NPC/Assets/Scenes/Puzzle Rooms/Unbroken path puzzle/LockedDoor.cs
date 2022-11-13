using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private GameObject lockedDoor;
    [SerializeField] private LockedDoorObject lockedDoorObject;
    [SerializeField] private GameObject keyBlurb;

    void Start()
    {
        lockedDoor.SetActive(true);
        keyBlurb.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        lockedDoorObject.enabled = true;
        keyBlurb.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        lockedDoorObject.enabled = false;
        keyBlurb.SetActive(false);
    }
}

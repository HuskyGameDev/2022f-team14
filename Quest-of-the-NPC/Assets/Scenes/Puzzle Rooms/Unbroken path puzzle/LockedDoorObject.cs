using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LockedDoorObject : MonoBehaviour
{
    public bool HasKey = false;
    [SerializeField] private GameObject unlockDoor_ps;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HasKey)
            {
                Instantiate(unlockDoor_ps, transform.position, quaternion.identity);
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Door is locked...");
            }
        }
    }
    
}

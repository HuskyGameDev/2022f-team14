using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorObject : MonoBehaviour
{
    public bool HasKey = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HasKey)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Door is locked...");
            }
        }
    }
    
}

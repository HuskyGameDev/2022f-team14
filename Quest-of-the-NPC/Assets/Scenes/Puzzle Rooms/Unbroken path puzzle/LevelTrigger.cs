using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    [SerializeField] private int nextSceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(nextSceneBuildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject Locations;
    [SerializeField]
    private int count;
    
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        int x = Locations.transform.childCount;
        int[] numbers = new int[x];
        for(int i = 0; i < x;i++) {
            numbers[i] = i;
        }
        for(int i = 0; i< x;i++) {
            int tmp = numbers[i];
            int r = Random.Range(i, numbers.Length);
            numbers[i] = numbers[r];
            numbers[r] = tmp;
        }
        for(int i = 0; i < count; i++) {
            GameObject loc = Locations.transform.GetChild(numbers[i]).gameObject;
            GameObject newEnemy = Instantiate(enemyPrefab, loc.transform.position, Quaternion.identity);
            newEnemy.transform.parent = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

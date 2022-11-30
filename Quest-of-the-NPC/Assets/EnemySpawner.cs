using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject Locations;
    [SerializeField]
    private int count;
    [SerializeField]
    private SceneChange SC;
    
    private int rand;

    // Start is called before the first frame update
    void Start()
    {
        //Shuffle list of locations
        int x = Locations.transform.childCount;
        int[] numbers = new int[x];
        for(int i = 0; i < x ;i++) {
            numbers[i] = i;
        }
        for(int i = 0; i< x ;i++) {
            int tmp = numbers[i];
            int r = Random.Range(i, numbers.Length);
            numbers[i] = numbers[r];
            numbers[r] = tmp;
        }
        //we take the first x many locations from shuffled list, where x is how many enemies we want to spawn
        for(int i = 0; i < count; i++) {
            GameObject loc = Locations.transform.GetChild(numbers[i]).gameObject;
            GameObject newEnemy = Instantiate(enemyPrefab, loc.transform.position, Quaternion.identity);
            newEnemy.transform.parent = this.transform;
            newEnemy.GetComponent<enHealth>().SC = SC; //this is so Scene Change can track enemies killed
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

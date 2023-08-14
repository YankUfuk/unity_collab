using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject ratPrefab;

    [SerializeField] private float swarmerInterval = 3.5f;

    [SerializeField] private float bigSwarmerInterval =10f; 

    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, ratPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, ratPrefab));
    }



private IEnumerator spawnEnemy(float interval, GameObject enemy)
{
    yield return new WaitForSeconds(interval);
    GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5f), Random.Range(-6f, 6f),0), Quaternion.identity);
    StartCoroutine(spawnEnemy(interval, enemy));
}


}

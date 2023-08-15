using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyReference;
    private GameObject spawnedEnemy;
    [SerializeField] private Transform spawnPos;
    private int index = 0;

     

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        
    }



IEnumerator SpawnEnemy()
{
    while(true)
    {
        yield return new WaitForSeconds(Random.Range(1,2));
        spawnedEnemy = Instantiate(enemyReference[index]);
        spawnedEnemy.transform.position = spawnPos.position;
        spawnedEnemy.GetComponent<EnemyWalking>().enemySpeed = -Random.Range(4,10);
        yield return new WaitForSeconds(5);
        Destroy(GameObject.FindWithTag("Enemy"));

    }
    
}


}

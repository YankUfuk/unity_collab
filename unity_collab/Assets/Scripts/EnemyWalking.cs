using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyWalking : MonoBehaviour
{
    public float enemySpeed = 3.0f;
    private Rigidbody2D myBody;
    
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(enemySpeed, 0);
    }

public int sceneBuildIndex;
    //public ItemCollector itemCollector;
    

    

    //[SerializeField] private AudioSource winSoundEffect;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            //winSoundEffect.Play();
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
    
}

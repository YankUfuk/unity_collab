using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;
    public ItemCollector itemCollector;
    

    

    [SerializeField] private AudioSource winSoundEffect;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            winSoundEffect.Play();
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;

    [SerializeField] private AudioSource winSoundEffect;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        print("Trigger Entered");

        if(other.tag == "Player")
        {
            winSoundEffect.Play();
            print("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}

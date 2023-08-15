using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public int collectible = 0;
    public Text collectibleText;
    public GameObject door;

    [SerializeField] private AudioSource collectionSoundEffect;

    
        void OnTriggerEnter2D(Collider2D collision)
        {
        if(collision.gameObject.CompareTag("Collectible"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            collectible++;
            collectibleText.text = "Food: " + collectible;

            if(collectible >= 10)
            {
                
                Destroy(GameObject.FindWithTag("Door"));
            }
            
        }
        }
    
    

    
}
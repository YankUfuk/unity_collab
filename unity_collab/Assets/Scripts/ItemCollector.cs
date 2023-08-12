using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int collectible = 0;
    public Text collectibleText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectible"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            collectible++;
            collectibleText.text = "Food: " + collectible;

        }
    }
}

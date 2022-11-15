using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{

    private int bananas = 0;

    [SerializeField] private Text bananasText;

    [SerializeField] private AudioSource collectionSound;

    public static int lives = 3;

    [SerializeField] private Text livesText;


    private void Start()
    {
        livesText.text = "Lives: " + lives;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            collectionSound.Play();
            Destroy(collision.gameObject);
            bananas++;
            bananasText.text = "Bananas: " + bananas;
        }
        
        if (collision.gameObject.CompareTag("Life"))
        {
            collectionSound.Play();
            Destroy(collision.gameObject);
            lives++;
            livesText.text = "Lives: " + lives;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    private Animator anim;

    private int bananas = 0;

    [SerializeField] private Text bananasText;

    [SerializeField] private AudioSource collectionSound;

    public static int lives = 1;

    [SerializeField] private Text livesText;


    private void Start()
    {
        livesText.text = "Lives: " + lives;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim = collision.GetComponent<Animator>();
        if (collision.gameObject.CompareTag("Banana"))
        {
            collectionSound.Play();
            anim.SetBool("pickedUp", true);
            Destroy(collision.gameObject);
            bananas++;
            bananasText.text = "Bananas: " + bananas;

            if(bananas == 10)
            {
                bananas = 0;
                lives++;
                livesText.text = "Lives: " + lives;
            }
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

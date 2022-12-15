using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator deathAnim;

    [SerializeField] private AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deathAnim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Die();
        }
    }

    private void Die()
    {
        
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        deathAnim.SetTrigger("Death");
        deathSound.Play();
    }

    private void RestartLevel()
    {
        PickUp.lives--;
        if (PickUp.lives >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (PickUp.lives < 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}

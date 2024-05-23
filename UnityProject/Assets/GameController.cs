using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 startPos;
    SpriteRenderer spriteRenderer;
    AudioManager audioManager;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            audioManager.PlaySFX(audioManager.death);
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(Respawn(0.5f));  
    }

    IEnumerator Respawn(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);  
        transform.position = startPos;  
        spriteRenderer.enabled = true;  
    }
}

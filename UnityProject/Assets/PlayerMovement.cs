using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    public Animator animator;
    public string[] scenes;
    public int requiredCoins = 10;

    public GameObject congratulationPanel;
    public GameObject tryAgainPanel;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private Vector2 movement;
    private bool isGrounded = false;
    private bool facingRight = true;
    private int jumpsRemaining;
    private int currentSceneIndex;
    AudioManager audioManager;

  
       void Awake() { 
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>(); }
      
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = rb.position;
        jumpsRemaining = maxJumps;
        currentSceneIndex = Array.IndexOf(scenes, SceneManager.GetActiveScene().name);

        
        // Debug the current scene index and scenes array
        Debug.Log("Current Scene: " + SceneManager.GetActiveScene().name);
        Debug.Log("Current Scene Index: " + currentSceneIndex);
        for (int i = 0; i < scenes.Length; i++)
        {
            Debug.Log("Scene " + i + ": " + scenes[i]);
        }

        congratulationPanel.SetActive(false);
        tryAgainPanel.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            HandleInput();
            HandleJump();
            FlipCharacter();
        }
    }

    void FixedUpdate()
    {
        if (Time.timeScale > 0)
        {
            MovePlayer();
            UpdateAnimatorParameters();
        }
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpsRemaining > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
    }

    private void FlipCharacter()
    {
        if ((movement.x > 0 && !facingRight) || (movement.x < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void UpdateAnimatorParameters()
    {
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", Math.Abs(rb.velocity.y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            isGrounded = true;
            jumpsRemaining = maxJumps;
            animator.SetBool("isJumping", false);
        }
        else if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            CoinCounter.instance.IncreaseCoins(1);
        }
        else if (other.CompareTag("Spike"))
        {
           
            ResetPlayerPosition(); 
            audioManager.PlaySFX(audioManager.death);
        }
        else if (other.CompareTag("Door"))
        {
            if (CoinCounter.instance.currentCoins >= requiredCoins)
            {
                
                ShowPanel(congratulationPanel);
                audioManager.PlaySFX(audioManager.energie);
            }
            else
            {
               
                ShowPanel(tryAgainPanel);
                audioManager.PlaySFX(audioManager.death);
            }
        }
        else if (other.CompareTag("StandingTable")) // Adjust this tag as per your actual table prefab tag
        {
            // Example: if landing on a table should reset jumping animation
            animator.SetBool("isJumping", false); // Reset jumping animation when landing on a table
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            jumpsRemaining = maxJumps;
            animator.SetBool("isJumping", false);
        }
    }

    private void ResetPlayerPosition()
    {
        rb.position = startPosition;
        transform.position = startPosition;
        jumpsRemaining = maxJumps;
        animator.SetBool("isJumping", false);
    }

   
   
    private void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
        // Remove all previous listeners to avoid duplication
        panel.GetComponent<Button>().onClick.RemoveAllListeners();
        // Add a new listener
        panel.GetComponent<Button>().onClick.AddListener(() => OnPanelClicked(panel));
        Time.timeScale = 0; // Pause the game
    }

    private void OnPanelClicked(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1; // Resume the game

        if (panel == congratulationPanel)
        {
            SceneController.LoadScene("Klausurphase"); 
        }
        else if (panel == tryAgainPanel)
        {
            SceneController.LoadScene("LucaNewScene");
        }
    }
}

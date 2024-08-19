using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 2;
    public Animator animator;
    public int requiredCoins = 10;

    public GameObject congratulationPanel;
    public GameObject tryAgainPanel;

    private Rigidbody2D rb;
    private Vector2 startPosition;
    private Vector2 movement;
    private bool isGrounded = false;
    private bool facingRight = true;
    private int jumpsRemaining;
    public string levelSceneName;
    public string backscene;
    private AudioManager audioManager;

    // New variables for ground detection
    public Transform groundCheck; // Assign this in the Unity Inspector
    public float groundCheckRadius = 0.2f; // Radius of the overlap circle
    public LayerMask groundLayer; // Assign this in the Unity Inspector

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        startPosition = rb.position;
        jumpsRemaining = maxJumps;

        congratulationPanel.SetActive(false);
        tryAgainPanel.SetActive(false);
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            HandleInput();
            CheckGrounded(); // Updated ground check
            HandleJump();
            FlipCharacter();
            MovePlayer();
            UpdateAnimatorParameters();
        }

        if (Input.GetMouseButtonDown(0))
        {
            DismissPanelOnClick();
        }
    }

    private void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpsRemaining--;
            isGrounded = false; // Prevent additional jumps until grounded again
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
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    // Step 2: Implement the ground detection
    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
        {
            jumpsRemaining = maxJumps;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stift"))
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stift"))
        {
            transform.parent = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Enter: " + other.tag);

        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            CoinCounter.instance.IncreaseCoins(1);
        }
        else if (other.CompareTag("Spike"))
        {

            Debug.Log("Trigger Enter: " + other.tag);
            Debug.Log("Hit a spike!");
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
                ResetPlayerPosition();
                audioManager.PlaySFX(audioManager.death);
            }
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
        panel.GetComponent<Button>().onClick.RemoveAllListeners();
        panel.GetComponent<Button>().onClick.AddListener(() => OnPanelClicked(panel));
        Time.timeScale = 0;
    }

    private void OnPanelClicked(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;

        if (panel == congratulationPanel)
        {
            SceneManager.LoadScene(levelSceneName);
        }
        else if (panel == tryAgainPanel)
        {
            SceneManager.LoadScene(backscene);
        }
    }

    private void DismissPanelOnClick()
    {
        if (congratulationPanel.activeSelf)
        {
            SceneManager.LoadScene(levelSceneName);
        }
        else if (tryAgainPanel.activeSelf)
        {
            SceneManager.LoadScene(backscene);
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}

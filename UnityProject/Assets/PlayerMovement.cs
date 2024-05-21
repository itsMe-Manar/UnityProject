using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    private float Move;
    public Rigidbody2D rb;
    public bool isJumping;
    private Animator animator;
    private bool doublejump;
    private int remainingjumps;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * Move, rb.velocity.y);

        if (isJumping == false && !Input.GetButtonDown("Jump"))
        {
            doublejump = false;
        }

        if (Input.GetButtonDown("Jump") && (isJumping == false || doublejump))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            doublejump = !doublejump;
        }
        if (Move > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (Move < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor")){
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor")){
            isJumping = true;
        }
    }
}

using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;

    public void UpdateMovement(float horizontalInput, bool isGrounded)
    {
        animator.SetFloat("xVelocity", Mathf.Abs(horizontalInput));
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Check if the player is not moving and stop animation
        if (isGrounded)
        {
            animator.SetBool("isJumping", Mathf.Abs(horizontalInput) > 0);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }

    public void TriggerJump()
    {
        // Play jump animation or set animator parameters
        animator.SetTrigger("Jump");
    }

    public void Flip(bool facingRight)
    {
        // Handle flip animation if necessary
    }
}

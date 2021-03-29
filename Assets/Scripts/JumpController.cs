using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Характеристики прыжка")]
    [SerializeField]
    private float jumpForce = 200f;
    [Range(0.002f, 1f)]
    [SerializeField]
    private float activeJumpTime = 0.15f;

    [Header("Имя параметра прыжка в аниматоре")]
    [SerializeField]
    private string groundParameterName = "isGrounded";

    private CapsuleCollider2D cc2d;
    private Rigidbody2D rb2d;
    private Animator animator;

    private bool onGround = false;

    private void Awake()
    {
        cc2d = GetComponent<CapsuleCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate ()
    {
        CheckIsGrounded();
        
        if (animator != null)
            animator.SetBool(groundParameterName, onGround);

        bool canJump = Input.GetKey(KeyCode.Space) && onGround && rb2d != null;

        if (canJump)
        {
            StopAllCoroutines();
            StartCoroutine(JumpCoroutine());
        }
    }

    private void CheckIsGrounded()
    {
        cc2d.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down * (cc2d.size.y / 2 - 0.1f), Vector3.down, cc2d.size.x / 4);
        cc2d.enabled = true;

        onGround = hit.collider && !hit.collider.isTrigger;
    }

    private IEnumerator JumpCoroutine()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        
        float currentJumpTime = 0f;
        while (Input.GetKey(KeyCode.Space) && currentJumpTime < activeJumpTime)
        {
            float timeMultiplier = 1f - currentJumpTime / activeJumpTime;
            rb2d.AddForce(Vector2.up * jumpForce * timeMultiplier * Time.fixedDeltaTime, ForceMode2D.Impulse);
            currentJumpTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}

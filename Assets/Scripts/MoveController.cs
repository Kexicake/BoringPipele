using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
    [Header("Скорость передвижения")]
    public float speed = 7f;

    [Header("Имя параметра передвижения в аниматоре")]
    public string walkParameterName = "isWalk";

    [Header("Первое положение")]
    public float firstPlat = -0.588f;

    [Header("Второе положение")]
    public float secondPlat = 1.48f;

    [Header("Третье положение")]
    public float therdPlat = 3.45f;


    [Header("Шакал ебучий")]
    public float dPlat = 0f;

    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D cc2d;
    private Rigidbody2D rb2d;
    private Animator animator;

    private bool isCanMove = true;
    private bool isFirst = true;
    private bool isSecond = false;
    private bool isTherd = false;
    private bool isStay = true;
    private bool isTurnRight = true;

    private void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate()
    {
CheckIsCanMove();
    
        float movement = Input.GetAxis("Vertical");

        isStay = Mathf. Abs(movement) <= 0.15f;

        if (movement > 0)
            isTurnRight = true;
        else if (movement < 0)
            isTurnRight = true;

        spriteRenderer.flipX = !isTurnRight;

        if (animator != null)
            animator.SetBool(walkParameterName, !isStay);

        if (rb2d != null)
        {
            if (isFirst)
            {
                if (this.gameObject.transform.position.y >= secondPlat)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    print(this.gameObject.transform.position.y);

                    if (this.gameObject.transform.position.y >= secondPlat)
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
                    }
                    else
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x, 1 * speed);
                    }   
                }
                if (this.gameObject.transform.position.y >= secondPlat)
                {
                    isFirst = false;
                    isSecond = true;
                }
                
            }else if (isSecond)
            {
                if (this.gameObject.transform.position.y >= therdPlat)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    print(this.gameObject.transform.position.y);

                    if (this.gameObject.transform.position.y >= therdPlat)
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
                    }
                    else
                    {
                        rb2d.velocity = new Vector2(rb2d.velocity.x, 1 * speed);
                    }
                }
                if (this.gameObject.transform.position.y >= therdPlat)
                {
                    isSecond = false;
                    isTherd = true;
                }
                
            }
        }  
    }

    private void CheckIsCanMove()
    {
        cc2d.enabled = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, isTurnRight ? Vector3.down : Vector3.up, cc2d.size.y + 0.1f);
        cc2d.enabled = true;

        isCanMove = !hit.collider || hit.collider.isTrigger;
    }
}

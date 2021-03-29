using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour{
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
    private float newPoz;
    private bool up = false;
    private bool down = false;

    private void Awake (){
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate(){
        

    
        if (animator != null)
            animator.SetBool(walkParameterName, !isStay);
        if (up)
            Movemente();

        if (this.gameObject.transform.position.y >= secondPlat){
            isFirst = false;
            isSecond = true;
        }
        if (this.gameObject.transform.position.y >= therdPlat){
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
        }
        if (this.gameObject.transform.position.y >= therdPlat){
            isSecond = false;
            isTherd = true;
        }
    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.W))
            up = true;
        if (Input.GetKeyDown(KeyCode.S))
            down = true;
        check();
    }
    private void check()
    {
        if (isFirst)
            down = false;
        if (isTherd)
            up = false;
    }
    private void Movemente(){
       
        if (isFirst){
            newPoz = secondPlat;
        }
        if (isSecond){
            newPoz = therdPlat;
        }
        if (isTherd){
            newPoz = secondPlat;
        }

        if (this.gameObject.transform.position.y >= newPoz){
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
            up = false;
        }
        else{
            rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
        } 
    }
}

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


    private Rigidbody2D rb2d;
    private Animator animator;

    private bool isFirst = true;
    private bool isSecond = false;  
    private float newPoz;
    private bool tap = false;

    private void Awake (){
    rb2d = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();  
    }
    
    private void FixedUpdate(){

        
        if (tap)
            Movemente();

        if (gameObject.transform.position.y >= secondPlat){
            isFirst = false;
            isSecond = true;
        }
        if (gameObject.transform.position.y <= firstPlat+0.2)
        {
            isFirst = true;
            isSecond = false;
        }

    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
            tap = true;
    }

    private void Movemente()
    {

        if (isFirst)
        {
            newPoz = secondPlat;
            if (gameObject.transform.position.y >= newPoz)
            {
                animator.Play("run");
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
                tap = false;
            }
            else
            {
                animator.Play("jump");
                rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
            }
        }
        if (isSecond)
        {
            newPoz = firstPlat;
            if (gameObject.transform.position.y <= newPoz+0.2)
            {
                animator.Play("run");
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0f);
                tap = false;
            }
            else
            {
                animator.Play("jump");
                rb2d.velocity = new Vector2(rb2d.velocity.x, -1 * speed);
            }
        }
    }
}

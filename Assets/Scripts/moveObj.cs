using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObj : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 3f;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb2d.velocity = new Vector2(-1*Speed, rb2d.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < -4)
            Destroy(gameObject);
    }
}

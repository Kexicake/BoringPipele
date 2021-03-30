using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flore : MonoBehaviour
{
    public float Speed = 5f;
    private Rigidbody2D rb2d;


    public GameObject spawnObject;


    public object Ve { get; private set; }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d.velocity = new Vector2(-1*Speed, rb2d.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {;
        if (this.gameObject.transform.position.x <= -9f)
        {

            GameObject newObj = Instantiate(gameObject, new Vector3(8.87f, -1.11f, 0f), Quaternion.identity);
            newObj.name = "1";
            Destroy(gameObject);
        }
            
    }
}

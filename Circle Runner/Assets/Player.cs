using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    Rigidbody2D rb;
    float angle = 0;


    [SerializeField]int xSpeed = 5;
    [SerializeField] int ySpeed = 100;

    GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        GetInput();
    }

    void MovePlayer() 
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 3;
       // pos.y = 0;
        transform.position = pos;
        angle+= Time.deltaTime* xSpeed;
    }

    void GetInput() 
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(new Vector2(0, ySpeed));
        }
        else 
        {
            if (rb.velocity.y > 0)
            {
                rb.AddForce(new Vector2(0, -ySpeed));
            }
            else 
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.GameOver();
    }
}

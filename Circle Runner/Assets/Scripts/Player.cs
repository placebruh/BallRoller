using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    public GameObject deadEffectObj;
    public GameObject itemEffectObj;

    Rigidbody2D rb;
    float angle = 0;

    bool isDead = false;


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
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == true) return;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Dead();
        }
        else if (other.gameObject.tag == "Item") 
        {
            GetItem(other);
            Debug.Log("Score +1");
         
        }

       
    }

    void GetItem(Collider2D other) 
    {
       Destroy(Instantiate(itemEffectObj, other.gameObject.transform.position, Quaternion.identity),0.5f);
        Destroy(other.gameObject.transform.parent.gameObject);
        gameManager.AddScore();
    }

     void Dead()
    {
        isDead = true;
        Destroy(Instantiate(deadEffectObj, transform.position, Quaternion.identity),0.5f);

        StopPlayer();

        gameManager.CallGameOver();
    }

    void StopPlayer() 
    {
        rb.velocity = new Vector2(0, 0);
        rb.isKinematic = true;
    }
}

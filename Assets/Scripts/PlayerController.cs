using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    //  SpriteRenderer sr;
    public float offsetForMove;
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;

    // Start is called before the first frame update
    void Start()
    {

        rb2D = gameObject.GetComponent<Rigidbody2D>();
      //  sr = GetComponent<SpriteRenderer>();
        moveSpeed = 0.3f;
        jumpForce = 6f;
        isJumping = false;

    }

    // Update is called once per frame
    void Update()
    {
       
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        //GetComponent<SpriteRenderer>().flipX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x;
   

    }

    void FixedUpdate()
    {
        MouseFlip();

        if (moveHorizontal> 0.1f || moveHorizontal< - 0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f),ForceMode2D.Impulse);
        }

        if (!isJumping && moveVertical > 0.1f )
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }


    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Platform" )
        {
            isJumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
    private void MouseFlip()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if (pos.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (pos.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}

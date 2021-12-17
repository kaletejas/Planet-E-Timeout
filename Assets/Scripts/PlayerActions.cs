using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float speed = 200f;
    public float jumpSpeed = 150f;
    private float direction = 0f;
    private Rigidbody2D player;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      isTouchingGround = Physics2D.OverlapCircle(groundCheck.position , groundCheckRadius , groundLayer);
       direction = Input.GetAxis("Horizontal");
       
       if(direction > 0f) {
           player.velocity = new Vector2(direction * speed, player.velocity.y);

       }
       else if(direction < 0f) {
           player.velocity = new Vector2(direction * speed, player.velocity.y);

       }
       else {
            player.velocity = new Vector2( 0, player.velocity.y);

       }

       if(Input.GetButtonDown("Jump") && isTouchingGround ) {
           player.velocity = new Vector2(player.velocity.x, jumpSpeed);
       }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    private Rigidbody2D rb;
    private const int maxJumps = 2;
    [SerializeField] private int jumps;
    private const float jumpVelocity = 5;
    private const float dashForce = 2000;
    private float horizontalInput;
    private bool hasDashed;
    private bool isGrounded = true;
    private float dashTime;
    private const float dashResetTime = 0.5f;
    private float startDashTime;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        jumps = maxJumps;
    }

    //Ran once per frame
    //TODO Implement dashing
    private void Update() 
{

    //Resets jump and dash if they're on the ground
    if(isGrounded)
    {
        jumps = maxJumps;
            if (Time.time - startDashTime >= dashResetTime && hasDashed)
            {
                Debug.Log("DASH RESET");
                hasDashed = false;
            }
        }
 
        //Left right movement
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //Changes players direction based on horizontal movement
    if(horizontalInput >= 0.01f)
    {
        transform.localScale = Vector3.one;
    } else if(horizontalInput <= -0.01f) 
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }



     
        //For dashing
        if (Input.GetKeyDown(KeyCode.LeftShift) && jumps > 0 && jumps <= maxJumps && !hasDashed)
        {
            startDashTime = Time.time;
            Dash();
        }

        //For jumping
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0 && jumps <= maxJumps)
        {
            Jump();
        }
    }


 

    //Checks if the player is grounded
private void OnCollisionEnter2D(Collision2D collision)
    {
    
    if(collision.gameObject.tag == "Ground")
    {
        Debug.Log("OnCollisionEnter2D");
        isGrounded = true;
    }
    }

    //Checks if the player is not grounded
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
        Debug.Log("OnCollisionExit2D");
        isGrounded = false;
        }
    }

private void Jump() 
    {
        Debug.Log("Jump!");
        if(jumps > 0)
        {
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        jumps--;
        isGrounded = false;
        }
    }

private void Dash() 
    {
            Debug.Log("Dash!");
            if(isLookingLeft())
            {
            rb.AddForce(Vector2.left * dashForce, ForceMode2D.Force);
            }
            if(isLookingRight())
            {
            rb.AddForce(Vector2.right * dashForce, ForceMode2D.Force);
        }
        hasDashed = true;
        jumps--;

    }

    private bool isLookingLeft()
    {
    if(transform.localScale.x <= -1)
    {
        return true;
    } 
    return false;

    }

    private bool isLookingRight()
    {
    if(transform.localScale.x >= 1)
    {
        return true;
    } 
    return false;
    
    }
}
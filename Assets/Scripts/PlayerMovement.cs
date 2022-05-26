using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private const int maxJumps = 2;
    [SerializeField] private int jumps;
    [SerializeField] private float jumpVelocity = 5;
   [SerializeField] private float dashForce = 5;
    public bool hasDashed;
    private bool isGrounded = true;
    private const float dashResetTime = 0.5f;
    private float startDashTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        jumps = maxJumps;
        rb.freezeRotation = true;
    }

    //Ran once per frame
    //TODO Implement dashing
    private void Update() 
    {

      //Resets dash
      if (isGrounded && Time.time - startDashTime >= dashResetTime && hasDashed)
            {
                Debug.Log("DASH RESET");
                hasDashed = false;
            }
        
      //Resets jumps
      if(isGrounded && jumps != maxJumps)
        {
            jumps = maxJumps;
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
        isGrounded = false;
        jumps--;
        Debug.Log("Jump!");
        rb.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);
        
    }

private void Dash() 
    {
        hasDashed = true;
        jumps--;
        Debug.Log("Dash!");
            if(isLookingLeft())
            {
            rb.AddForce(Vector2.left * dashForce, ForceMode2D.Impulse);
            }
            if(isLookingRight())
            {
            rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
            }

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
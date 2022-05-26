using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;
    [SerializeField] public float moveSpeed = 3;
    private PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal movement
        if (!pm.hasDashed)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }
  
        //Changes player sprite direction based on horizontal movement
        if (horizontalInput >= 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput <= -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}

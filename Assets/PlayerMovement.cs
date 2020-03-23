using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpSpeed;
    public float moveSpeed;
    public bool grounded = false;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    Animator anim;
    Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.D))    // Derecha
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A)){  // Izquierda 

            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
        if  (Input.GetKeyDown(KeyCode.W) && grounded )  //Salto
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jumpTimeCounter = jumpTime;
        }
        if (Input.GetKey(KeyCode.W) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("Grounded", grounded);


    }
}

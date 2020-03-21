using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpSpeed;
    public float moveSpeed;
    public bool moving = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }else if (Input.GetKey(KeyCode.A)){

            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }else if  (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpSpeed);
        }
    }
}

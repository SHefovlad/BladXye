using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class PlayerController : MonoBehaviour
{
    Collider2D collider;
    Rigidbody2D rigidbody;
    public bool canJump;
    float jumpForce;
    public float jumpSpeed;
    public float jumpMinusSpeed;
    [SerializeField] float moveSpeed;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        jumpForce = 1;
    }

    void Update()
    {
        if (Input.GetAxis("Jump") != 0)
        {
            if (canJump)
            {
                //jumpForce = jumpSpeed;
                //canJump = false;
                StartCoroutine(Jump());
                //rigidbody.AddForce(new Vector2(jumpSpeed, 0));
            }
        }
        //-------------------------//
        rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * moveSpeed * jumpForce, Input.GetAxis("Vertical") * moveSpeed * jumpForce));
        //-------------------------//
    }

    IEnumerator Jump()
    {
        canJump = false;
        int c = 0;
        jumpForce = jumpSpeed;
        while (c / 60 < 3)
        {
            c++;
            jumpForce -= jumpMinusSpeed;
            if (jumpForce <= 1) { jumpForce = 1; }
            yield return new WaitForSeconds(1 / 60);
        }
        jumpForce = 1;
        canJump = true;
    }
}

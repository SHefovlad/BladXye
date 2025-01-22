using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] new Collider2D collider;
    [SerializeField] new Rigidbody2D rigidbody;

    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 200f;
    public float dashingTime = 0.1f;
    public float dashingCooldown = 0.35f;


    public float moveSpeed;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        //-------------------------//
        rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed));
        //-------------------------//

        if (Input.GetButton("Jump") && canDash)
        {
            StartCoroutine(Dash());
        }

    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rigidbody.AddForce(new Vector2(Input.GetAxis("Horizontal") * moveSpeed * dashingPower, Input.GetAxis("Vertical") * moveSpeed * dashingPower));

        yield return new WaitForSeconds(dashingTime);

        isDashing = false;

        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

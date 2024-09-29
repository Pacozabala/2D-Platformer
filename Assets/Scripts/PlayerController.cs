using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D footCollider, bodyCollider, headCollider;
    public bool grounded;
    public float xSpeed, ySpeed, xInput, yInput, groundFriction, gravity;
    public LayerMask solidObjects;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xSpeed = 5f;
        ySpeed = 25f;
        groundFriction = 0.9f;
        gravity = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputs();
        MovePlayer();
    }

    private void FixedUpdate() {
        CheckCollisions();
        ApplyDeceleration();
    }

    private void GetInputs() {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    private void MovePlayer() {
        if (Mathf.Abs(xInput) > 0) {
            rb.velocity = new Vector2(xInput * xSpeed, rb.velocity.y);
        }
        if (Mathf.Abs(yInput) > 0 && grounded) {
            rb.velocity = new Vector2(rb.velocity.x, ySpeed);
        }
    }

    private void CheckCollisions() {
        bool groundCollided = Physics2D.BoxCast(footCollider.bounds.center, footCollider.size, 0, Vector2.down, 0.05f);
        bool ceilingCollided = Physics2D.BoxCast(headCollider.bounds.center, headCollider.size, 0, Vector2.up, 0.05f, solidObjects);

        if (ceilingCollided) {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }

        if (!grounded && groundCollided) {
            grounded = true;
        }
        else if (grounded && !groundCollided) {
            grounded = false;
        }
    }

    private void ApplyDeceleration() {
        if (grounded && xInput == 0) {
            rb.velocity = new Vector2(rb.velocity.x * groundFriction, rb.velocity.y);
        }
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - gravity);
    }
}

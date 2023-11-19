using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRightMovement : BulletBaseScript
{
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Movement();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = velocityVector.normalized * magnitude;
    }

    public override void Movement()
    {
        velocityVector = new Vector2(moveSpeed * Time.deltaTime, 0);
    }
}

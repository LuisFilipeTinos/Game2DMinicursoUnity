using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLeftMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float magnitude;

    private Vector2 velocityVector;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocityVector = new Vector2(-moveSpeed * Time.deltaTime, 0);

    }

    private void FixedUpdate()
    {
        rb2d.velocity = velocityVector.normalized * magnitude;
    }
}

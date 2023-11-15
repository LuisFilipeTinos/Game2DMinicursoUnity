using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    Rigidbody2D rb2d;

    private float horizontalMovement;
    private float verticalMovement;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float magnitude;

    PlayerMovement playerMovement;

    private Vector2 velocityVector;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (verticalMovement != 0 || horizontalMovement != 0)
            velocityVector = new Vector2(horizontalMovement * moveSpeed * Time.deltaTime, verticalMovement * moveSpeed * Time.deltaTime);
        else if (playerMovement.isStandingUp)
            velocityVector = new Vector2(0, moveSpeed * Time.deltaTime);
        else if (playerMovement.isStandingDown)
            velocityVector = new Vector2(0, -moveSpeed * Time.deltaTime);
        else if (playerMovement.isStandingLeft)
            velocityVector = new Vector2(-moveSpeed * Time.deltaTime, 0);
        else if (playerMovement.isStandingRight)
            velocityVector = new Vector2(moveSpeed * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = velocityVector.normalized * magnitude;
    }
}

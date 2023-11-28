using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : BulletBaseScript
{
    Rigidbody2D rb2d;
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        Movement();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = velocityVector.normalized * magnitude;
    }

    public override void Movement()
    {
        if (verticalMovement != 0 || horizontalMovement != 0)
        {
            velocityVector = new Vector2(horizontalMovement * moveSpeed * Time.deltaTime, verticalMovement * moveSpeed * Time.deltaTime);
            var direction = velocityVector.normalized;
            float directionInDegrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            this.transform.eulerAngles = new Vector3(0, 0, this.transform.eulerAngles.z + directionInDegrees);
        }
        else if (playerMovement.isStandingUp)
        {
            velocityVector = new Vector2(0, moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (playerMovement.isStandingDown)
        {
            velocityVector = new Vector2(0, -moveSpeed * Time.deltaTime);
            this.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (playerMovement.isStandingLeft)
        {
            velocityVector = new Vector2(-moveSpeed * Time.deltaTime, 0);
            this.transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (playerMovement.isStandingRight)
        {
            velocityVector = new Vector2(moveSpeed * Time.deltaTime, 0);
            this.transform.eulerAngles = new Vector3(0, 0, -90);
        }
            
    }
}

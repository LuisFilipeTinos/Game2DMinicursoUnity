using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private bool isWalkingUp;
    private bool isWalkingLeft;
    private bool isWalkingRight;
    private bool isWalkingDown;

    Animator anim;

    private float horizontalMovement;
    private float verticalMovement;

    private Vector2 horizontalVelocity;
    private Vector2 verticalVelocity;

    [SerializeField] private float moveSpeed;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("PlayerIdleDown");
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        verticalVelocity = new Vector2(0, (verticalMovement * moveSpeed) * Time.deltaTime);
        horizontalVelocity = new Vector2((horizontalMovement * moveSpeed) * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.UpArrow) || (horizontalMovement == 0 && verticalMovement > 0))
        {
            SetUpTrue();
            anim.Play("PlayerWalkingBack");
        }
        else if (horizontalMovement == 0 && verticalMovement == 0 && isWalkingUp && !Input.GetKey(KeyCode.UpArrow))
        {
            ResetVariables();
            anim.Play("PlayerIdleBack");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || (horizontalMovement < 0 && verticalMovement == 0))
        {
            SetLeftTrue();
            this.transform.localScale = new Vector3(-1, this.transform.localScale.z, this.transform.localScale.z);
            anim.Play("PlayerWalkingSide");
        }
        else if (horizontalMovement == 0 && verticalMovement == 0 && isWalkingLeft && !Input.GetKey(KeyCode.LeftArrow))
        {
            ResetVariables();
            anim.Play("PlayerIdleSide");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || (horizontalMovement > 0 && verticalMovement == 0))
        {
            SetRightTrue();
            this.transform.localScale = new Vector3(1, this.transform.localScale.z, this.transform.localScale.z);
            anim.Play("PlayerWalkingSide");
        }
        else if (horizontalMovement == 0 && verticalMovement == 0 && isWalkingRight && !Input.GetKey(KeyCode.RightArrow))
        {
            ResetVariables();
            anim.Play("PlayerIdleSide");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || (horizontalMovement == 0 && verticalMovement < 0))
        {
            SetDownTrue();
            anim.Play("PlayerWalkingFront");
        }
        else if (horizontalMovement == 0 && verticalMovement == 0 && isWalkingDown && !Input.GetKey(KeyCode.DownArrow))
        {
            ResetVariables();
            anim.Play("PlayerIdleFront");
        }
    }

    //Usado para o movimento e para as físicas do jogo
    void FixedUpdate()
    {
        if (verticalMovement != 0 || horizontalMovement != 0)
            rb2d.velocity = new Vector2(horizontalMovement * moveSpeed * Time.deltaTime, verticalMovement * moveSpeed * Time.deltaTime);
        else
            rb2d.velocity = Vector2.zero;
    }

    private void ResetVariables()
    {
        isWalkingUp = false;
        isWalkingLeft = false;
        isWalkingRight = false;
        isWalkingDown = false;
    }

    private void SetUpTrue()
    {
        isWalkingUp = true;
        isWalkingLeft = false;
        isWalkingRight = false;
        isWalkingDown = false;
    }

    private void SetLeftTrue()
    {
        isWalkingUp = false;
        isWalkingLeft = true;
        isWalkingRight = false;
        isWalkingDown = false;
    }

    private void SetRightTrue()
    {
        isWalkingUp = false;
        isWalkingLeft = false;
        isWalkingRight = true;
        isWalkingDown = false;
    }

    private void SetDownTrue()
    {
        isWalkingUp = false;
        isWalkingLeft = false;
        isWalkingRight = false;
        isWalkingDown = true;
    }
}

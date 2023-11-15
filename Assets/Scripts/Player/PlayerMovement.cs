using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private bool isWalkingUp;
    private bool isWalkingLeft;
    private bool isWalkingRight;
    private bool isWalkingDown;

    public bool isStandingUp;
    public bool isStandingLeft;
    public bool isStandingRight;
    public bool isStandingDown;

    Animator anim;

    private float horizontalMovement;
    private float verticalMovement;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float magnitude;

    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("PlayerIdleBack");
        SetStandingUpTrue();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMovement = Input.GetAxisRaw("Vertical");
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow) || (horizontalMovement == 0 && verticalMovement > 0))
        {
            SetUpTrue();
            anim.Play("PlayerWalkingBack");
        }
        else if (horizontalMovement == 0 && verticalMovement == 0 && isWalkingUp && !Input.GetKey(KeyCode.UpArrow))
        {
            ResetWalkVariables();
            SetStandingUpTrue();
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
            ResetWalkVariables();
            SetStandingLeftTrue();
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
            ResetWalkVariables();
            SetStandingRightTrue();
            anim.Play("PlayerIdleSide");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || (horizontalMovement == 0 && verticalMovement < 0))
        {
            SetDownTrue();
            anim.Play("PlayerWalkingFront");
        }
        else if (horizontalMovement == 0 && verticalMovement == 0 && isWalkingDown && !Input.GetKey(KeyCode.DownArrow))
        {
            ResetWalkVariables();
            SetStandingDownTrue();
            anim.Play("PlayerIdleFront");
        }
    }

    //Usado para o movimento e para as físicas do jogo
    void FixedUpdate()
    {
        if (verticalMovement != 0 || horizontalMovement != 0)
            rb2d.velocity = new Vector2(horizontalMovement * moveSpeed * Time.deltaTime, verticalMovement * moveSpeed * Time.deltaTime).normalized * magnitude;
        else
            rb2d.velocity = Vector2.zero;
    }

    private void ResetWalkVariables()
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

    private void SetStandingUpTrue()
    {
        isStandingUp = true;
        isStandingLeft = false;
        isStandingRight = false;
        isStandingDown = false;
    }

    private void SetStandingLeftTrue()
    {
        isStandingUp = false;
        isStandingLeft = true;
        isStandingRight = false;
        isStandingDown = false;
    }

    private void SetStandingRightTrue()
    {
        isStandingUp = false;
        isStandingLeft = false;
        isStandingRight = true;
        isStandingDown = false;
    }

    private void SetStandingDownTrue()
    {
        isStandingUp = false;
        isStandingLeft = false;
        isStandingRight = false;
        isStandingDown = true;
    }
}

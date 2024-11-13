using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float movementSpeed = 1f;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime;

    bool facingRight = true;
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    // Awake is called when the scene generated // Does not depend on script activation
    private void Awake()
    {
        
    }

    // Start is called before the first frame update // Depends on the script activation
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver) return;

        HorizontalMove();
        OnGroundCheck();

        if (playerRB.velocity.x < 0 && facingRight )
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight )
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical") >  0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    //FixedUpdate is called once per "n" second (default: 0.02 == 50 call for per second)
    void FixedUpdate()
    {
        
    }

    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;  
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Jump()
    {
        playerRB.AddForce(new Vector2(0f, jumpSpeed));
        SoundManager.instance.PlaySoundJump();
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}

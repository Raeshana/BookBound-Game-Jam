using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    [Header("Scripts")]
    private Movement _playerMove;
    private Jump _playerJump;

    [Header("Variables")]
    private float _directionX;
    private bool isFacingRight = true;

    [Header("Bools")]
    private bool _isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerMove = GetComponent<Movement>();
        _playerJump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
        Flip();
    }

    private void PlayerMove()
    {
        _directionX = Input.GetAxis("Horizontal");
        _playerMove.MoveFn(_directionX);
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _playerJump.JumpFn();
            _isGrounded = false;
        }
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    private void Flip()
    {
        if (isFacingRight && _directionX < 0f || !isFacingRight && _directionX >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

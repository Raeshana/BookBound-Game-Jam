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
    private bool _isFacingRight = true;

    [Header("Bools")]
    private bool _isGrounded = false;

    [Header("Animations")]
    private Animator _playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        _playerMove = GetComponent<Movement>();
        _playerJump = GetComponent<Jump>();
        _playerAnim = GetComponent<Animator>();
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
        if(_directionX != 0f)
        {
            _playerMove.MoveFn(_directionX);
            _playerAnim.SetBool("isRunning", true);
        }
        else {
            _playerAnim.SetBool("isRunning", false);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _playerJump.JumpFn();
            _isGrounded = false;
            _playerAnim.SetBool("isJumping", true);
        }
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            _playerAnim.SetBool("isJumping", false);
        }
    }

    private void Flip()
    {
        if (_isFacingRight && _directionX < 0f || !_isFacingRight && _directionX > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}

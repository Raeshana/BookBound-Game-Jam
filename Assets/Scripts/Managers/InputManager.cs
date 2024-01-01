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

    private Rigidbody2D _rb;

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
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckJump());
        PlayerMove();
        PlayerJump();
        Flip();
    }

    private IEnumerator CheckJump()
    {
        if (_rb.velocity.y == 0) // the player may be either touching ground or at the max jump height
        {

            yield return new WaitForSeconds(0.1f);
            if (_rb.velocity.y == 0) // if the player isn't falling anymore i.e. he's on the ground
            {
                _isGrounded = true;
                _playerAnim.SetBool("isJumping", false);
            }
        }
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
            _rb.velocity = new Vector2(0, _rb.velocity.y);
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
        //Debug.Log(_isGrounded);

        if (collision.gameObject.tag == "Ground")
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

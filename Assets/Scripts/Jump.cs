using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void JumpFn()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
    }
}

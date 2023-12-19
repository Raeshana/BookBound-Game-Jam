using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveFn(float _direction)
    {
        _rb.velocity = new Vector2(_direction * moveSpeed, _rb.velocity.y);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float direction;
    public string type;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (type == "vertical")
        {
            StartCoroutine(Vertical());
        }
        else
        {
            StartCoroutine(Horizontal());
        }
    }

    private IEnumerator Vertical()
    {
        Debug.Log(rb.velocity.y);
        bool running = true;
        while (running)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * direction);
            yield return new WaitForSeconds(0.5f);
            rb.velocity = new Vector2(rb.velocity.x, speed * direction * -1);
            yield return new WaitForSeconds(0.5f);
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(1.5f);
        }
    }

    private IEnumerator Horizontal()
    {
        //Debug.Log(rb.velocity.x);
        bool running = true;
        while (running)
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
            yield return new WaitForSeconds(0.5f);
            rb.velocity = new Vector2(speed * direction * -1, rb.velocity.y);
            yield return new WaitForSeconds(0.5f);
            rb.velocity = Vector2.zero;
            yield return new WaitForSeconds(1.5f);
        }
    }
}

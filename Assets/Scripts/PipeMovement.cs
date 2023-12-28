using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    private IEnumerator Countdown()
    {
        Debug.Log(rb.velocity.y);
        bool running = true;
        while (running)
        {
            yield return new WaitForSeconds(2f);
            rb.velocity = new Vector2(rb.velocity.x, speed);
            yield return new WaitForSeconds(2f);
            rb.velocity = new Vector2(rb.velocity.x, speed * -1);
            yield return new WaitForSeconds(2f);
        }
    }
}

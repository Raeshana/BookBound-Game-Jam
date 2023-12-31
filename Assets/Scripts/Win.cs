using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private SceneController scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = GetComponent<SceneController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Destination"))
        {
            scene.GoToWinScreen();
        }
    }
}

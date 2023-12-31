using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private SceneController scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = GetComponent<SceneController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            scene.GoToLoseScreen();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int counter = 0;
    [SerializeField] TMP_Text text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gobstopper"))
        {
            Destroy(collision.gameObject);
            counter++;
            text.text = counter + "*";
        }
    }
}

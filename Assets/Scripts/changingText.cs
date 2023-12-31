using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changingText : MonoBehaviour
{
    private TMP_Text text;
    [SerializeField] float time;
    private string[] words = {"Adieu", "Aufwiedersehen", "Gesundheit", "Farewell", "Goodbye"};
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(changeTextRoutine());
    }

    private IEnumerator changeTextRoutine()
    {
        yield return new WaitForSeconds(time);
        //text.text = words[counter];
        counter++;
    }
}

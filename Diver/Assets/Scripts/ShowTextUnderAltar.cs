using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTextUnderAltar : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject altar;

    private int bodyParts;

    private void FixedUpdate()
    {
        bodyParts = FindFirstObjectByType<AltarLogic>().bodyParts;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.SetActive(true);

            text.text = bodyParts + " out of 10 body parts left";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.SetActive(false);
        }
    }

}

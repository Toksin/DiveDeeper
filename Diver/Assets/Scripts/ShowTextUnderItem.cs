using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ShowTextUnderItem : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject bucket;
    private int gems;   

    private void FixedUpdate()
    {
        gems = FindFirstObjectByType<EndingGame>().gemsFromPlayer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canvas.SetActive(true);           

            text.text = gems + " out of 50 gems left to collect";
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

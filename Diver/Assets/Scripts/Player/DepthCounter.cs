using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DepthCounter : MonoBehaviour
{
    [Header("Компоненты")]
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text depthText;
    
   

    [Header("Переменные")]
    private float depth; 


    void Update()
    {
        CalculateDepth();
    }

    void CalculateDepth()
    {
        depth = player.transform.position.y;

        depthText.text =  Convert.ToInt64(depth).ToString() + " m.";
    }
}

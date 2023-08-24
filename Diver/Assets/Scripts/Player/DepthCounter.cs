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

    [Header("Настройки смерти")]
    [SerializeField] private float maxFallingDistance = 10f;
    [SerializeField] private float startedPos;// Глубина, при которой происходит смерть
    [SerializeField] private float endPos;// Глубина, при которой происходит смерть



    void Update()
    {
        CalculateDepth();
    }

    void CalculateDepth()
    {
        depth = player.transform.position.y * -1;

        depthText.text =  Convert.ToInt64(depth).ToString() + " m.";
    }
    
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DepthCounter : MonoBehaviour
{
    [Header("����������")]
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text depthText;
    
   

    [Header("����������")]
    public float depth;

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

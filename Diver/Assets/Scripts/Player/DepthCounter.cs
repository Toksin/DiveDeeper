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
    private float depth;

    [Header("��������� ������")]
    [SerializeField] private float maxFallingDistance = 10f;
    [SerializeField] private float startedPos;// �������, ��� ������� ���������� ������
    [SerializeField] private float endPos;// �������, ��� ������� ���������� ������



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

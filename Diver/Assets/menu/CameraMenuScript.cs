using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuScript : MonoBehaviour
{
    public float shakeAmount = 0.1f;
    public float shakeSpeed = 5.0f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // ��������� �������� ��� ������ �� ������ ������ �������
        float xOffset = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
        float yOffset = Mathf.Cos(Time.time * shakeSpeed) * shakeAmount;

        // ��������� �������� � ��������� �������
        Vector3 newPosition = initialPosition + new Vector3(xOffset, yOffset, 0);

        // ��������� ����� ������� � ������
        transform.position = newPosition;
    }
}

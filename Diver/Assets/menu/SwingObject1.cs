using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObject1 : MonoBehaviour
{
    public float swingSpeed = 2.0f; // �������� �������
    public float maxSwingAngle = 30.0f; // ������������ ���� �������

    private Quaternion startRotation;
    private float timeElapsed = 0.0f;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        // ���������� ���� ������� �� ������ �������������� �������
        float angle = Mathf.Sin(timeElapsed * swingSpeed) * maxSwingAngle;

        // ���������� �������� � �������
        Quaternion newRotation = startRotation * Quaternion.Euler(0.0f, 0.0f, angle);
        transform.rotation = newRotation;
    }
}

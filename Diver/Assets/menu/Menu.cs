using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject objectToEnable;

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    private System.Collections.IEnumerator StartGameCoroutine()
    {
        // �������� ������ �� 2 �������
        objectToEnable.SetActive(true);
        yield return new WaitForSeconds(3f);

        // ��������� ��������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameCoroutine());
    }

    private System.Collections.IEnumerator ExitGameCoroutine()
    {
        // �������� ������ �� 2 �������
        objectToEnable.SetActive(true);
        yield return new WaitForSeconds(2f);

        // ������� ����������
        Application.Quit();
    }
}

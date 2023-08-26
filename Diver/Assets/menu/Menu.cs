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
        // Включить объект на 2 секунды
        objectToEnable.SetActive(true);
        yield return new WaitForSeconds(3f);

        // Загрузить следующую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        StartCoroutine(ExitGameCoroutine());
    }

    private System.Collections.IEnumerator ExitGameCoroutine()
    {
        // Включить объект на 2 секунды
        objectToEnable.SetActive(true);
        yield return new WaitForSeconds(2f);

        // Закрыть приложение
        Application.Quit();
    }
}

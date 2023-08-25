using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Vector2 playerInitPosition;

    private void Start()
    {
        playerInitPosition = FindFirstObjectByType<Player>().transform.position;
    }

    public void Restart()
    {     

        if(FindFirstObjectByType<LifeCount>().attemptRemain == 0) 
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            FindFirstObjectByType<Player>().ResetPlayer();
            FindFirstObjectByType<Player>().transform.position = playerInitPosition;
            FindFirstObjectByType<LifeCount>().livesRemaining = 4;

            foreach (var item in FindFirstObjectByType<LifeCount>().lifes)
            {
                item.enabled = true;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{  
    public int livesRemaining;
    public Image[] lifes;

    public int attemptRemain = 3;

    public void LoseLife()
    {
        if (livesRemaining == 0)
            return;

        livesRemaining--;
        lifes[livesRemaining].enabled = false;

        if(livesRemaining == 0)
        {
            FindFirstObjectByType<Player>().Die();
            attemptRemain--;

        }
    }

    public void RestoreLife()
    {       

        lifes[livesRemaining].enabled = true;
        livesRemaining++;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)) 
        {
            LoseLife();
        }        
    }

    //private void Start()
    //{
    //    lifes = new Image[maxLives];
    //    livesRemaining = maxLives;
    //}

}

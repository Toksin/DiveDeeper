using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{  
    public int livesRemaining;
    public Image[] lifes;   

    public void LoseLife()
    {
        if (livesRemaining == 0)
            return;

        livesRemaining--;
        lifes[livesRemaining].enabled = false;

        if(livesRemaining == 0)
        {
            Debug.Log("GG");
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

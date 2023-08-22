using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lifes;
    public int livesRemaining;
    
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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)) 
        {
            LoseLife();
        }
    }

}

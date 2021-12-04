using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;

    public void LoseLife()
    {
        if (livesRemaining == 0)
            return;
        //Decrease the value of livesRemmaining
        livesRemaining--;
        //Hide one of the life images
        lives[livesRemaining].enabled = false;

        //If we run out of lives we loose the game
        if(livesRemaining == 0)
        {
            Debug.Log("You Lose");
        }
    }

    public void Update (bool isDead)
    {
        if (isDead == true)
            LoseLife();
    }
}

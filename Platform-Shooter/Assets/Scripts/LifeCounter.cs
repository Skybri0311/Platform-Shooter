using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    public bool gameOver = false;
    public LevelController levelController;

    private void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    public void LoseLife()
    {

        //Decrease the value of livesRemmaining
        livesRemaining--;
        //Hide one of the life images
        lives[livesRemaining].enabled = false;

        //If we run out of lives we loose the game
        if(livesRemaining == 0)
        {
            Debug.Log("You Lose");
            gameOver = true;
            levelController.Reload();
        }
    }

    public void IsDead(bool isDead)
    {
        if (isDead == true)
            LoseLife();
    }

}

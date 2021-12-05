using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    public bool isDead = false;
    public int sDamage = 25;
    
    private LifeCounter lifeCounter;
    private LevelController levelController;

    private void Awake()
    {
        lifeCounter = FindObjectOfType<LifeCounter>();
        levelController = FindObjectOfType<LevelController>();
    }

    public void LoseHealth()
    {
        //Reduce the health
        health -= sDamage;
        Debug.Log("Health" + health);
        //Refresh the UI fill bar
        fillBar.fillAmount = health / 100;
        //Check if health is 0 or less
        if(health==0)
        {
            Debug.Log("You Die");
            Die();
        }
    }
    void Die()
    {
        //set the is dead bool in HealthBar script and in LifeCounter scipt
        isDead = true;
        lifeCounter.IsDead(isDead = true);
        isDead = false;
        lifeCounter.IsDead(isDead = false);
        //Reset health to 100 and reset the fill to the new health
        health = 100;
        fillBar.fillAmount = health;
        //Reset player to start position do not reset level
        levelController.Respawn();
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            LoseHealth();
        }
        Debug.Log(hitInfo.name);
    }
}

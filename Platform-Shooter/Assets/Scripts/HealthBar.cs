using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health;
    public int currentLevelIndex;
    public bool isDead = false;
    public int sDamage = 25;
    private LifeCounter lifeCounter;

    private void Awake()
    {
        lifeCounter = GameObject.FindObjectOfType<LifeCounter>();
            
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
        isDead = true;
        lifeCounter.IsDead(isDead = true);
        isDead = false;
        lifeCounter.IsDead(isDead = false);
        health = 100;
        fillBar.fillAmount = health;
        //Reset player to start position
        
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

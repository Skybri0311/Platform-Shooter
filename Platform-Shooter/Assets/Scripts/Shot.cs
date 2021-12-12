using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 20f;
    public int sDamage = 100;
    public Rigidbody2D rb;

    public ScoreCounter scoreCounter;

    private void Awake()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage();
            scoreCounter.AddScore();
            Debug.Log("Took Hit");
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }
}


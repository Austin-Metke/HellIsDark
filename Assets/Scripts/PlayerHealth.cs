using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    
    [SerializeField] private float playerHealth;
    private const float maxHealth = 100;
    private const float enemyDamage = 15;
    private bool isDead;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        isDead = false;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            isDead = true;
            Debug.Log("Player died!");
        }
    }
    //Checks for collison with enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player hit!");
            takeDamage(enemyDamage);
        }
    }

    private void takeDamage(float damage)
    {
        playerHealth -= damage;
        healthBar.setHealth(playerHealth);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    
    [SerializeField] private float playerHealth;
    private const float maxHealth = 100;
    private const float enemyDamage = 15;
    public bool isDead;
   [SerializeField] private bool isInvincible;
    private bool isColidedWithEnemy;
    public HealthBar healthBar;
    [SerializeField] private const float invincibiltyDurationInSeconds = 0.5f;
    private float startInvincibiltyTimer;
    private float damage;
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

        if (isInvincible)
        {
            startInvincibiltyTimer += Time.deltaTime;
        }


        if(isColidedWithEnemy && startInvincibiltyTimer >= invincibiltyDurationInSeconds)
        {
            startInvincibiltyTimer = 0;
            isInvincible = false;
            takeDamage(damage);
        }


    }
    //Checks for collison with enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Grunt":
                isColidedWithEnemy = true;
                damage = DamageValues.EnemyDamage.gruntDamage;
                takeDamage(damage);
                isInvincible = true;
                break;

            case "Spike":
                isColidedWithEnemy = true;
                damage = DamageValues.EnemyDamage.spikeDamage;
                takeDamage(damage);
                isInvincible = true;
                break;

            case "Void":
                instantKill();
                break;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        switch (collision.gameObject.tag)
        {
            case "Grunt":
                isColidedWithEnemy = false;
                break;

            case "Spike":
                isColidedWithEnemy = false;
                break;

            case "Void":
                isColidedWithEnemy = false;
                break;
        }

    }

    private void instantKill()
    {
        playerHealth = 0;
        healthBar.setHealth(playerHealth);
    }

    private void takeDamage(float damage)
    {
        if(isInvincible)
        {
            return;
        }
        playerHealth -= damage;
        healthBar.setHealth(playerHealth);
        isInvincible = true;
    }
}

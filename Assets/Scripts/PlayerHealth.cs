using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float playerHealth;
    private const float maxHealth = 100;
    private const float enemyDamage = 15;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth <= 0)
        {
            isDead = true;
        }
        



    }
    //Checks for collison with enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHealth -= enemyDamage;
        }
    }
}

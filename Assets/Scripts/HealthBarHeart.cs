using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHeart : MonoBehaviour
{
    public Sprite oneHundredPercent;
    public Sprite seventyFivePercent;
    public Sprite fiftyPercent;
    public Sprite twentyFivePercent;
    public Sprite zeroPercent;
    private Image image;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
         image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.getHealth() >= 100)
        {
            image.sprite = oneHundredPercent;
        }
        if (healthBar.getHealth() <= 75)
        {
            image.sprite = seventyFivePercent;
        }

        if (healthBar.getHealth() <= 50)
        {
            image.sprite = fiftyPercent;
        }

        if (healthBar.getHealth() <= 25)
        {
            image.sprite = twentyFivePercent;
        }

        if(healthBar.getHealth() <= 0)
        {
            image.sprite = zeroPercent;
        }
    }
}

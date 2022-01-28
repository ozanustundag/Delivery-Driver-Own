using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PackageCollectScript : MonoBehaviour
{
    [Header("Car Colors")]
    [SerializeField] Color normalCarColor;
    [SerializeField] Color packageCarColor;
    [Header("Background")]
    [SerializeField] TextMeshProUGUI scoreText;
    
    public int score { get; set; }

    bool hasPackage;

    CarControllerScript carController;
  
    void Start()
    {
        
        carController = FindObjectOfType<CarControllerScript>();
    }

    private void Update()
    {
        Debug.Log(score);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag=="Package" && !hasPackage)
        {
           
            hasPackage = true;          
            ColorControl(hasPackage);
            Destroy(collision.gameObject);
            
        }
        else if (collision.tag=="DeliveryPoint" && hasPackage)
        {
            
            score++;
            scoreText.text = "Score: " + score;
            hasPackage = false;          
            ColorControl(hasPackage);
            if (score == 1)
            {
                
                FindObjectOfType<GameControl>().GameOver();
            }


        }
        else if (collision.tag=="Boost")
        {
            carController.BumpBoostSpeed(false, true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Bumped")
        {
            carController.BumpBoostSpeed(true, false);

        }
    }

    void ColorControl(bool hasPackage)
    {
        if (hasPackage)
        {
            GetComponent<SpriteRenderer>().color = packageCarColor;
          
        }
        else
            GetComponent<SpriteRenderer>().color = normalCarColor;
    }
}

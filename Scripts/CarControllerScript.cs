using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControllerScript : MonoBehaviour
{
    [Header("Speed Parameters")]
    [SerializeField] float normalSpeed=10f;
    [SerializeField] float bumpSpeed=5f;
    [SerializeField] float boostSpeed=15f;
    [SerializeField] float steelSpeed = 100f;

    float carSpeed;
    float speedAmount;
    float steelAmount;

    void Start()
    {
        carSpeed = normalSpeed;
    }  
    void Update()
    {
      CarMove();        
    }
    void CarMove()
    {
        speedAmount = Input.GetAxisRaw("Vertical") * carSpeed * Time.deltaTime;
        steelAmount = Input.GetAxisRaw("Horizontal") * steelSpeed * Time.deltaTime;
        transform.Translate(0, speedAmount, 0);
        transform.Rotate(0, 0, -steelAmount);      
    }
   public void BumpBoostSpeed(bool hasBumped,bool hasBoost)
    {
        if (hasBoost)
        {
            
            carSpeed = boostSpeed;
        }
        else if (hasBumped)
        {
           
            carSpeed = bumpSpeed;          
        }
            
    }
}

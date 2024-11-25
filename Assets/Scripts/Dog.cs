using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Animal
{
    public override void Feed()
    {
        HungerLevel = Mathf.Min(HungerLevel + 3, MaxHungerLevel);
        Debug.Log("Dog is fed! Hunger Level: " + HungerLevel);
        
    GameController gameController = FindObjectOfType<GameController>();
    if (gameController != null)
    {
        gameController.UpdateHungerText(); // Call to refresh hunger display
    }
    else
    {
        Debug.LogError("GameController not found!");
    }
    }

    public override void Pet()
    {
        HappinessLevel = Mathf.Min(HappinessLevel + 2, 10);
        Debug.Log("Dog is petted! Happiness Level: " + HappinessLevel);
    }
}

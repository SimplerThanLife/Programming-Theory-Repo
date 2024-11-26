using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    public override void Feed()
    {
        HungerLevel = Mathf.Min(HungerLevel + 3, MaxHungerLevel);
        Debug.Log("Cat is fed! Hunger Level: " + HungerLevel);
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
        HappinessLevel = Mathf.Min(HappinessLevel + 1, 10);
        Debug.Log("Cat is petted! Happiness Level: " + HappinessLevel);
        GameController gameController = FindObjectOfType<GameController>();
        if (gameController != null)
        {
            gameController.UpdateHappinessText(); // Call to refresh hunger display
        }
        else
        {
            Debug.LogError("GameController not found!");
        }
    }
}

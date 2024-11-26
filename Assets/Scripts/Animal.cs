using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    // Properties
    public int HungerLevel { get; protected set; }
    public int MaxHungerLevel { get; protected set; } = 10; // Default max value
    public int HappinessLevel { get; protected set; }
    public int MaxHappinessLevel { get; protected set; } = 10; // Default max value

    private void Start()
    {
        HungerLevel = MaxHungerLevel; // Initialize HungerLevel to MaxHungerLevel
        HappinessLevel = MaxHappinessLevel;
        GameController gameController = FindObjectOfType<GameController>();
    if (gameController != null)
    {
        gameController.UpdateHungerText(); // Call to refresh hunger display
        gameController.UpdateHappinessText();
    }
    else
    {
        Debug.LogError("GameController not found!");
    }
        StartCoroutine(DecayHungerOverTime());
        StartCoroutine(DecayHappinessOverTime());

    }

    // Decay over time
    private void DecayHunger()
    {
        HungerLevel = Mathf.Max(HungerLevel - 1, 0);

        GameController gameController = FindObjectOfType<GameController>();
            // Call the method to update the hunger bar in the UI
        if (gameController != null)
        {
            gameController.UpdateHungerText();  // Update the hunger bar in the GameController
            Debug.Log("Hunger bar updated.");
        }
        else
        {
            Debug.LogError("GameController not found!");
        }
        Debug.Log("Hunger Level: " + HungerLevel);

        if (HungerLevel == 0)
        {
            FindObjectOfType<GameController>().EndGame();
        }
    }

    private void DecayHappiness()
    {
        HappinessLevel = Mathf.Max(HappinessLevel - 1, 0);
        GameController gameController = FindObjectOfType<GameController>();
            // Call the method to update the hunger bar in the UI
        if (gameController != null)
        {
            gameController.UpdateHappinessText();  // Update the hunger bar in the GameController
            Debug.Log("Happiness bar updated.");
        }
        else
        {
            Debug.LogError("GameController not found!");
        }
        Debug.Log("Happiness Level: " + HappinessLevel);
    }
    private IEnumerator DecayHungerOverTime()
    {
        while (HungerLevel > 0)
        {
            Debug.Log("Waiting to decay hunger...");
            yield return new WaitForSeconds(5);  // Decay every 5 seconds
            Debug.Log("Triggering DecayHunger...");
            DecayHunger();
        }
        Debug.Log("Hunger has reached zero, stopping decay.");
    }

     private IEnumerator DecayHappinessOverTime()
    {
        while (HappinessLevel > 0)
        {
            Debug.Log("Waiting to decay happiness...");
            yield return new WaitForSeconds(5);  // Decay every 5 seconds
            Debug.Log("Triggering DecayHappiness...");
            DecayHappiness();
        }
        Debug.Log("Happiness has reached zero, stopping decay.");
    }


    // Abstract methods for each action
    public abstract void Feed();
    public abstract void Pet();
}
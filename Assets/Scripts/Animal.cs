using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    // Properties
    public float HungerLevel = 10;
    public int HappinessLevel { get; protected set; }

    private float hungerDecayTimer = 2.0f; // Time in seconds between hunger decay
    private float happinessDecayTimer = 3.0f; // Time in seconds between happiness decay

    private void Start()
    {
        StartCoroutine(DecayHungerOverTime());
        //InvokeRepeating(nameof(DecayHunger), hungerDecayTimer, hungerDecayTimer);
        InvokeRepeating(nameof(DecayHappiness), happinessDecayTimer, happinessDecayTimer);
    }

    // Decay over time
    private void DecayHunger()
    {
        HungerLevel = Mathf.Max(HungerLevel - 1, 0);

        GameController gameController = FindObjectOfType<GameController>();
            // Call the method to update the hunger bar in the UI
        if (gameController != null)
        {
            gameController.UpdateHungerBar();  // Update the hunger bar in the GameController
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
    }
    private IEnumerator DecayHungerOverTime()
    {
        while (HungerLevel > 0)
        {
            yield return new WaitForSeconds(5);  // Decay every 5 seconds
            DecayHunger();
        }
    }
    // Abstract methods for each action
    public abstract void Feed();
    public abstract void Pet();
}
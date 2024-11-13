using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    // Properties
    public int HungerLevel { get; protected set; }
    public int HappinessLevel { get; protected set; }

    private float hungerDecayTimer = 2.0f; // Time in seconds between hunger decay
    private float happinessDecayTimer = 3.0f; // Time in seconds between happiness decay

    private void Start()
    {
        InvokeRepeating(nameof(DecayHunger), hungerDecayTimer, hungerDecayTimer);
        InvokeRepeating(nameof(DecayHappiness), happinessDecayTimer, happinessDecayTimer);
    }

    // Decay over time
    private void DecayHunger()
    {
        HungerLevel = Mathf.Max(HungerLevel - 1, 0);
        if (HungerLevel == 0)
        {
            FindObjectOfType<GameController>().EndGame();
        }
    }

    private void DecayHappiness()
    {
        HappinessLevel = Mathf.Max(HappinessLevel - 1, 0);
    }

    // Abstract methods for each action
    public abstract void Feed();
    public abstract void Pet();
}
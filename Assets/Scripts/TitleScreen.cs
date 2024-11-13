using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameController gameController; // Reference to the GameController
    public Animal dogPrefab; // Drag your Dog prefab here in the Inspector
    public Animal catPrefab; // Drag your Cat prefab here in the Inspector

    // Call this function when the Dog button is pressed
    public void OnDogSelected()
    {
        gameController.StartGame(dogPrefab);
    }

    // Call this function when the Cat button is pressed
    public void OnCatSelected()
    {
        gameController.StartGame(catPrefab);
    }

}

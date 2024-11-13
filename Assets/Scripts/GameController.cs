using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public AnimalManager animalManager;
    
    public void StartGame(Animal chosenAnimal)
    {
        animalManager.SelectAnimal(chosenAnimal);
        Debug.Log("Game started with " + chosenAnimal.GetType().Name);
        // Load game scene or initialize game logic
        SceneManager.LoadScene(1);


    }

    public void EndGame()
    {
        Debug.Log("Game Over! Hunger Level reached zero.");
        // Code to display end game message or return to title screen
    }
}

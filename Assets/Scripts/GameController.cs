using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private AnimalManager animalManager;

    private void Start() 
    {
        animalManager = AnimalManager.Instance;
         // Check if we're already in the game scene
        if (SceneManager.GetActiveScene().buildIndex == 1) // Assuming game scene is index 1
        {
            InitializeSelectedAnimal();
        }
        
    }
    
    public void StartGame(Animal chosenAnimal)
    {
        animalManager.SelectAnimal(chosenAnimal);
        Debug.Log("Game started with " + chosenAnimal.GetType().Name);
        // Load game scene or initialize game logic
        SceneManager.LoadScene(1);


    }
    private void InitializeSelectedAnimal()
    {
        // Retrieve the selected animal from the AnimalManager
        Animal selectedAnimal = AnimalManager.Instance.GetSelectedAnimal();
        
        if (selectedAnimal != null)
        {
            // Instantiate the selected animal in the game scene
            Instantiate(selectedAnimal, new Vector3(0, 0, 0), Quaternion.identity); // Adjust position as needed
            Debug.Log("Initialized selected animal: " + selectedAnimal.GetType().Name);
        }
        else
        {
            Debug.LogError("No animal selected! Returning to title screen.");
            // Optionally, load the title screen again if no animal was selected
            SceneManager.LoadScene("TitleScreen"); // Replace "TitleScreen" with your title scene name
        }
    }

    public void EndGame()
    {
        Debug.Log("Game Over! Hunger Level reached zero.");
        // Code to display end game message or return to title screen
        //SceneManager.LoadScene("TitleScreen"); // Adjust as needed
    }
}

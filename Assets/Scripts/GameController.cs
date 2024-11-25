using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI hungerText;
    private AnimalManager animalManager;

    private void Start() 
    {
        animalManager = AnimalManager.Instance;
         // Check if we're already in the game scene
        if (SceneManager.GetActiveScene().buildIndex == 1) // Assuming game scene is index 1
        {
            InitializeSelectedAnimal();
        }

                // Check if AnimalManager is properly loaded
        if (AnimalManager.Instance != null)
        {
            Debug.Log("AnimalManager is loaded.");
        }
        else
        {
            Debug.LogError("AnimalManager instance not found!");
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
            Animal selectedAnimalInstance = Instantiate(selectedAnimal, new Vector3(0, 0, 0), Quaternion.identity); // Adjust position as needed
            AnimalManager.Instance.SelectAnimal(selectedAnimalInstance);
            Debug.Log("Initialized selected animal: " + selectedAnimalInstance.GetType().Name);
        }
        else
        {
            Debug.LogError("No animal selected! Returning to title screen.");
            // Optionally, load the title screen again if no animal was selected
            SceneManager.LoadScene("TitleScreen"); // Replace "TitleScreen" with your title scene name
        }
    }

        public void FeedSelectedAnimal()
    {
        if (animalManager != null && animalManager.GetSelectedAnimal() != null)
        {
            animalManager.GetSelectedAnimal().Feed();
            UpdateHungerText();
            Debug.Log("Feeding selected animal.");
        }
        else
        {
            Debug.LogError("No animal selected to feed.");
        }
    }

    public void UpdateHungerText()
    {
        Animal selectedAnimal = AnimalManager.Instance.GetSelectedAnimal();
        if (selectedAnimal != null)
        {
            Debug.Log($"Updating hunger text for Animal Instance ID: {selectedAnimal.GetInstanceID()}");
            hungerText.text = $"Hunger: {selectedAnimal.HungerLevel}/{selectedAnimal.MaxHungerLevel}";
        }
        else
        {
            Debug.LogError("No selected animal found for hunger update!");
        }
    }

    public void EndGame()
    {
        Debug.Log("Game Over! Hunger Level reached zero.");
        // Code to display end game message or return to title screen
        //SceneManager.LoadScene("TitleScreen"); // Adjust as needed
    }
}

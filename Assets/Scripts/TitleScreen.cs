using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public Animal dogPrefab; // Drag your Dog prefab here in the Inspector
    public Animal catPrefab; // Drag your Cat prefab here in the Inspector

    // Call this function when the Dog button is pressed
    public void OnDogSelected()
    {
        AnimalManager.Instance.SelectAnimal(dogPrefab);
        LoadGameScene();
    }

    // Call this function when the Cat button is pressed
    public void OnCatSelected()
    {
        AnimalManager.Instance.SelectAnimal(catPrefab);
        LoadGameScene();
    }

    private void LoadGameScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

}

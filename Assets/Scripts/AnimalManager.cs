using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    public static AnimalManager Instance { get; private set; }
    private Animal selectedAnimal;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate instances
        }
    }

    public void SelectAnimal(Animal animal)
    {
        selectedAnimal = animal;
        Debug.Log("Selected Animal: " + selectedAnimal.GetType().Name);
    }

    public Animal GetSelectedAnimal()
    {
        return selectedAnimal;
    }

    public void FeedSelectedAnimal()
    {
        if (selectedAnimal != null)
        {
            selectedAnimal.Feed();
        }
    }

    public void PetSelectedAnimal()
    {
        if (selectedAnimal != null)
        {
            selectedAnimal.Pet();
        }
    }
}

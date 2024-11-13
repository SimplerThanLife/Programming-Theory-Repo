using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalManager : MonoBehaviour
{
    private Animal selectedAnimal;

    private static AnimalManager Instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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

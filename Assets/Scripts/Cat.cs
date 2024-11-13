using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
{
    private void Awake()
    {
        HungerLevel = 10;
        HappinessLevel = 10;
    }

    public override void Feed()
    {
        HungerLevel = Mathf.Min(HungerLevel + 3, 10);
        Debug.Log("Cat is fed! Hunger Level: " + HungerLevel);
    }

    public override void Pet()
    {
        HappinessLevel = Mathf.Min(HappinessLevel + 2, 10);
        Debug.Log("Cat is petted! Happiness Level: " + HappinessLevel);
    }
}
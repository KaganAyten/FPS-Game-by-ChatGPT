using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // The maximum health of the object
    public float maxHealth = 100.0f;

    // The current health of the object
    public float currentHealth;

    void Start()
    {
        // Set the current health to the maximum health when the object is created
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // Reduce the current health by the specified amount of damage
        currentHealth -= damage;

        // If the current health is less than or equal to 0
        if (currentHealth <= 0)
        {
            // Destroy the object 
        }
    }
}

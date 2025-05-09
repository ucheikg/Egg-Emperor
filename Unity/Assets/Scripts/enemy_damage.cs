using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_damage : MonoBehaviour
{

    int health = 100;
    public bool foild = false;
    int currentHealth;

    void Update()
    {

        // if enemies health is less than or equal to zero then you win and game quits
        if (health <= 0)
        {
            Destroy(gameObject);
            Application.Quit();
            Debug.Log("died");
        }

    }
    // if enemy maes contact with enemy of the weapon systems then enemy takes damage
    private void OnTriggerEnter(Collider other)
    {
        // laser does consistent damage to gameobject
        if (other.gameObject.CompareTag("laser"))
        {
            currentHealth = health;
            health--;
        }
        if (other.gameObject.CompareTag("laser"))
        {
            health -= 3;
        }
        if (other.gameObject.CompareTag("bullet"))
        {
            health--;
        }
    }

    private void OnTriggerExit(Collider other)
    {
    //when the gameobject leaves the lasers range it should stop taking damage
        if (other.gameObject.CompareTag("laser"))
        {
            health = currentHealth;
        }
    }

}

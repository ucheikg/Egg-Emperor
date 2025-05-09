using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    int health = 100;
    public bool foild = false;
    int currentHealth;

    void Update()
    {
        // if Player has zero health or less the player has died and the program ends
        if (health <= 0)
        {
            Application.Quit();
            Debug.Log("died");
        }
        // allows players to quit game with escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("quit");
            Application.Quit();

        }
    }
    // if player makes contact with enemy health reduces
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            currentHealth = health;
            health--;
        }
    }
    // when player leaves player vicinity health stops reducing
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            health = currentHealth;
        }
    }

}

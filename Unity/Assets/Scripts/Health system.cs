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
        if (health <= 0)
        {
            Application.Quit();
            Debug.Log("died");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("quit");
            Application.Quit();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            currentHealth = health;
            health--;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            health = currentHealth;
        }
    }

}

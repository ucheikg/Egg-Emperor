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
        if (health <= 0)
        {
            Destroy(gameObject);
            Application.Quit();
            Debug.Log("died");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
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
        if (other.gameObject.CompareTag("laser"))
        {
            health = currentHealth;
        }
    }

}

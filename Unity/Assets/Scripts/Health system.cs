using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    int health = 100;
    bool attacked;
    bool safe;
    public bool foild = false;

    void Update()
    {
        while(attacked)
        {
            health--;
            if (safe == true)
            {
                break;
            }
        }
        attacked = false;

        if (health <= 0)
        {
            foild = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            attacked = true;
            safe = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            safe = true;
        }
    }
}

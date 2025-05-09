using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    // if bullet makes contact with enemy or the ground then it should be destroyed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}

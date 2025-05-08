using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_damage : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int health = 100;
    public bool alive = true;
    bool takingdamage;
    bool onFire = false;
    bool safe;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (onFire)
        {
            health--;
            if (safe == true)
            {
                break;
            }
        }
        onFire = false;

        if(health <= 0)
        {
            alive = false;
        }

        if (!alive)
        {
            Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("flamethrower"))
        {
            onFire = true;
            safe = false;
        }
        else if (other.gameObject.CompareTag("bullet"))
        {
            health--;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("punchspring"))
        {
            health -= 15;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("flamethrower"))
        {
            safe = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_condition : MonoBehaviour
{
    enemy_damage enemyDamage;
    NewBehaviourScript healthsystem;
    void Start()
    {
        enemyDamage = GetComponent<enemy_damage>();
        healthsystem = GetComponent<NewBehaviourScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!enemyDamage.alive)
        {
            Application.Quit();
        }
        if (healthsystem.foild)
        {
            Application.Quit();
        }

        
    }
}

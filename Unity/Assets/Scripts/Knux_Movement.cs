using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Knux_Movement : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;
    private void Start()
    {
        // assigns a gameobject to player by a specific name
        player = GameObject.Find("Player").transform;
        // agents uses navmesh as navigation
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // agent will chase player down
        agent.SetDestination(player.position);
    }

}

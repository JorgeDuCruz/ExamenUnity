using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent navMeshAgent;
    private float disntacia;
    public String estado;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
       {    
           navMeshAgent.SetDestination(player.position);
           disntacia = Vector3.Distance(player.position,transform.position);
           if (disntacia > 10)
            {
                estado = "Lejos";
            }
            else
            {
                estado = "Cerca";
            }
       }
    }
}

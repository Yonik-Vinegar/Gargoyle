using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    public Transform goal;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (GargoyleScript.isSeen) { goal = transform; } else { goal = player.transform; }

        agent.destination = goal.position;
    }
}

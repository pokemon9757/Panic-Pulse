using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Manikin : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _agent;
    public bool testChase = false;
    void Start()
    {
        _player = FindObjectOfType<Player>().transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (testChase)
        {
            testChase = false;
            _agent.SetDestination(_player.position);
        }
    }

    public void ChasePlayerAfter(float delay)
    {
        _agent.SetDestination(_player.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Manikin : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _agent;
    Animator _animator;
    [Header("Animation triggers")]
    public string Idle = "Idle";
    public string Run = "Run";
    public string Kill = "Kill";

    public bool testChase = false;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>().transform;
        _agent = GetComponent<NavMeshAgent>();
        tag = "Manikin";
    }

    void Update()
    {
        if (testChase)
        {
            testChase = false;
            _agent.SetDestination(_player.position);
            _animator.SetTrigger(Run);
        }
    }

    public void ChasePlayerAfter(float delay)
    {
        _agent.SetDestination(_player.position);
    }
}

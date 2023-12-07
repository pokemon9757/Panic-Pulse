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
    Coroutine _coFreeze;
    float _remainingFreezeTime = 0;
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
            ChasePlayer();
            _animator.SetTrigger(Run);
        }
    }

    public void ChasePlayer()
    {
        ChasePosition(_player.position);
    }

    public void ChasePosition(Vector3 pos)
    {
        _agent.SetDestination(pos);
    }

    public void Freeze(float time)
    {
        _remainingFreezeTime = time;
        if (_coFreeze == null) _coFreeze = StartCoroutine(CoFreeze());
    }

    IEnumerator CoFreeze()
    {
        _agent.isStopped = true;
        while (_remainingFreezeTime >= 0)
        {
            _remainingFreezeTime -= Time.deltaTime;
            yield return null;
        }
        _agent.isStopped = false;
        _coFreeze = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
public class Manikin : MonoBehaviour
{
    [SerializeField] NoiseDetection noiseDetection;
    public AudioClip[] FootstepAudioClips;
    [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

    [Header("Animation triggers")]
    public string Idle = "Idle";
    public string Run = "Run";
    public string Kill = "Kill";
    public AttackAbility attackAbility;
    public bool testChase = false;
    Transform _player;
    NavMeshAgent _agent;
    Animator _animator;
    CapsuleCollider _collider;
    Coroutine _coFreeze;
    float _remainingFreezeTime = 0;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _player = FindObjectOfType<Player>().transform;
        _agent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<CapsuleCollider>();
        attackAbility.OnCanAttack.AddListener(Attack);
        tag = "Manikin";
        noiseDetection.OnHighHeartBeatDetected += ChasePlayer;
    }

    void Update()
    {
        if (testChase)
        {
            testChase = false;
            ChasePlayer();
        }
    }

    public void ChasePlayer()
    {
        ChasePosition(_player.position);
    }

    public void ChasePosition(Vector3 pos)
    {
        _animator.SetTrigger(Run);
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
        _animator.speed = 0;
        while (_remainingFreezeTime >= 0)
        {
            _remainingFreezeTime -= Time.deltaTime;
            yield return null;
        }
        _agent.isStopped = false;
        _animator.speed = 1;

        _coFreeze = null;
    }

    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_collider.center), FootstepAudioVolume);
            }
        }
    }

    void Attack(Player player)
    {
        if (_remainingFreezeTime > 0) return;
        _animator.SetTrigger(Kill);
        player.Die();
    }
}

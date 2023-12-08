using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackAbility : MonoBehaviour
{
    public UnityEvent<Player> OnCanAttack;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        OnCanAttack?.Invoke(other.GetComponent<Player>());
    }
}

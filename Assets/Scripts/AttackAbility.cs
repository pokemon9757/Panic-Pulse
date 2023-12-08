using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackAbility : MonoBehaviour
{
    public UnityEvent<Player> OnCanAttack;
    Player player;
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        if (player == null)
            player = other.GetComponent<Player>();
        OnCanAttack?.Invoke(player);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoiseDetection : MonoBehaviour
{
    Player player;
    public UnityAction OnHighHeartBeatDetected;
    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player") return;
        if (player == null)
            player = other.GetComponent<Player>();
        if (player.heartBeat.CurrentHRLevel > 2)
        {
            OnHighHeartBeatDetected?.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoiseDetection : MonoBehaviour
{
    public UnityAction OnHighHeartBeatDetected;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

        var player = other.GetComponent<Player>();
        if (player.heartBeat.CurrentHRLevel > 2)
        {
            OnHighHeartBeatDetected?.Invoke();
        }
    }
}

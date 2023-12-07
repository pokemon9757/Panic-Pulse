using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Player : MonoBehaviour
{
    public HeartBeat heartBeat;
    public float MinMoveSpeed = 2;
    public float MaxMoveSpeed = 5;
    [SerializeField] DynamicMoveProvider moveProvider;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Doom");
        }
    }

    void Update()
    {
        // Todo: Update HB based on the watch
        // Adapt the actions after HB has been updated
        AdaptHeartBeat();
    }

    void AdaptHeartBeat()
    {
        // Reduce movement speed based on HB 
        moveProvider.moveSpeed = Mathf.Lerp(MinMoveSpeed, MaxMoveSpeed, 1 / heartBeat.CurrentHRLevel);
    }
}

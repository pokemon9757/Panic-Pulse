using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Player : MonoBehaviour
{
    public int CurrentHeartBeat = 120;
    public int BaseHeartBeat = 60;
    public float MoveSpeed = 1;
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
        float hbRateToNormal = CurrentHeartBeat / BaseHeartBeat;
        MoveSpeed = Mathf.Lerp(0.2f, 1f, 1 / hbRateToNormal);
        moveProvider.moveSpeed = MoveSpeed;

        // Todo: Play HB audio based on the value

    }
}

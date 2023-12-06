using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public float Radius;
    public float Depth;
    public float Angle;
    public Light SpotLight;
    private Physics _physics;

    void FixedUpdate()
    {
        Depth = SpotLight.range;
        Angle = SpotLight.spotAngle;
        Radius = SpotLight.range * Mathf.Tan(SpotLight.spotAngle * 0.5f * Mathf.Deg2Rad);
        DoSphereCast();
    }

    void DoSphereCast()
    {
        var hits = Physics.SphereCastAll(transform.position, Radius, transform.forward, Depth);
        foreach (var hit in hits)
        {
            Vector3 dirToHit = (hit.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, dirToHit);

            if (angle < SpotLight.spotAngle / 2) // Check if within flashlight cone
            {
                Debug.Log("inside " + hit.collider.gameObject.name);
            }
        }
    }
}

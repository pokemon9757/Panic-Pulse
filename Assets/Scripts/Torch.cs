using System.Collections;
using System.Collections.Generic;
using Unity.Barracuda;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public float Radius;
    public float Depth;
    public Light SpotLight;
    public float FreezeTime = 5f;
    private Physics _physics;
    void FixedUpdate()
    {
        Depth = SpotLight.range;
        Radius = SpotLight.range * Mathf.Tan(SpotLight.spotAngle * 0.5f * Mathf.Deg2Rad);
        DoSphereCast();
    }

    void DoSphereCast()
    {
        // var hits = Physics.SphereCastAll(transform.position, Radius, transform.forward, Depth - Radius * 2, LayerMask.GetMask("Manikins"));
        // foreach (var hit in hits)
        // {
        //     var hitGO = hit.collider.gameObject;
        //     Debug.Log("Hitting manikin " + hitGO.name);

        //     // Freeze if it is manikin
        //     var manikin = hitGO.GetComponent<Manikin>();
        //     manikin.Freeze(FreezeTime);
        // }
    }
}

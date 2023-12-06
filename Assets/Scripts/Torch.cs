using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public float Radius;
    public float Depth;
    public float Angle;

    private Physics _physics;

    void FixedUpdate()
    {

        RaycastHit[] coneHits = _physics.ConeCastAll(transform.position, Radius, transform.forward, Depth, Angle);

        if (coneHits.Length > 0)
        {
            for (int i = 0; i < coneHits.Length; i++)
            {
                //do something with collider information
                coneHits[i].collider.gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 1f);
            }
        }
    }
}

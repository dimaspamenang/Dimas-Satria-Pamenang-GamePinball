using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BolaControl : MonoBehaviour
{

    public float maxSpeed;

    private Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rig.velocity.magnitude > maxSpeed)
        {
            rig.velocity = rig.velocity.normalized * maxSpeed;
        }
    }
}

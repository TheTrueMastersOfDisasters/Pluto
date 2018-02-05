using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour {

    public FauxGravityAttractor m_Attractor;

    private Transform m_Transform;
    private Rigidbody m_RigidBody;

    // Use this for initialization
    void Start ()
    {
        m_Transform = transform;
        m_RigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	private void FixedUpdate()
    {
        m_Attractor.Attract(m_Transform, m_RigidBody);
	}
}

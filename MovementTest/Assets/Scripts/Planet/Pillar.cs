using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour {

    public Transform m_Tracked;
    public float m_DirectionalOffset; 

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerController.instance.GetRelativeMoveDirection() != Vector3.zero)
        {
            Vector3 pointTo = m_Tracked.position + (PlayerController.instance.GetRelativeMoveDirection() * m_DirectionalOffset);
            transform.LookAt(pointTo);
        }
	}
}

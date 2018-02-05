using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour {

    public Transform m_Tracked;
    public float m_DirectionalOffset; 
	public float m_Timer;

	private bool InitiatePillarAttackA = false;
	private bool m_TrackingPluto = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.N))
		{
			InitiatePillarAttackA = true;
		}

		if (InitiatePillarAttackA) 
		{
			if (m_TrackingPluto) 
			{
				TrackPluto ();
			} 
			else 
			{
			
			}
		}
	}

	private void TrackPluto()
	{
		if (PlayerController.instance.GetRelativeMoveDirection () != Vector3.zero) {
			Vector3 pointTo = m_Tracked.position + (PlayerController.instance.GetRelativeMoveDirection () * m_DirectionalOffset);
			transform.LookAt (pointTo);
		} 
	}
}

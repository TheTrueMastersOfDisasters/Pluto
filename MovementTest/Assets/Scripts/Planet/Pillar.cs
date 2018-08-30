using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
	public enum PillarState
	{
		Dormint = 0,
		Emerging = 1,
		Emerged = 2
	};

	public float m_DirectionalOffset;
	public float m_EmergeHeight;

	private Quaternion m_InitialDirection = new Quaternion();
	private Vector3 m_InitialPosition = new Vector3();
	private Vector3 m_PointToDirection = new Vector3();
	private Vector3 m_PillarDestination = new Vector3();

	public PillarState e_PillarState;

	public Transform m_TrackingTransform;

	[SerializeField]
	private ParticleSystem m_EmergingSplash;

	private void Start()
	{
		m_InitialPosition = transform.position;
		m_InitialDirection = transform.rotation;
		m_PillarDestination = transform.position + (-transform.up * m_EmergeHeight);
		m_EmergingSplash.Stop();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			e_PillarState = PillarState.Emerging;
		}

		switch(e_PillarState)
		{
			case PillarState.Dormint:
				break;
			case PillarState.Emerging:
				this.Emerge();
				break;
			case PillarState.Emerged:
				this.Retract();
				break;
			default:
				break;
		}
	}

	private void ResetPillars()
	{
		transform.position = m_InitialPosition;
		transform.rotation = m_InitialDirection;
		e_PillarState = PillarState.Dormint;
		m_EmergingSplash.Stop();
	}

	private void Emerge()
	{
		transform.position = Vector3.Lerp(transform.position, m_PillarDestination, PillarAttackManager.instance.m_EmergeSpeed * Time.deltaTime);

		if (transform.position == m_PillarDestination)
		{
			e_PillarState = PillarState.Emerged;
		}
	}

	private void Retract()
	{
		transform.position = Vector3.Lerp(transform.position, m_InitialPosition, PillarAttackManager.instance.m_RetractSpeed * Time.deltaTime);

		if (MathUtility.IsClose(transform.position, m_InitialPosition, 1.0f))
		{
			this.ResetPillars();
		}

	}

	public void TrackPlayer()
	{
		m_PointToDirection = (PillarAttackManager.instance.GetPlayerTransform().position + (PlayerController.instance.GetRelativeMoveDirection().normalized * m_DirectionalOffset)).normalized;
		m_TrackingTransform.LookAt(m_PointToDirection);
		m_PillarDestination = transform.position + (m_TrackingTransform.forward * m_EmergeHeight);
	}

	public void PlaySplash()
	{
		m_EmergingSplash.Play();
	}

	public void StopSplash()
	{
		m_EmergingSplash.Play();
	}
}

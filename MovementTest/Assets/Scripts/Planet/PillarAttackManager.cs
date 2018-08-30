using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manager class for pillar attacks
/// </summary>
public class PillarAttackManager : MonoBehaviour
{

	private enum Attacks
	{
		BlowFish, // Attack that forces all pillars to emerge around the planet.
		PinPoint, // Selects some pillars to emerge at the players position.
		Area // Combination of both. All pillars emerge around a certain inescapable area.
	};

	private enum AttackState
	{
		Attacking,
		Cooldown,
	}

	private const int numberOfPillars = 26;

	public static PillarAttackManager instance = null;
	public float m_EmergeSpeed = 10.0f;
	public float m_RetractSpeed = 5.0f;

	[SerializeField]
	private Transform m_PlayerPosition;

	[SerializeField]
	private Pillar[] m_Pillars;

	private float m_AttackTimer = 0.0f;
	private bool m_Attacking = false;
	private int m_PinpointPillarCount = 3;

	// Use this for initialization
	void Start()
	{
		if(instance == null)
		{
			instance = this;
		}

		foreach (var piller in m_Pillars)
		{
			piller.gameObject.SetActive(true);
		}
	}

	// Update is called once per frame
	void Update()
	{
		//if (!m_Attacking)
		//{
		//	attackTimer += Time.deltaTime;
		//}
		//
		//if (attackTimer >= 10)
		//{
		//	PinPointAttack();
		//	m_Attacking = true;
		//}
	}

	private void PinPointAttack()
	{
		for (int i = 0; i < m_PinpointPillarCount; ++i)
		{
			//m_Pillars[i].trackPlayer = true;
		}
	}

	public Transform GetPlayerTransform()
	{
		return m_PlayerPosition;
	}
}

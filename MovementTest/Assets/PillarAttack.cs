using UnityEngine;

public class PillarAttack : MonoBehaviour {

	private enum AttackState
	{
		DoNothing,
		AttackInitiated,
		Tracked,
		Emerged,
	};

	[SerializeField]
	private Pillar m_Pillar;

	private float m_EmergeDelay = 1.0f;
	private float m_EmergedTime = 2.0f;

	private AttackState e_AttackState;

	void Start ()
	{
		e_AttackState = AttackState.DoNothing;
	}

	void Update()
	{		
		if(Input.GetKeyDown(KeyCode.V))
		{
			e_AttackState = AttackState.AttackInitiated;
		}

		switch (e_AttackState)
		{
			case AttackState.DoNothing:
				break;
			case AttackState.AttackInitiated:
				this.StartAttack();
				break;
			case AttackState.Tracked:
				m_EmergeDelay -= Time.deltaTime;

				if (m_EmergeDelay <= 0.0f)
				{
					this.Attack();
				}

				break;
			case AttackState.Emerged:
				m_EmergedTime -= Time.deltaTime;

				if (m_EmergedTime <= 0.0f)
				{
					this.EndAttack();
				}

				break;
			default:
				break;
		}
	}

	private void StartAttack()
	{
		m_Pillar.TrackPlayer();
		m_Pillar.PlaySplash();
		e_AttackState = AttackState.Tracked;
	}

	private void Attack()
	{
		m_Pillar.e_PillarState = Pillar.PillarState.Emerging;
		m_Pillar.StopSplash();
		e_AttackState = AttackState.Emerged;
	}

	private void EndAttack()
	{
		m_Pillar.PlaySplash();
		m_Pillar.e_PillarState = Pillar.PillarState.Emerged;
		e_AttackState = AttackState.DoNothing;
		this.Reset();
	}

	private void Reset()
	{
		m_EmergeDelay = 1.0f;
		m_EmergedTime = 2.0f;
	}
}

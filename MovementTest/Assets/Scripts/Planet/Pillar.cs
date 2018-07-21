using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour {

    enum PillarState
    {
        Dormint = 0,
        Emerging = 1,
        Emerged = 2
    };

    public Transform m_PlayerPosition;
    public float m_DirectionalOffset;

    public float m_EmergeSpeed;
    public float m_EmergeHeight;

    private Vector3 m_InitialPosition = new Vector3();
    private Quaternion m_InitialDirection = new Quaternion();
    private Vector3 m_PointToDirection = new Vector3();
    private Vector3 m_PillarDestination = new Vector3();
    private PillarState e_PillarState;

    private void Start()
    {
        m_InitialPosition = transform.position;
        m_InitialDirection = transform.rotation;
    }

    // Update is called once per frame
    void Update ()
    {
        if(e_PillarState == PillarState.Dormint)
        {
            if (PlayerController.instance.GetRelativeMoveDirection() != Vector3.zero)
            {
                // m_PointToDirection = m_PlayerPosition.position + (PlayerController.instance.GetRelativeMoveDirection().normalized * m_DirectionalOffset);
                // transform.LookAt(m_PointToDirection);
                m_PillarDestination = transform.position + (transform.forward * m_EmergeHeight);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            e_PillarState = PillarState.Emerging;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.Reset();
        }

        if (e_PillarState == PillarState.Emerging)
        {
            transform.position = Vector3.Lerp(transform.position, m_PillarDestination, m_EmergeSpeed * Time.deltaTime);

            if(transform.position == m_PillarDestination)
            {
                e_PillarState = PillarState.Emerged;
            }
        }
    }

    private void Reset()
    {
        transform.position = m_InitialPosition;
        transform.rotation = m_InitialDirection;
        e_PillarState = PillarState.Dormint;
    }
}

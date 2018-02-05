using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public float m_Speed = 10.0f;
    public float m_IdleSpeed = .5f;
    Vector3 m_ReferenceVector = new Vector3(1, 0, 1);

    void Update()
    {
        Vector3 relativeRotateVector = PlayerController.instance.GetRelativeRight().normalized;

        if(relativeRotateVector == Vector3.zero)
        {
            transform.Rotate(-m_ReferenceVector * m_IdleSpeed, Space.World);
        }
        else
        {
            transform.Rotate(relativeRotateVector * m_Speed, Space.World);
            m_ReferenceVector = relativeRotateVector;
        }
    }
}

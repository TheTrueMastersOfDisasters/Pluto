using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform m_Destination;
    public float m_LerpSpeed = 10f;

    void LateUpdate()
	{
		this.transform.SetPositionAndRotation(Vector3.Lerp(transform.position, m_Destination.position, m_LerpSpeed * Time.deltaTime),
			Quaternion.Slerp(transform.rotation, m_Destination.rotation, m_LerpSpeed * Time.deltaTime));
    }
}

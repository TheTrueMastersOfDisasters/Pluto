using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour {

    public float m_Gravity = -10;

    public void Attract(Transform targetTransform, Rigidbody targetRigidBody)
    {
        Vector3 m_GravityUp = (targetTransform.position - transform.position).normalized;
        Vector3 targetUp = targetTransform.up;

        targetRigidBody.AddForce(m_GravityUp * m_Gravity, ForceMode.Acceleration);

        Quaternion targetRotation = Quaternion.FromToRotation(targetUp, m_GravityUp) * targetTransform.rotation;

        targetTransform.rotation = Quaternion.Slerp(targetTransform.rotation, targetRotation, 50 * Time.deltaTime);
    }
   
}

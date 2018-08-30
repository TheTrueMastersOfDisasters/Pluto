using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTracker : MonoBehaviour {

    public Transform m_Target;
    Vector2 m_NewPosition = new Vector2();


    public float m_XConstraint = 2.0f;
    public float m_YConstraint = 1.0f;

    public bool m_IsLeft;

    private Vector3 m_TargetDirection = new Vector3();

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update ()
    {
        m_TargetDirection = (m_Target.position - transform.position);    

        m_NewPosition = new Vector2(Mathf.Clamp(m_TargetDirection.x, -m_XConstraint, m_XConstraint), Mathf.Clamp(m_TargetDirection.y, -m_YConstraint, m_YConstraint));

        if(m_IsLeft)
        {
            m_NewPosition.x *= -1.0f;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, m_NewPosition, 10 * Time.deltaTime);

        //Debug.DrawLine(transform.position, transform.position + m_TargetDirection, Color.cyan);
        //print(m_NewPosition);
    }
}

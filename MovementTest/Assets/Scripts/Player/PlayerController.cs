using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance;

    public float m_Acceleration = 20;
    public float m_MaxSpeed = 10;
    public float m_IdleOrbitSpeed = 2;
    public float m_JumpSpeed = 35;
	public float m_PoundForce = 10;
    public float m_InitialJumpResistance = 1f;

    public GameObject m_BasePlanet;

    private Rigidbody m_RigidBody;
    private bool m_IsGrounded = false;

    private Vector3 m_MoveDir;
    private Vector3 m_Normal = new Vector3(0,1,0);
    private Vector3 m_HorizontalVelocity = new Vector3();

    private float m_JumpResistance;

	private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_HorizontalVelocity = Vector3.forward * m_Acceleration;
        m_JumpResistance = m_InitialJumpResistance;
    }

    private void FixedUpdate()
    {
        CalculateRelativeNormal();

        Move();

		if (m_IsGrounded)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}
		}
		else
		{
			ApplyCounterForce();

			if (Input.GetKeyDown(KeyCode.Space))
			{
				Pound();
			}
		}

    }

    private void Update()
    { 
        DebugDrawLines();
    }

    private void DebugDrawLines()
    {
        Debug.DrawLine(transform.position, (transform.position + (m_Normal * 2.0f)), Color.green);
        Debug.DrawLine(transform.position, (transform.position + transform.TransformDirection(m_MoveDir) * 2.0f), Color.yellow);
    }

    private void CalculateRelativeNormal()
    {
        m_Normal = (transform.position - m_BasePlanet.transform.position).normalized;
    }

    private void Jump()
    {
        m_RigidBody.velocity += m_JumpSpeed * m_Normal;
        m_IsGrounded = false;
    }

    private void Move()
    {
		m_MoveDir = this.GetInputDirection();

		if (m_MoveDir == Vector3.zero)
        {
           //
        }
        else
        {
            m_HorizontalVelocity = transform.TransformDirection(m_MoveDir).normalized * m_Acceleration;
            m_RigidBody.AddForce(m_HorizontalVelocity, ForceMode.Impulse);

            if (m_IsGrounded)
            {
                if (m_RigidBody.velocity.magnitude >= m_MaxSpeed)
                {
                    m_RigidBody.velocity = m_RigidBody.velocity.normalized * m_MaxSpeed;
                }
            }

            m_HorizontalVelocity = transform.TransformDirection(m_MoveDir);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_IsGrounded = true;
        m_JumpResistance = m_InitialJumpResistance;
    }

    private void OnCollisionExit(Collision collision)
    {

    }

    public bool IsGrounded()
    {
        return m_IsGrounded;
    }

	private Vector3 GetInputDirection()
	{
		if (SystemInfo.deviceType == DeviceType.Desktop)
		{
			m_MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
		}
		else if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			m_MoveDir = new Vector3(Input.acceleration.x, 0.0f, Input.acceleration.z);
		}

		return m_MoveDir;
	}

	private void Pound()
	{
		m_RigidBody.velocity = Vector3.zero;
		m_RigidBody.velocity = -1f * GetRelativeNormal() * m_PoundForce;
	}

	public Vector3 GetRelativeNormal()
    {
        return m_Normal;
    }

    public Vector3 GetRelativeMoveDirection()
    {
        return transform.TransformDirection(m_MoveDir);
    }

    public Vector3 GetRelativeRight()
    {
        return Vector3.Cross(m_Normal, GetRelativeMoveDirection());
    }

    public void ApplyCounterForce()
    {
        m_RigidBody.velocity += m_JumpResistance * -m_Normal;
        m_JumpResistance += .1f;
    }

}

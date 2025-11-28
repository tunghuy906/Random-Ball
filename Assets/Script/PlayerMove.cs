using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float forwardForce = 500f;
	public float lateralForce = 500f;
	public float targetSpeed = 100f;
	public float maxLateralPos = 3f;

	public float jumpForce = 300f;    // Force để nhảy
	public LayerMask groundLayer;     // Layer mặt đất
	public float groundCheckDistance = 0.6f;

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		// Điều khiển trái phải luôn hoạt động
		LateralMovement();

		if (!IsGrounded())
		{
			// Rơi nhanh hơn
			rb.AddForce(Vector3.down * 40f, ForceMode.Acceleration);

			JumpMovement();
		}
		else
		{
			ForwardMovement();
			JumpMovement();
		}
	}

	private void ForwardMovement()
	{
		float currentSpeed = rb.linearVelocity.z;

		if (currentSpeed < targetSpeed)
		{
			rb.AddForce(Vector3.forward * forwardForce * Time.fixedDeltaTime, ForceMode.Force);
		}
		else if (currentSpeed > targetSpeed)
		{
			Vector3 clampedVelocity = rb.linearVelocity;
			clampedVelocity.z = targetSpeed;
			rb.linearVelocity = clampedVelocity;
		}
	}

	void LateralMovement()
	{
		float direction = Input.GetAxis("Horizontal");

		Vector3 v = rb.linearVelocity;
		v.x = direction * lateralForce;
		rb.linearVelocity = v;

		// Clamp X bằng MovePosition thay vì set transform
		Vector3 pos = rb.position;
		pos.x = Mathf.Clamp(pos.x, -maxLateralPos, maxLateralPos);
		rb.MovePosition(pos);
	}

	void JumpMovement()
	{
		if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && IsGrounded())
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	// Check ground bằng Raycast
	bool IsGrounded()
	{
		return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
	}
}

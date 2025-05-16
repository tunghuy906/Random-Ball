using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float forwardForce = 500f;
	public float lateralForce = 500f;
	public float targetSpeed = 100f;
	public float maxLateralPos = 3f;

	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		ForwardMovement();

		LateralMovement();
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

		Vector3 lateralVelocity = rb.linearVelocity;
		lateralVelocity.x = direction * lateralForce;
		rb.linearVelocity = lateralVelocity;

		Vector3 clampedPosition = transform.position;
		clampedPosition.x = Mathf.Clamp(clampedPosition.x, -maxLateralPos, maxLateralPos);
		transform.position = clampedPosition;
	}
}

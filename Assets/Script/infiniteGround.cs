using UnityEngine;

public class infiniteGround : MonoBehaviour
{
	public float groundLenght = 1000f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			transform.parent.position += new Vector3(0, 0, groundLenght * 2);
		}
	}
}

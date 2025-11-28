using UnityEngine;
using TMPro;

public class ProgressController : MonoBehaviour
{
	public Transform player;          // Quả bóng
	public float mapLength = 6500f;   // Chiều dài map
	public TextMeshProUGUI progressText;

	private float startZ;

	void Start()
	{
		startZ = player.position.z;
	}

	void Update()
	{
		float distance = player.position.z - startZ;
		float percent = Mathf.Clamp01(distance / mapLength) * 100f;

		progressText.text = $"{percent:F0}%";
	}
}

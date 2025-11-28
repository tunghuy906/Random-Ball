using UnityEngine;

public class TrapEndGame : MonoBehaviour
{
	public GameObject losePanel;       // UI thua

	private void Start()
	{
		// Ẩn lose panel khi bắt đầu gameplay
		if (losePanel != null)
			losePanel.SetActive(false);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			EndGame();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			EndGame();
		}
	}

	void EndGame()
	{
		// Dừng game
		Time.timeScale = 0f;

		// Hiện UI thua
		if (losePanel != null)
			losePanel.SetActive(true);

		Debug.Log("GAME OVER!");
	}
}

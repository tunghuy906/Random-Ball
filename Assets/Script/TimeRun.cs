using UnityEngine;
using TMPro;

public class RunTimer : MonoBehaviour
{
	public TextMeshProUGUI timeText;   // UI hiển thị thời gian
	public float mapDuration = 90f;    // 90 giây
	private float timer = 0f;

	private bool isFinished = false;

	void Update()
	{
		if (isFinished) return; // nếu đã hết giờ → không chạy nữa

		timer += Time.deltaTime;

		float remaining = Mathf.Clamp(mapDuration - timer, 0, mapDuration);

		int minutes = Mathf.FloorToInt(remaining / 60);
		int seconds = Mathf.FloorToInt(remaining % 60);

		timeText.text = $"{minutes:00}:{seconds:00}";

		// Kiểm tra hết giờ
		if (remaining <= 0f)
		{
			FinishLevel();
		}
	}

	void FinishLevel()
	{
		isFinished = true;

		// Dừng toàn bộ màn chơi
		Time.timeScale = 0f;

		Debug.Log("Level Finished!");

		// Bạn có thể mở UI Win ở đây
		// winPanel.SetActive(true);
	}
}

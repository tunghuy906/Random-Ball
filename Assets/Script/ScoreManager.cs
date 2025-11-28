using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;

	public TextMeshProUGUI txtScore;

	private int score = 0;

	public int distanceMultiplier = 1;

	private Transform player;
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	private void Update()
	{
		UpadateScore();
	}

	private void UpadateScore()
	{
		score = Mathf.FloorToInt(player.position.z +  distanceMultiplier);
		txtScore.text = score.ToString();
		
	}
}

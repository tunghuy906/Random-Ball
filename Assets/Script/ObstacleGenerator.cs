using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
	public GameObject[] coinPrefabs;
	public Transform player;
	public Vector3 spawnPosition;

	public float distanceBetweenCoin = 50f;     // coin thưa hơn
	public float horizonDistance = 200f;

	public float spawnRate = 0.5f;              // 50% khả năng spawn coin

	void Update()
	{
		float distance = Vector3.Distance(player.position, spawnPosition);

		if (distance < horizonDistance)
		{
			// Random lane
			int x = Random.Range(-3, 4);

			// Cập nhật vị trí mới
			spawnPosition = new Vector3(x, 0.6f, spawnPosition.z + distanceBetweenCoin);

			// 50% không spawn → coin tách thưa tự nhiên
			if (Random.value > spawnRate)
				return;

			// Random 1 coin prefab
			GameObject coinPrefab = coinPrefabs[Random.Range(0, coinPrefabs.Length)];

			Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
		}
	}
}

using UnityEngine;

public class CoinManager : MonoBehaviour
{
	public static CoinManager instance;

	private int totalCoins = 0;

	private void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void AddCoin(int amount)
	{
		totalCoins += amount;
		Debug.Log("Coin : " + totalCoins);
	}
}

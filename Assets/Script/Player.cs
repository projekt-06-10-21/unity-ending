
using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	[System.Serializable]
	public class PlayerStats
	{
		public int Zycie = 100;
	}

	public PlayerStats playerStats = new PlayerStats();

	public int fallBoundary = -20;

	void Update()
	{
		if (transform.position.y <= fallBoundary)
			DamagePlayer(999999);
	}

	public void DamagePlayer(int damage)
	{
		playerStats.Zycie -= damage;
		if (playerStats.Zycie <= 0)
		{
			GameMaster.KillPlayer(this);
		}
	}
}
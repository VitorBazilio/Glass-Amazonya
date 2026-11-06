using UnityEngine;

public class EnemyTree : MonoBehaviour
{
	protected PlayerController playerManager;

	protected GameController gameManager;

	private void Update()
	{
		playerManager = Object.FindObjectOfType<PlayerController>();
		gameManager = Object.FindObjectOfType<GameController>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			gameManager.vida--;
		}
	}
}

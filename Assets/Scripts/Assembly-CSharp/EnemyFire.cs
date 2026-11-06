using UnityEngine;

public class EnemyFire : MonoBehaviour
{
	public float velocidadeEnemy;

	protected GameController gameManager;

	private void Start()
	{
		velocidadeEnemy = 2f;
		gameManager = Object.FindObjectOfType<GameController>();
	}

	private void Update()
	{
		if (!gameManager.perdeu && gameManager.TimeGame <= 6f)
		{
			if (base.transform.position.y <= 4f)
			{
				fogoMata();
			}
			else
			{
				gameManager.Derrota();
			}
		}
	}

	public void fogoMata()
	{
		base.transform.Translate(Vector3.up * Time.deltaTime * velocidadeEnemy);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Object.Destroy(other.gameObject);
	}

	public void apaga()
	{
		Object.Destroy(base.gameObject);
	}
}

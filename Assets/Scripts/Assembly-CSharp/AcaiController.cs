using UnityEngine;

public class AcaiController : MonoBehaviour
{
	protected GameController gameManager;

	protected virtual void Start()
	{
		gameManager = Object.FindObjectOfType<GameController>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Object.FindObjectOfType<SaveScript>().SalvarColeta();
			gameManager.venceu = true;
			Object.Destroy(base.gameObject);
		}
	}
}

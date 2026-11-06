using UnityEngine;
using UnityEngine.SceneManagement;

public class ColetaScript : MonoBehaviour
{
	public int id;

	private void Start()
	{
		if (SceneManager.GetActiveScene().name != "Coletaveis" && Object.FindObjectOfType<SaveScript>().coletaveis[id])
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Object.FindObjectOfType<SaveScript>().Coletada(id);
			Object.Destroy(base.gameObject);
		}
	}
}

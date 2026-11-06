using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public int vida = 1;

	protected GameController gameManager;

	public float velocidadePerso;

	public static Transform _playerTransform;

	public Rigidbody2D rb;

	public Transform movex;

	public GameObject Explosao;

	public GameObject dano;

	public bool andando;

	public Animator AndandoAve;

	protected virtual void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		_playerTransform = base.transform;
		gameManager = Object.FindObjectOfType<GameController>();
		Time.timeScale = 1f;
	}

	private void Movimento()
	{
		if (Input.GetKey(KeyCode.Keypad1))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[0].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Keypad2))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[1].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Keypad3))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[2].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Keypad4))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[3].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Keypad5))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[4].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Keypad6))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[5].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Keypad7))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[6].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Keypad8))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[7].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Keypad9))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[8].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Keypad0))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.playerSpawnT.position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha1))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[0].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha2))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[1].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha3))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[2].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha4))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[3].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha5))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[4].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha6))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[5].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha7))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[6].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha8))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[7].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha9))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.locaisTransform[8].position, velocidadePerso * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Alpha0))
		{
			base.transform.position = Vector3.Lerp(base.transform.position, gameManager.playerSpawnT.position, velocidadePerso * Time.deltaTime);
		}
	}

	private void Update()
	{
		Movimento();
		if (vida <= 0)
		{
			gameManager.perdeu = true;
			Object.Destroy(base.gameObject);
			gameManager.Derrota();
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			GameController._instance.vida--;
			Object.Instantiate(dano, base.transform.position, Quaternion.identity);
		}
		if (other.gameObject.tag == "Plataforma")
		{
			andando = true;
			AndandoAve.SetBool("Andando", value: true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Plataforma")
		{
			andando = false;
			AndandoAve.SetBool("Andando", value: false);
		}
	}

	public void Morte()
	{
		Object.Destroy(base.gameObject);
	}
}

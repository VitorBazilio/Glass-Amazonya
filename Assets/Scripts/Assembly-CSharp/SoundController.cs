using UnityEngine;

public class SoundController : MonoBehaviour
{
	public static SoundController _instance;

	public AudioSource audioSource;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			_instance = this;
		}
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}

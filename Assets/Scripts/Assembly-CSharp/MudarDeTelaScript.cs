using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarDeTelaScript : MonoBehaviour
{
	public int level;

	public int tempo;

	private void Start()
	{
		Mudar();
	}

	private void Update()
	{
	}

	private IEnumerator Mudar()
	{
		yield return new WaitForSeconds(tempo);
		SceneManager.LoadScene(level);
	}
}

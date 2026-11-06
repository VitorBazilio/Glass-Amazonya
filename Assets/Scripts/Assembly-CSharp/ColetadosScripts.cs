using UnityEngine;

public class ColetadosScripts : MonoBehaviour
{
	private SaveScript saveScript;

	public ColetaveisScriptableObject coletaveisSO;

	public GameObject[] objetos;

	private void Start()
	{
		saveScript = Object.FindObjectOfType<SaveScript>();
		int num = 0;
		for (int i = 0; i < saveScript.coletaveis.Length; i++)
		{
			if (saveScript.coletaveis[i])
			{
				objetos[num].AddComponent<SpriteRenderer>();
				objetos[num].AddComponent<Animator>().runtimeAnimatorController = coletaveisSO.coletaveis[i].objeto;
				num++;
			}
		}
	}
}

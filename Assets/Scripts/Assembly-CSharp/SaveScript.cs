using System;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
	public static SaveScript _instance;

	public ColetaveisScriptableObject coletaveisSO;

	public bool[] coletaveis;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			_instance = this;
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		CarregaColetados();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Coletada(int id)
	{
		coletaveis[id] = true;
	}

	public void SalvarColeta()
	{
		for (int i = 0; i < coletaveis.Length; i++)
		{
			PlayerPrefs.SetString("ColetavelSalvo" + i, coletaveis[i].ToString());
		}
	}

	public void CarregaColetados()
	{
		coletaveis = new bool[coletaveisSO.coletaveis.Length];
		for (int i = 0; i < coletaveis.Length; i++)
		{
			string text = PlayerPrefs.GetString("ColetavelSalvo" + i);
			if (text != "")
			{
				coletaveis[i] = Convert.ToBoolean(text);
			}
		}
	}
}

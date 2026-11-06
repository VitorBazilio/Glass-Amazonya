using UnityEngine;

public class LanguageManager : MonoBehaviour
{
	public static Language currentLanguage;

	public GameObject[] eng;

	public GameObject[] port;

	private void Awake()
	{
		GetLanguage();
		if (currentLanguage == Language.Portuguese)
		{
			for (int i = 0; i < port.Length; i++)
			{
				port[i].SetActive(value: true);
			}
			for (int j = 0; j < eng.Length; j++)
			{
				eng[j].SetActive(value: false);
			}
		}
		else
		{
			for (int k = 0; k < port.Length; k++)
			{
				port[k].SetActive(value: false);
			}
			for (int l = 0; l < eng.Length; l++)
			{
				eng[l].SetActive(value: true);
			}
		}
	}

	public void ChangeLanguage(Language newLang)
	{
		currentLanguage = newLang;
		PlayerPrefs.SetString("CurrentLanguage", newLang.ToString());
		TranslatableText[] array = Object.FindObjectsOfType<TranslatableText>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UpdateLanguage(newLang);
		}
	}

	private void GetLanguage()
	{
		string text = PlayerPrefs.GetString("CurrentLanguage", "Portuguese");
		if (text != null && text == "Portuguese")
		{
			currentLanguage = Language.Portuguese;
		}
		else
		{
			currentLanguage = Language.English;
		}
	}

	public void SwitchLanguage()
	{
		if (currentLanguage == Language.Portuguese)
		{
			currentLanguage = Language.English;
		}
		else
		{
			currentLanguage = Language.Portuguese;
		}
		ChangeLanguage(currentLanguage);
	}

	public void SetEnglish()
	{
		ChangeLanguage(Language.English);
	}

	public void SetPortuguese()
	{
		ChangeLanguage(Language.Portuguese);
	}
}

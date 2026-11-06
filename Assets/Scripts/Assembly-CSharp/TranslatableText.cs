using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class TranslatableText : MonoBehaviour
{
	public string portuguese;

	public string english;

	private void OnEnable()
	{
		UpdateLanguage(LanguageManager.currentLanguage);
	}

	private void Start()
	{
		if (GetComponent<Text>() != null)
		{
			UpdateLanguage(LanguageManager.currentLanguage);
		}
	}

	public void UpdateLanguage(Language newLanguage)
	{
		if (portuguese != "" || english != "")
		{
			if (newLanguage == Language.Portuguese)
			{
				GetComponent<Text>().text = portuguese;
			}
			else
			{
				GetComponent<Text>().text = english;
			}
		}
	}
}

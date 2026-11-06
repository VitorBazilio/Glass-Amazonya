using UnityEngine;

public class SoundEffects : MonoBehaviour
{
	private AudioSource audioSource;

	public float volume;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
		volume = PlayerPrefs.GetFloat("Volume", 0.5f);
		audioSource.volume = volume;
	}

	public void SetVolume(float newVol)
	{
		volume = newVol;
		audioSource.volume = volume;
		PlayerPrefs.SetFloat("Volume", volume);
	}

	private void OnEnable()
	{
		ChangeSoundVolume.OnVolumeChanged += SetVolume;
	}

	private void OnDisable()
	{
		ChangeSoundVolume.OnVolumeChanged -= SetVolume;
	}
}

using System;
using UnityEngine;

public class ChangeSoundVolume : MonoBehaviour
{
	public static event Action<float> OnVolumeChanged;

	public void ChangeVolume(float newVolume)
	{
		OnVolumeChanged?.Invoke(newVolume);
	}
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Adapta camera e UI ao monitor do jogador (qualquer resolucao/proporcao).
// Inicia sozinho (nao precisa ser colocado em cena) e reaplica ao trocar de cena
// e ao redimensionar a janela.
public class ScreenAdapter : MonoBehaviour
{
	// Proporcao para a qual o jogo foi desenhado (800x600 = 4:3).
	private const float ReferenceAspect = 800f / 600f;

	private static ScreenAdapter instance;

	private readonly Dictionary<int, float> baseOrthoSize = new Dictionary<int, float>();

	private int lastWidth;

	private int lastHeight;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Init()
	{
		if (instance == null)
		{
			GameObject gameObject = new GameObject("ScreenAdapter");
			instance = gameObject.AddComponent<ScreenAdapter>();
			Object.DontDestroyOnLoad(gameObject);
		}
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		baseOrthoSize.Clear();
		Apply();
	}

	private void Update()
	{
		if (Screen.width != lastWidth || Screen.height != lastHeight)
		{
			Apply();
		}
	}

	private void Apply()
	{
		lastWidth = Screen.width;
		lastHeight = Screen.height;
		if (lastWidth <= 0 || lastHeight <= 0)
		{
			return;
		}
		float aspect = (float)lastWidth / lastHeight;

		// Camera: mantem a altura do cenario; se a tela for mais estreita que 4:3,
		// aumenta a altura para nao cortar as laterais. Em telas largas aparece mais cenario.
		Camera[] cameras = Camera.allCameras;
		foreach (Camera camera in cameras)
		{
			if (!camera.orthographic)
			{
				continue;
			}
			int id = camera.GetInstanceID();
			if (!baseOrthoSize.ContainsKey(id))
			{
				baseOrthoSize[id] = camera.orthographicSize;
			}
			camera.rect = new Rect(0f, 0f, 1f, 1f);
			camera.orthographicSize = baseOrthoSize[id] * Mathf.Max(1f, ReferenceAspect / aspect);
		}

		// UI: todo Canvas escala pela altura da tela, a partir de 800x600.
		CanvasScaler[] scalers = Object.FindObjectsOfType<CanvasScaler>(true);
		foreach (CanvasScaler scaler in scalers)
		{
			scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			scaler.referenceResolution = new Vector2(800f, 600f);
			scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
			scaler.matchWidthOrHeight = aspect >= ReferenceAspect ? 1f : 0f;
		}
	}
}

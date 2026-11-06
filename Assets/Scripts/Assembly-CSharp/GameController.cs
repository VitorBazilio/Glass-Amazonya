using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Transform playerSpawnT;

	public Transform finalFase;

	public Transform[] locaisTransform;

	public static GameController _instance;

	public bool jogoComecou;

	protected GameController gc;

	public bool pause;

	public bool venceu;

	public bool perdeu;

	public int pontosgame;

	public float TimeGame = 30f;

	protected PlayerController playerController;

	protected EnemyFire enemyManager;

	public LevelManager levelManager;

	public Text TextTempo;

	public int vida = 1;

	public float velocidade = 1.5f;

	public Transform FimDeFase;

	public Animator PainelPausado;

	public Animator PainelVitoria;

	public Animator PainelDerrota;

	private void Awake()
	{
		SceneManager.sceneLoaded += Carrega;
	}

	private void Carrega(Scene cena, LoadSceneMode modo)
	{
		playerController = Object.FindObjectOfType<PlayerController>();
		enemyManager = Object.FindObjectOfType<EnemyFire>();
		gc = Object.FindObjectOfType<GameController>();
		gc = this;
		StartGame();
	}

	private void Start()
	{
		pause = false;
		perdeu = false;
		venceu = false;
		StartGame();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		playerController.vida = vida;
		playerController.velocidadePerso = velocidade;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Pausar();
		}
		if (TimeGame > 0f)
		{
			TimeGame -= Time.deltaTime;
		}
		else
		{
			TextTempo.enabled = false;
			playerController.velocidadePerso = 0f;
		}
		TextTempo = GameObject.FindGameObjectWithTag("TimeGame").GetComponent<Text>();
		TextTempo.text = Mathf.Round(TimeGame).ToString();
		if (venceu)
		{
			TextTempo.enabled = false;
			Vitoria();
		}
		if (!perdeu && TimeGame <= 0f)
		{
			TextTempo.enabled = false;
		}
		if (playerController.vida <= 0 && !perdeu && TimeGame <= 0f)
		{
			TextTempo.enabled = false;
		}
	}

	public void Pausar()
	{
		pause = !pause;
		if (pause)
		{
			Time.timeScale = 0f;
			PauseGame(acao: true);
		}
		else
		{
			PauseGame(acao: false);
			Time.timeScale = 1f;
		}
	}

	private void StartGame()
	{
		jogoComecou = true;
		playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	public void PauseGame(bool acao)
	{
		if (acao)
		{
			MonoBehaviour.print("jogo pausado, vem o painel");
			playerController.velocidadePerso = 0f;
			PainelPausado.SetBool("pause", value: true);
			TextTempo.enabled = false;
		}
		else
		{
			MonoBehaviour.print("jogo despausado, some o painel");
			playerController.velocidadePerso = 0f;
			PainelPausado.SetBool("pause", value: false);
			TextTempo.enabled = true;
		}
	}

	public void Vitoria()
	{
		MonoBehaviour.print("venceu");
		Time.timeScale = 0f;
		TextTempo.enabled = false;
		PainelVitoria.SetBool("venceu", value: true);
	}

	public void Derrota()
	{
		playerController.velocidadePerso = 0f;
		perdeu = true;
		TextTempo.enabled = false;
		MonoBehaviour.print("perdeu, sobe o painel");
		PainelDerrota.SetBool("perdeu", value: true);
		Time.timeScale = 0f;
		playerController.Morte();
	}

	public void FecharJogo()
	{
		Application.Quit();
		MonoBehaviour.print("jogo fechado");
	}
}

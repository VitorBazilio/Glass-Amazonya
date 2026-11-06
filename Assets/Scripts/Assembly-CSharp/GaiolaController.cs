using UnityEngine;

public class GaiolaController : MonoBehaviour
{
	protected AveController aveManager;

	public Sprite sprite1;

	public Sprite sprite2;

	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		_ = spriteRenderer.sprite == sprite2;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			spriteRenderer.sprite = sprite2;
		}
	}
}

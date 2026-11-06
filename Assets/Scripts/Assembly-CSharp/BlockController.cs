using UnityEngine;

public class BlockController : MonoBehaviour
{
	public ButtonController buttonController;

	private void Start()
	{
	}

	private void Update()
	{
		if (buttonController.Button == 1)
		{
			Object.Destroy(base.gameObject);
		}
	}
}

using UnityEngine;

public class ButtonController : MonoBehaviour
{
	public int Button;

	private void Update()
	{
		if (Button == 1)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			Button = 1;
		}
	}
}

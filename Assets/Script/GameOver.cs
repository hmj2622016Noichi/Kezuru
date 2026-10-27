using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	private bool isGameOver = false;

	private void OnTriggerEnter(Collider other)
	{
		if (isGameOver) return;

		if (other.CompareTag("ammo"))
		{
			isGameOver = true;

			SceneManager.LoadScene("GameOver");
		}
	}
}
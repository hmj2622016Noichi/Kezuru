using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class Move : MonoBehaviour
{
	public float moveSpeed = 5f;
	public GameObject prefab;
	public Transform shootPoint;
	public float shootSpeed = 20f;

	bool isGameOver = false;

	void Update()
	{
		if (isGameOver) return;

		Vector3 move = Vector3.zero;

		if (Keyboard.current.wKey.isPressed) move.z = 1;
		if (Keyboard.current.sKey.isPressed) move.z = -1;
		if (Keyboard.current.dKey.isPressed) move.x = 1;
		if (Keyboard.current.aKey.isPressed) move.x = -1;

		transform.position += move.normalized * moveSpeed * Time.deltaTime;

		if (Keyboard.current.eKey.wasPressedThisFrame)
		{
			if (prefab != null && shootPoint != null)
			{
				GameObject bullet = Instantiate(prefab,shootPoint.position,shootPoint.rotation);

				Rigidbody rb = bullet.GetComponent<Rigidbody>();

				if (rb != null)
				{
					rb.linearVelocity = shootPoint.forward * shootSpeed;
				}
			}
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("ammo"))
		{
			if (isGameOver) return;

			isGameOver = true;
			StartCoroutine(LoadGameOver());
		}
	}

	IEnumerator LoadGameOver()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("GameOver");
	}
}
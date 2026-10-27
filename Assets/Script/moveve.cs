using UnityEngine;
using UnityEngine.InputSystem;
public class Move : MonoBehaviour
{
	public GameObject prefab;
	public Transform shootPoint;
	public float moveSpeed  = 5f;
	public float shootSpeed = 20f;
	public class ObjectDestroy : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("ammo"))
			{
				Destroy(gameObject);
			}
		}
	}
	void Update()
	{
		Vector3 move = Vector3.zero;
		//ˆÚ“®
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
}
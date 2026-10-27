using UnityEngine;
using System.Collections;

public class ObjectDestroy : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform firePoint;
	public float bulletSpeed = 20f;

	private bool isDestroyed = false;

	private void Start()
	{
		StartCoroutine(AutoFire());
	}

	private IEnumerator AutoFire()
	{
		while (true)
		{
			Fire();

			int interval = Random.Range(2, 4);
			yield return new WaitForSeconds(interval);
		}
	}

	private void Fire()
	{
		if (bulletPrefab == null || firePoint == null)
			return;

		GameObject bullet = Instantiate(
			bulletPrefab,
			firePoint.position,
			firePoint.rotation
		);

		Rigidbody rb = bullet.GetComponent<Rigidbody>();

		if (rb != null)
		{
			rb.linearVelocity = firePoint.forward * bulletSpeed;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (isDestroyed) return;

		if (other.CompareTag("ammo"))
		{
			isDestroyed = true;

			if (KillCounter.Instance != null)
			{
				KillCounter.Instance.AddKill();
			}

			Destroy(gameObject);
		}
	}
}
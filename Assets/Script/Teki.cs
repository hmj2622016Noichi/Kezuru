using UnityEngine;
using System.Collections;

public class Ammo : MonoBehaviour
{
	public GameObject bulletPrefab;
	public Transform firePoint;
	public float bulletSpeed = 20f;
	private bool isDestroyed = false;
	private void Start()
	{
		StartCoroutine(AutoFire());
	}
	//ランダム発射
	private IEnumerator AutoFire()
	{
		while (true)
		{
			Fire();
			int interval = Random.Range(2, 4);
			yield return new WaitForSeconds(interval);
		}
	}
	//弾薬生成.発射
	private void Fire()
	{
		if (bulletPrefab == null || firePoint == null)return;
		GameObject bullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
		Rigidbody rb = bullet.GetComponent<Rigidbody>();

		if (rb != null)
		{
			rb.linearVelocity = firePoint.forward * bulletSpeed;
		}
	}
	//ammotagに当たるとカウント+1
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
			//さくじょ
			Destroy(gameObject);
		}
	}
}
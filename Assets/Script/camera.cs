using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
	public Transform player;
	public float distance = 7f;
	public float height = 3f;
	public float mouseSensitivity = 3f;

	float mouseX;
	float mouseY = 15f;

	void Start()
	{
		Vector3 angles = transform.eulerAngles;
		mouseX = angles.y;
		mouseY = angles.x;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void LateUpdate()
	{
		if (player == null || Mouse.current == null) return;

		Vector2 mouseDelta = Mouse.current.delta.ReadValue();

		mouseX += mouseDelta.x * mouseSensitivity * Time.deltaTime;
		mouseY -= mouseDelta.y * mouseSensitivity * Time.deltaTime;
		mouseY = Mathf.Clamp(mouseY, -20f, 70f);

		Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0f);

		Vector3 offset = rotation * new Vector3(0f, 0f, -distance);
		transform.position = player.position + Vector3.up * height + offset;

		transform.LookAt(player.position + Vector3.up * height);
	}

	void OnDisable()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
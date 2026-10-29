using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
	public Vector3 clearPosition = new Vector3(0, 0, 10);
	public float distance = 1f;
	//ÉNÉäÉA
	void Update()
	{
		if (Vector3.Distance(transform.position, clearPosition) < distance)
		{
			SceneManager.LoadScene("ClearScene");
		}
	}
}
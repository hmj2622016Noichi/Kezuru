using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
//3ïbå„Ç…ÉQÅ[ÉÄÇ…ñﬂÇÈ
public class GameOverTimer : MonoBehaviour
{
	private void Start()
	{
		StartCoroutine(GoToGameScene());
	}

	private IEnumerator GoToGameScene()
	{
		yield return new WaitForSecondsRealtime(3f);

		SceneManager.LoadScene("GameScene");
	}
}
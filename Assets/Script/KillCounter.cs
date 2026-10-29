using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
	public static KillCounter Instance;
	private int killCount = 0;
	public TMP_Text countText;
	private void Awake()
	{
		Instance = this;
		UpdateText();
	}
	//+1
	public void AddKill()
	{
		killCount++;
		UpdateText();
	}
	//çÌÇÈ
	private void UpdateText()
	{
		if (countText != null)
		{
			countText.text = "Sennryoku okezutta: " + killCount;
		}
	}
}
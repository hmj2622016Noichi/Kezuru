using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
	public static KillCounter Instance;

	public TMP_Text countText;
	private int killCount = 0;

	private void Awake()
	{
		Instance = this;
		UpdateText();
	}

	public void AddKill()
	{
		killCount++;
		UpdateText();
	}

	private void UpdateText()
	{
		if (countText != null)
		{
			countText.text = "Sennryoku okezutta: " + killCount;
		}
	}
}
using UnityEngine;

public class GoToOpeningScene : MonoBehaviour
{
	public void MoveScene()
	{
		Invoke("StopSE", 0.5f);
		TitleScene.Instance.LoadScene("OpeningScene");
	}

	public void StopSE()
	{
		AudioManager.Instance.StopSE("s-15_se");
	}
}

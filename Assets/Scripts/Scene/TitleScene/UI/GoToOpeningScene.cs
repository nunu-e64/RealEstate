using UnityEngine;

public class GoToOpeningScene : MonoBehaviour
{
	public void MoveScene()
	{
		TitleScene.Instance.LoadScene("OpeningScene");
	}
}

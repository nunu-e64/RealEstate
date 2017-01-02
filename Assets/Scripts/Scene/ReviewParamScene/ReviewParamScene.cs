using UnityEngine;

public class ReviewParamScene : BaseScene<ReviewParamScene>
{
	public UIEvent uiEvent;

	protected override void Initialize()
	{
		uiEvent.Run(0);
		AudioManager.Instance.StopBGM();
	}

	protected override void OnFadeInFinished()
	{
		uiEvent.Run(1);
	}

	protected override void OnFadeOutFinished()
	{

	}

	public void MoveScene()
	{
		LoadScene("EndingScene");
	}
}

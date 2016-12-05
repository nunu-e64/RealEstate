using UnityEngine;

public class ReviewScene : BaseScene<ReviewScene>
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
		AudioManager.Instance.PlaySE2("s-17_se");
	}

	protected override void OnFadeOutFinished()
	{

	}
}

using UnityEngine;

public class StillScene : BaseScene<StillScene>
{
	public UIEvent uiEvent;

	protected override void Initialize()
	{
		uiEvent.Run(0);
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
		LoadScene("ReviewParamScene");
	}
}

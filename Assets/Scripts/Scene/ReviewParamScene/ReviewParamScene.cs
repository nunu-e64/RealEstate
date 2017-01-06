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
		Global.Grade grade = GameDataManager.Instance.GetGrade();
		if (grade == Global.Grade.A) {
			LoadScene(Global.STILL_SCENE);
		} else {
			LoadScene(Global.TITLE_SCENE);
		}
	}
}

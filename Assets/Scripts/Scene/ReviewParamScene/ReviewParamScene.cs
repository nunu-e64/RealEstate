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
		Global.Grade grade = Global.GRADE_KVS[UserDataManager.Instance.PlayCount % Global.MAX_ALIEN][GameDataManager.Instance.HouseIndex];
		if (grade == Global.Grade.A) {
			LoadScene(Global.ENDING_SCENE);
		} else {
			LoadScene(Global.TITLE_SCENE);
		}
	}
}

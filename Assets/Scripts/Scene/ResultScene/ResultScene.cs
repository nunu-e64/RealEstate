using UnityEngine;

public class ResultScene : BaseScene<ResultScene>
{
	public UIEvent uiEvent;

	protected override void Initialize()
	{
		uiEvent.Run(0);
		AudioManager.Instance.PlayBGM("s-7_bgm");
	}

	protected override void OnFadeInFinished()
	{
		uiEvent.Run(1);
	}

	protected override void OnFadeOutFinished()
	{
		Debug.Log("フェードアウト終了");
	}

	public void MoveScene()
	{
		LoadScene(Global.REVIEW_SCENE);
	}
}

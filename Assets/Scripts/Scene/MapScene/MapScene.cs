using UnityEngine;

public class MapScene : BaseScene<MapScene>
{
	protected override void Initialize()
	{
		Debug.Log("初期化");
		AudioManager.Instance.PlayBGM("s-7_bgm");
	}

	protected override void OnFadeInFinished()
	{
		Debug.Log("フェードイン終了");
		this.GetComponent<MapUIController>().UnlockButton();
	}

	protected override void OnFadeOutFinished()
	{
		Debug.Log("フェードアウト終了");
	}

	public void GoToNextScene()
	{
		if (!IsFadeInFinished) {
			return;
		}
		GameDataManager.Instance.HouseIndex = 0;
		LoadScene(Global.RESULT_SCENE);
	}
}

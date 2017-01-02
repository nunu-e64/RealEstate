using UnityEngine;

public class LevelUpScene : BaseScene<EndingScene>
{
	private bool isSePlaying = false;

	protected override void Initialize()
	{
		Debug.Log("初期化");
		UserDataManager.Instance.Count();
		UserDataManager.Instance.Save();
		AudioManager.Instance.PlayBGM("s-19_bgm");
	}

	protected override void OnFadeInFinished()
	{
		Debug.Log("フェードイン終了");
	}

	protected override void OnFadeOutFinished()
	{
		Debug.Log("フェードアウト終了");
	}

	private void Update()
	{
		if (!IsFadeInFinished) {
			return;
		}

		// DEBUG
		if (Input.GetMouseButton(0)) {
			GoNextScene();
		}
	}

	public void GoNextScene()
	{
		LoadScene(Global.TITLE_SCENE);
		if (!isSePlaying) {
			AudioManager.Instance.PlaySE2("s-3_se");
			isSePlaying = true;
		}
	}
}

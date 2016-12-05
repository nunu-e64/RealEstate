using UnityEngine;

public class OpeningScene : BaseScene<OpeningScene>
{
	protected override void Initialize()
	{
		Debug.Log("初期化");
		AudioManager.Instance.PlayBGM("s-4_bgm");
	}

	protected override void OnFadeInFinished()
	{
		Debug.Log("フェードイン終了");
		this.GetComponent<OpeningUIController>().ShowOpening();
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
	}
}

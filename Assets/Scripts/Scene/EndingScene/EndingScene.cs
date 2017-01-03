using UnityEngine;

public class EndingScene : BaseScene<EndingScene>
{
	private bool canGoNext = false;

	protected override void Initialize()
	{
		Debug.Log("初期化");
		AudioManager.Instance.PlayBGM("s-19_bgm");
	}

	protected override void OnFadeInFinished()
	{
		Debug.Log("フェードイン終了");
		this.GetComponent<EndingUIController>().ShowContent();
	}

	protected override void OnFadeOutFinished()
	{
		Debug.Log("フェードアウト終了");
	}

	private void Update()
	{
		if (!IsFadeInFinished || !canGoNext) {
			return;
		}
		if (Input.GetMouseButtonDown(0)) {
			LoadScene(Global.TITLE_SCENE);
		}
	}

	public void OnFinishAnimation()
	{
		canGoNext = true;
	}
}

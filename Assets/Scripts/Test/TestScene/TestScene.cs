using UnityEngine;

public class TestScene : BaseScene<TitleScene>
{
	protected override void Initialize()
	{
		Debug.Log("初期化");
	}

	protected override void OnFadeInFinished()
	{
		Debug.Log("フェードイン終了");
		var controller = GameObject.FindObjectOfType<TestUIController>() as TestUIController;
		controller.ShowPanel1();
	}

	protected override void OnFadeOutFinished()
	{
		Debug.Log("フェードアウト終了");
	}
}

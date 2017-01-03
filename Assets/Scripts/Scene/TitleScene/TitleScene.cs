using UnityEngine;

public class TitleScene : BaseScene<TitleScene>
{
	protected override void Initialize()
	{
		AudioManager.Instance.PlayBGM("s-1_bgm");
	}

	protected override void OnFadeInFinished()
	{

	}

	protected override void OnFadeOutFinished()
	{

	}

	public void SkipToMapScene()
	{
		LoadScene(Global.MAP_SCENE);
	}
}

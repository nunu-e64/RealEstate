using UnityEngine;

public class StillScene : BaseScene<StillScene>
{
	public UIEvent uiEvent;
	[SerializeField] private UnityEngine.UI.Image still;

	protected override void Initialize()
	{
		still.sprite = GameDataManager.Instance.CharacterStill;
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
		LoadScene(Global.REVIEW_PARAM_SCENE);
	}
}

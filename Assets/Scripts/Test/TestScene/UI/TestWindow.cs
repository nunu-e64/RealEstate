using UnityEngine;
using System.Collections;

public class TestWindow : BaseWindow
{
	[SerializeField]
	private BaseButton button;

	public void Start()
	{
		if (button == null) {
			Debug.LogError("button is null");
		}
		button.SetClickableAgain();
	}

	public void SetButtonCallback(BaseButton.OnClickedCallback callback)
	{
		button.SetClickCallback(callback);
	}
}

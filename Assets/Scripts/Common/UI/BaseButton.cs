using UnityEngine;
using System.Collections;

public class BaseButton : BaseUI
{
	public delegate void OnClickedCallback();

	private OnClickedCallback onClickedCallback;
	private bool hasClicked;
	private bool canClickAgain;

	public void Start()
	{
		IsLocked = true;
		Initialize();
	}

	public virtual void Initialize()
	{
	}

	public void SetClickCallback(OnClickedCallback callback)
	{
		onClickedCallback = callback;
	}

	public void OnClicked()
	{
		if ((!canClickAgain && hasClicked) || IsLocked) {
			return;
		}
		hasClicked = true;
		if (onClickedCallback != null) {
			onClickedCallback();
		}
	}

	public void SetClickableAgain()
	{
		canClickAgain = true;
	}
}

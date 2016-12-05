using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class BaseWindow : BaseUI
{
	public delegate void OnShowFinishedCallback();

	public delegate void OnDismissFinishedCallback();

	private OnShowFinishedCallback onShowFinishedCallback;
	private OnDismissFinishedCallback onDismissFinishedCallback;

	private const string SHOW_ANIMATION_STATE = "Show";
	private const string DISMISS_ANIMATION_STATE = "Dismiss";

	protected bool isShowning;
	protected bool isDimissing;

	public virtual void Show()
	{
		UpdateStateShow();
		GetComponent<Animator>().Play(SHOW_ANIMATION_STATE);
	}

	protected void UpdateStateShow()
	{
		if (isShowning || IsLocked) {
			return;
		}
		gameObject.SetActive(true);
		isShowning = true;
		IsLocked = true;
	}

	public virtual void Dismiss()
	{
		UpdateStateDismiss();
		GetComponent<Animator>().Play(DISMISS_ANIMATION_STATE);
	}

	protected void UpdateStateDismiss()
	{
		if (isDimissing || IsLocked) {
			return;
		}
		isDimissing = true;
		IsLocked = true;
	}

	public void OnShowFinished()
	{
		Debug.Log("Window Showed");
		isShowning = false;
		IsLocked = false;
		if (onShowFinishedCallback != null) {
			onShowFinishedCallback();
		}
	}

	public void OnDismissFinished()
	{
		Debug.Log("Window Dimissed");
		isDimissing = false;
		IsLocked = false;
		if (onDismissFinishedCallback != null) {
			onDismissFinishedCallback();
		}
		gameObject.SetActive(false);
	}

	public void SetShowFinishedCallback(OnShowFinishedCallback callback)
	{
		onShowFinishedCallback = callback;
	}

	public void SetDismissFinishedCallback(OnDismissFinishedCallback callback)
	{
		onDismissFinishedCallback = callback;
	}
}

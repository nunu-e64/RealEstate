using UnityEngine;
using System.Collections;

public class BalloonWindow : BaseWindow
{
	public override void Show()
	{
		UpdateStateShow();
		iTween.ScaleFrom(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f, "easetype", "easeOutBack", "oncomplete", "OnShowFinished"));
	}

	public override void Dismiss()
	{
		UpdateStateDismiss();
		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f, "easetype", "easeOutQuad", "oncomplete", "OnDismissFinished"));
	}
}

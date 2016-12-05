using UnityEngine;
using System.Collections;

public class MapWindow : BaseWindow
{

	public override void Show()
	{
		UpdateStateShow();
		this.transform.localScale = Vector3.zero;
		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.one, "time", 0.5f, "easetype", "easeOutBack", "oncomplete", "OnShowFinished"));
	}

	public override void Dismiss()
	{
		UpdateStateDismiss();
		iTween.ScaleTo(gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f, "easetype", "easeInBack", "oncomplete", "OnDismissFinished"));
	}

}

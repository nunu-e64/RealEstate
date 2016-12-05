using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BaseUI : MonoBehaviour
{
	protected bool isLocked;
	protected List<BaseUI> baseUIChildren;

	public virtual bool IsLocked {
		get {
			return isLocked;
		}
		set {
			isLocked = value;
			foreach (var item in baseUIChildren) {
				item.IsLocked = value;
			}
		}
	}

	public virtual void Awake()
	{
		baseUIChildren = new List<BaseUI>();
		foreach (Transform child in transform) {
			var baseUI = child.GetComponent<BaseUI>();
			if (baseUI != null) {
				baseUIChildren.Add(baseUI);
			}
		}
	}
}

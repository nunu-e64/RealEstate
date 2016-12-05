using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CommonButton : BaseButton
{
	public override bool IsLocked {
		get {
			return isLocked;
		}
		set {
			isLocked = value;
			this.GetComponent<Button>().interactable = !value;
			foreach (var item in baseUIChildren) {
				item.IsLocked = value;
			}
		}
	}

	public override void Initialize()
	{
		var button = this.GetComponent<Button>();
		button.onClick.AddListener(OnClicked);
		IsLocked = false;
		SetClickableAgain();
	}
}

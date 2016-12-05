using UnityEngine;
using System.Collections;

public class TestUIController : BaseUIController
{
	[SerializeField]
	private TestWindow[] testWindows;

	private bool window1visible;

	void Start()
	{
		if (testWindows.Length != 4) {
			Debug.LogErrorFormat("TestUIController must have 4 windows, but actual {0}", testWindows.Length);
		}
		foreach (var window in testWindows) {
			if (window == null) {
				Debug.LogError("TestUIController must not have a null window");
			}
			window.gameObject.SetActive(false);
		}
	}

	public void ShowPanel1()
	{
		testWindows[0].SetButtonCallback(() => {
			Debug.Log("Clicked 1");
			ShowPanel2();
		});
		testWindows[0].SetShowFinishedCallback(() => {
			Debug.Log("Finished showing Panel1");
			window1visible = true;
		});

		testWindows[0].Show();
	}

	public void ShowPanel2()
	{
		testWindows[1].SetButtonCallback(() => {
			Debug.Log("Click 2");
			if (window1visible) {
				testWindows[0].Dismiss();
			} else {
				testWindows[0].Show();
			}
		});
		testWindows[0].SetDismissFinishedCallback(() => {
			Debug.Log("Finished dismissing Panel1");
			window1visible = false;
		});

		testWindows[1].Show();
	}
}
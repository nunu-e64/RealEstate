using UnityEngine;
using System.Collections;

public class ConfirmWIndowController : BaseUIController
{
	[SerializeField] private BaseWindow window;
	[SerializeField] private BaseButton noButton;
	[SerializeField] private BaseButton yesButton;

	private int houseIndex;

	public void Start()
	{
		Debug.Assert(window != null);
		Debug.Assert(noButton != null);
		Debug.Assert(yesButton != null);
	}

	public void Initialize()
	{
		window.gameObject.SetActive(false);
	}

	public void ShowConfirm(int houseIndex)
	{
		this.GetComponent<InfoWindowController>().LockButton();

		this.houseIndex = houseIndex;	
		setupLayout();
		window.Show();
	}

	private void setupLayout()
	{
		// Set button callback
		noButton.SetClickCallback(() => {
			selectNo();
		});
		yesButton.SetClickCallback(() => {
			selectYes();
		});
	}

	private void selectNo()
	{
		window.SetDismissFinishedCallback(() => {
			this.GetComponent<InfoWindowController>().UnlockButton();
		});
		window.Dismiss();
		AudioManager.Instance.PlaySE2("s-8,11_se");
	}

	private void selectYes()
	{
		GameDataManager.Instance.HouseIndex = houseIndex;
		this.GetComponent<MapScene>().LoadScene(Global.RESULT_SCENE);
		AudioManager.Instance.PlaySE2("s-10_se");
	}
}

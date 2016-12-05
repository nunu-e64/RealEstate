using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoWindowController : MonoBehaviour
{
	private int houseIndex;
	[SerializeField] private BaseWindow window;
	[SerializeField] private BaseButton selectButton;
	[SerializeField] private BaseButton goBackButton;
	[SerializeField] private BaseButton appearanceButton;
	[SerializeField] private BaseButton floorButton;
	[SerializeField] private Image appearanceImage;
	[SerializeField] private Image floorImage;

	[SerializeField] private Sprite appearanceButtonOnImage;
	[SerializeField] private Sprite appearanceButtonOffImage;
	[SerializeField] private Sprite floorButtonOnImage;
	[SerializeField] private Sprite floorButtonOffImage;

	public void Start()
	{
		Debug.Assert(window != null);
		Debug.Assert(selectButton != null);
		Debug.Assert(goBackButton != null);
		Debug.Assert(appearanceButton != null);
		Debug.Assert(floorButton != null);
		Debug.Assert(floorImage != null);
		Debug.Assert(appearanceImage != null);

		Debug.Assert(appearanceButtonOnImage != null);
		Debug.Assert(appearanceButtonOffImage != null);
		Debug.Assert(floorButtonOnImage != null);
		Debug.Assert(floorButtonOffImage != null);
	}

	public void Initialize()
	{
		window.gameObject.SetActive(false);
	}

	private void setUpLayout(int index)
	{
		// set button callback
		goBackButton.SetClickCallback(() => {
			goBack();
		});
		selectButton.SetClickCallback(() => {
			select();
		});
		appearanceButton.SetClickCallback(() => {
			showAppearance();
		});
		floorButton.SetClickCallback(() => {
			showFloor();
		});

		// default
		showAppearance();

		// load house image
		string id = Util.Choose(index + 1, "a", "b", "c", "d", "e", "f");
		Debug.Log("Set House " + id);
		window.GetComponent<Image>().sprite = Resources.Load<Sprite>(Global.PATH_TO_HOUSE + "/Info/info_" + id);
		appearanceImage.sprite = Resources.Load<Sprite>(Global.PATH_TO_HOUSE + "/Appearance/house_" + id);
		floorImage.sprite = Resources.Load<Sprite>(Global.PATH_TO_HOUSE + "/Floor/floor_" + id);
	}

	public void ShowInfo(int index)
	{
		// lock map
		this.GetComponent<MapUIController>().LockButton();

		this.houseIndex = index;
		setUpLayout(index);
		window.Show();
	}

	private void goBack()
	{
		window.SetDismissFinishedCallback(() => {
			this.GetComponent<MapUIController>().UnlockButton();
		});
		window.Dismiss();
		AudioManager.Instance.PlaySE2("s-8,11_se");
	}

	private void select()
	{
		this.GetComponent<ConfirmWIndowController>().ShowConfirm(houseIndex);
		AudioManager.Instance.PlaySE2("s-9_se");
	}

	private void showAppearance()
	{
		// switch image
		floorImage.gameObject.SetActive(false);
		appearanceImage.gameObject.SetActive(true);

		floorButton.GetComponent<Image>().sprite = floorButtonOffImage;
		appearanceButton.GetComponent<Image>().sprite = appearanceButtonOnImage;
	}

	private void showFloor()
	{
		// switch image
		appearanceImage.gameObject.SetActive(false);
		floorImage.gameObject.SetActive(true);

		floorButton.GetComponent<Image>().sprite = floorButtonOnImage;
		appearanceButton.GetComponent<Image>().sprite = appearanceButtonOffImage;
	}

	public void LockButton()
	{
		window.IsLocked = true;
	}

	public void UnlockButton()
	{
		window.IsLocked = false;
	}
}

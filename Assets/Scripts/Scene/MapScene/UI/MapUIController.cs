using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MapUIController : MonoBehaviour
{
	[SerializeField] private BaseWindow map;
	[SerializeField] private BaseButton characterFace;
	[SerializeField] private BalloonWindow ballon;
	[SerializeField] private Text wish;

	private HouseIconButton[] houseIcons;

	public void Start()
	{
		Debug.Assert(map != null);
		Debug.Assert(characterFace != null);
		Debug.Assert(ballon != null);
		Debug.Assert(wish != null);

		houseIcons = map.GetComponentsInChildren<HouseIconButton>();

		Debug.Assert(houseIcons.Length == Global.HOUSE_NUM);

		this.GetComponent<InfoWindowController>().Initialize();
		this.GetComponent<ConfirmWIndowController>().Initialize();

		setUpContent();
	}

	public void LockButton()
	{
		map.IsLocked = true;
	}

	public void UnlockButton()
	{
		map.IsLocked = false;
	}

	private void setUpContent()
	{
		// SetUp HouseIcon
		foreach (var icon in houseIcons) {
			icon.SetClickHouseCallback((int index) => {
				this.GetComponent<InfoWindowController>().ShowInfo(index);
			});
		}
		LockButton();

		// SetUp Character Face Button
		characterFace.SetClickableAgain();
		characterFace.SetClickCallback(() => {
			characterFace.IsLocked = true;
			ballon.Show();
		});
		characterFace.IsLocked = false;
		ballon.SetShowFinishedCallback(() => {
			characterFace.IsLocked = false;
		});

		// SetUp Character and wish
		characterFace.GetComponent<Image>().sprite = GameDataManager.Instance.CharacterFace;
		wish.text = GameDataManager.Instance.CharacterWish;
		ballon.GetComponentInChildren<Text>().text = GameDataManager.Instance.CharacterMapComment;

		// Select House List by Character
		int charaIndex = GameDataManager.Instance.CharacterIndex;
		foreach (var icon in houseIcons) {
			icon.gameObject.SetActive(false);
		}
		for (int i = 0; i < 3; i++) {
			int index = Global.HOUSE_LIST[charaIndex, i];
			houseIcons[index].gameObject.SetActive(true);
		}
	}
}

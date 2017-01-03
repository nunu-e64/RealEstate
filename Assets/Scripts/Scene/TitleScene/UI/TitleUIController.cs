using UnityEngine;
using System.Collections;

public class TitleUIController : MonoBehaviour
{

	[SerializeField] private GameObject optionPanel;
	[SerializeField] private GameObject randomButton;
	[SerializeField] private GameObject[] selectCharacterButtons;

	private bool isRandomMode = true;

	public void Start()
	{
		Debug.Assert(optionPanel != null);
		Debug.Assert(randomButton != null);
		Debug.Assert(selectCharacterButtons.Length == 3);
		optionPanel.SetActive(false);

		SetupButtonStatus();
	}

	public void SetupButtonStatus()
	{
		if (isRandomMode) {
			ChangeButtonVisible(randomButton);
		} else {
			ChangeButtonVisible(selectCharacterButtons[GameDataManager.Instance.CharacterIndex]);
		}
	}

	public void ChangeButtonVisible(GameObject exception)
	{
		randomButton.GetComponent<UnityEngine.UI.Button>().interactable = true;
		foreach (var button in selectCharacterButtons) {
			button.GetComponent<UnityEngine.UI.Button>().interactable = true;
		}
		exception.GetComponent<UnityEngine.UI.Button>().interactable = false;
	}

	public void SwitchOptionPanelVisible()
	{
		if (optionPanel.activeSelf) {
			optionPanel.SetActive(false);
		} else {
			optionPanel.SetActive(true);
		}
	}

	public void SetPlayCount(int count)
	{
		isRandomMode = false;
		UserDataManager.Instance.PlayCount = count;
		ChangeButtonVisible(selectCharacterButtons[count]);
	}

	public void SwitchRandom()
	{
		isRandomMode = true;
		ChangeButtonVisible(randomButton);
	}

	public void SetupPlayerCount()
	{
		if (isRandomMode) {
			UserDataManager.Instance.RandomizePlayerCount();
		}
		Debug.Log(string.Format("Start: CharacterIndex={0}", GameDataManager.Instance.CharacterIndex));
	}

	public void ResetUserData()
	{
		UserDataManager.Instance.Delete();
		Debug.Log("Delete All User Data.");
		TitleScene.Instance.LoadScene(Global.TITLE_SCENE);
	}

}
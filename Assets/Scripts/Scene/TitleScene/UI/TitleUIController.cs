using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TitleUIController : MonoBehaviour
{

	[SerializeField] private GameObject optionPanel;
	[SerializeField] private GameObject randomButton;
	[SerializeField] private GameObject orderButton;
	[SerializeField] private GameObject[] selectCharacterButtons;

	private bool isRandomMode = false;
	private List<Button> optionButtons;

	public void Start()
	{
		Debug.Assert(optionPanel != null);
		Debug.Assert(randomButton != null);
		Debug.Assert(selectCharacterButtons.Length == 3);
		optionPanel.SetActive(false);

		optionButtons = new List<Button>();
		optionButtons.Add(randomButton.GetComponent<Button>());
		optionButtons.Add(orderButton.GetComponent<Button>());
		foreach (var button in selectCharacterButtons) {
			optionButtons.Add(button.GetComponent<Button>());
		}

		SetupButtonStatus();
	}

	public void SetupButtonStatus()
	{
		if (isRandomMode) {
			ChangeButtonVisible(randomButton);
		} else {
			ChangeButtonVisible(selectCharacterButtons[GameDataManager.Instance.CharacterIndex]);
			orderButton.GetComponent<Button>().interactable = false;
		}
	}

	public void ChangeButtonVisible(GameObject exception)
	{
		foreach (var button in optionButtons) {
			button.interactable = true;
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

	public void SwitchOrder() {
		isRandomMode = false;
		ChangeButtonVisible(orderButton);
		selectCharacterButtons[GameDataManager.Instance.CharacterIndex].GetComponent<Button>().interactable = false;
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
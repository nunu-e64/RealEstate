﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OpeningUIController : BaseUIController
{
	[SerializeField]	private Image spaceBackground;
	[SerializeField]	private Image introBackground;
	[SerializeField]	private BalloonWindow openingBalloon;
	[SerializeField]	private BalloonWindow introBalloon;
	[SerializeField]	private BalloonWindow wishBalloon;

	[SerializeField]	private Image navigator;
	[SerializeField]	private Image character;
	[SerializeField]	private Image characterNameWindow;

	private OpeningState state;

	private enum OpeningState
	{
		OPENING_SHOWING,
		OPENING_SHOW_FINISHED,
		INTRO_SHOWING,
		INTRO_SHOW_FINISHED,
	}

	public void Start()
	{
		state = OpeningState.OPENING_SHOWING;

		introBackground.gameObject.SetActive(false);
		openingBalloon.gameObject.SetActive(false);
		introBalloon.gameObject.SetActive(false);
		wishBalloon.gameObject.SetActive(false);

		navigator.gameObject.SetActive(false);
		character.gameObject.SetActive(false);
		characterNameWindow.gameObject.SetActive(false);

		spaceBackground.gameObject.SetActive(true);

		SetCharacterData();
	}

	private void SetCharacterData()
	{
		character.sprite = GameDataManager.Instance.CharacterSprite;
		characterNameWindow.GetComponentInChildren<Text>().text = GameDataManager.Instance.CharacterName;
		wishBalloon.GetComponentInChildren<Text>().text = GameDataManager.Instance.CharacterWish;

		// TODO Intro comment
	}

	public void Update()
	{
		if (state == OpeningState.OPENING_SHOW_FINISHED) {
			if (InputManager.Instance.IsTouchBegan()) {
				state = OpeningState.OPENING_SHOWING;
				SwitchBackground();
			}
		}
		if (state == OpeningState.INTRO_SHOW_FINISHED) {
			if (InputManager.Instance.IsTouchBegan()) {
				// go to next scene
				this.GetComponent<OpeningScene>().LoadScene(Global.MAP_SCENE);
			}
		}
	}

	public void ShowOpening()
	{		
		navigator.gameObject.SetActive(true);
		float x = navigator.transform.position.x;
		iTween.MoveFrom(navigator.gameObject, iTween.Hash("x", x + 500, "easeType", "easeOutQuad", "time", 0.5f, "oncompletetarget", this.gameObject, "oncomplete", "ShowOpeningBalloon"));
	}

	public void ShowOpeningBalloon()
	{
		openingBalloon.SetShowFinishedCallback(() => {
			state = OpeningState.OPENING_SHOW_FINISHED;
		});
		openingBalloon.Show();
	}

	public void SwitchBackground()
	{
		introBackground.gameObject.SetActive(true);
		introBackground.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
		iTweenExt.FadeTo(spaceBackground.gameObject, iTween.Hash("from", 1, "to", 0, "time", 1.0f, "oncompletetarget", this.gameObject, "oncomplete", "ShowIntroduction"));
		iTweenExt.FadeTo(introBackground.gameObject, 0, 1, 1.0f);
	}

	public void ShowIntroduction()
	{
		openingBalloon.SetDismissFinishedCallback(() => {
			introBalloon.Show();
		});
		introBalloon.SetShowFinishedCallback(() => {
			float x = character.transform.localPosition.x;
			character.gameObject.SetActive(true);
			iTween.MoveFrom(character.gameObject, iTween.Hash("x", x - 100, "time", 0.5f, "oncompletetarget", this.gameObject, "oncomplete", "ShowWish"));
			AudioManager.Instance.PlaySE2("s-16_se");

			characterNameWindow.gameObject.SetActive(true);
			iTween.ScaleFrom(characterNameWindow.gameObject, iTween.Hash("scale", Vector3.zero, "time", 0.5f, "easetype", "easeOutQuad"));
		});
		openingBalloon.Dismiss();
	}

	public void ShowWish()
	{
		wishBalloon.SetShowFinishedCallback(() => {
			state = OpeningState.INTRO_SHOW_FINISHED;
		});
		wishBalloon.Show();
	}
}

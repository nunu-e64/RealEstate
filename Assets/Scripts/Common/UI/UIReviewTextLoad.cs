﻿using UnityEngine;
using UnityEngine.UI;

public class UIReviewTextLoad : MonoBehaviour
{
	public Text text;

	void Start()
	{
		if (GameDataManager.Instance.HouseIndex == -1) {
			GameDataManager.Instance.HouseIndex = 0;
		}

		Global.Grade grade = GameDataManager.Instance.GetGrade();
		int id = GameDataManager.Instance.CharacterIndex + 1;
		text.text = Resources.Load<TextAsset>(string.Format("Texts/review_character{0}_{1}", id, grade)).text;
	}
}

﻿using UnityEngine;
using System;

public class UserDataManager : PersistentSingletonMonoBehaviour<UserDataManager>
{
	public const string KEY = "userData";
	public const string INITIAL_VALUE_PATH = "UserData/initialValue";

	[Serializable]
	public class SaveData
	{
		public int exp = 0;
		public int playCount = 0;
		public bool[] clearArray = new bool[Global.MAX_ALIEN];
	}

	private SaveData saveData;

	public int Exp {
		get {
			return saveData.exp;
		}
	}

	public int PlayCount {
		get {
			return saveData.playCount;
		}
		set {
			saveData.playCount = value;
		}
	}

	public bool GetClearArray(int count)
	{
		return saveData.clearArray[count];
	}

	public void GameClear(int exp)
	{
		saveData.clearArray[saveData.playCount % Global.MAX_ALIEN] = true;
		saveData.exp += exp;
	}

	public void GameOver(int exp)
	{
		saveData.exp += exp;
	}

	public void IncrementPlayerCount()
	{
		// リリア→ポロ→カイト想定だったのが、リリア→カイト→ポロに変わったため、ファイル修正を回避するためにここのIndex変化を修正する
		//saveData.playCount++;
		var prev = saveData.playCount;
		if (saveData.playCount == 0) {
			saveData.playCount = 2;
		} else if (saveData.playCount == 2) {
			saveData.playCount = 1;
		} else if (saveData.playCount == 1) {
			saveData.playCount = 0;
		} else {
			Debug.LogWarningFormat(string.Format("unexpected playcount {0}", saveData.playCount));
			saveData.playCount = 0;
		}
		Debug.Log(string.Format("PlayerCount {0} to {1}", prev, saveData.playCount));
	}

	private void Awake()
	{
		Load();
	}

	public void Save()
	{
		PlayerPrefs.SetString(KEY, JsonUtility.ToJson(saveData));
		PlayerPrefs.Save();
	}

	public void Delete()
	{
		PlayerPrefs.DeleteKey(KEY);
		Load();
		PlayerPrefs.Save();
	}

	public void ShowJson()
	{
		Debug.Log(JsonUtility.ToJson(saveData, true));
	}

	public void Load()
	{
		string json = PlayerPrefs.GetString(KEY, string.Empty);
		if (json == string.Empty) {
			json = Resources.Load<TextAsset>(INITIAL_VALUE_PATH).text;
		}
		saveData = JsonUtility.FromJson<SaveData>(json);
		if (saveData == null) {
			saveData = new SaveData();
			Debug.LogError("Could not find user data.");
		}
	}

	public void RandomizePlayerCount()
	{
		int oldCount = saveData.playCount;
		saveData.playCount = UnityEngine.Random.Range(0, Global.MAX_ALIEN);
		Debug.Log(string.Format("RandomizPlayerCount: {0} to {1}", oldCount, saveData.playCount));
	}
}

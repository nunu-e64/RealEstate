using UnityEngine;

public class TestSave : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.C)) {
			Debug.Log("UserDataManager.Instance.GameClear(100)");
			UserDataManager.Instance.GameClear(100);
			UserDataManager.Instance.ShowJson();
		}

		if (Input.GetKeyDown(KeyCode.O)) {
			Debug.Log("UserDataManager.Instance.GameOver(30)");
			UserDataManager.Instance.GameOver(30);
			UserDataManager.Instance.ShowJson();
		}

		if (Input.GetKeyDown(KeyCode.J)) {
			Debug.Log("UserDataManager.Instance.ShowJson()");
			UserDataManager.Instance.ShowJson();
		}

		if (Input.GetKeyDown(KeyCode.S)) {
			Debug.Log("UserDataManager.Instance.Save()");
			UserDataManager.Instance.Save();
			UserDataManager.Instance.ShowJson();
		}

		if (Input.GetKeyDown(KeyCode.L)) {
			Debug.Log("UserDataManager.Instance.Load()");
			UserDataManager.Instance.Load();
			UserDataManager.Instance.ShowJson();
		}

		if (Input.GetKeyDown(KeyCode.D)) {
			Debug.Log("UserDataManager.Instance.Delete()");
			UserDataManager.Instance.Delete();
			UserDataManager.Instance.ShowJson();
		}

		if (Input.GetKeyDown(KeyCode.T)) {
			Debug.Log("Test");
			Debug.Log(UserDataManager.Instance.Exp);
			Debug.Log(UserDataManager.Instance.PlayCount);
			for (int i = 0, n = Global.MAX_ALIEN; i < n; i++) {
				Debug.Log(UserDataManager.Instance.GetClearArray(i));
			}
		}
	}
}

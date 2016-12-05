using UnityEngine;
using UnityEditor;

public static class PlayerPrefsHelper
{
	private const string MENU_PATH = "Editor/PlayerPrefs/";

	[MenuItem(MENU_PATH + "Clear All")]
	public static void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}
}

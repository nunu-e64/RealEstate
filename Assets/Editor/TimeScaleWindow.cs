using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


/// <summary>
/// 実行中のみTimeScaleを自由に操作するエディタ
/// </summary>
public sealed class TimeScaleWindow : EditorWindow
{
	private static bool isActive = true;
	private static float timeScale = 1;
	private static float SCALE_MAX = 10.0f;
	private static Dictionary<float, string> buttonValueDictionary = new Dictionary<float, string>() {
		{ 0f, "0" },
		{ 0.1f, "0.1 (F1)" },
		{ 0.5f, "0.5 (F2)" },
		{ 1f, "1.0 (F3)" },
		{ 2f, "2.0 (F4)" },
		{ 5f, "5.0 (F5)" },
		{ 10f, "10" },
	};

	private static Dictionary<int, string> skipFrameValueDictionary = new Dictionary<int, string>() {
		{ 1, "1 (F9)" },
		{ 3, "3 (F10)" },
		{ 10, "10 (F11)" },
	};

	[MenuItem("Editor/TimeScaleWindow")]
	private static void Init()
	{
		GetWindow(typeof(TimeScaleWindow), false, "TimeScaleWindow");
	}

	private void OnGUI()
	{
		TimeScaleWindow.RenderGUI();
	}

	public static void RenderGUI()
	{
		isActive = EditorGUILayout.Toggle("isActive", isActive);
		EditorGUILayout.BeginHorizontal();
		foreach (KeyValuePair<float, string> pair in buttonValueDictionary) {
			CreateButton(pair);
		}
		EditorGUILayout.EndHorizontal();
		timeScale = EditorGUILayout.Slider("TimeScale 0〜" + SCALE_MAX.ToString(), timeScale, 0, SCALE_MAX);
		UpdateTimeScale();

		#if DEVELOPMENT
		if (EditorApplication.isPlaying) {
		GUILayout.Space(10);
		GUILayout.Label("Skip frame:");
		EditorGUILayout.BeginHorizontal();
		foreach (KeyValuePair<int, string> pair in skipFrameValueDictionary) {
		CreateSkipFrameButtion(pair);
		}
		EditorGUILayout.EndHorizontal();
		GUILayout.Space(10);
		CreatePauseAndResumeButton();
		}
		#endif
	}

	#if DEVELOPMENT
	private static void CreateSkipFrameButtion(KeyValuePair<int, string> pair)
	{
	if (GUILayout.Button(pair.Value)) {
	DebugManager.Instance.SetSkipFrameByFrameCountForEditor(pair.Key, timeScale);
	isActive = true;
	}
	}

	private static void CreatePauseAndResumeButton()
	{
	if (GUILayout.Button("Pause / Resume (P)")) {
	bool isSkipFrame = DebugManager.Instance.Paused;
	if (isSkipFrame) {
	DebugManager.Instance.ResetSkipFrameForEditor();
	} else {
	DebugManager.Instance.SetSkipFrameByFrameCountForEditor(1, timeScale);
	}
	}
	}
	#endif

	private static void CreateButton(KeyValuePair<float, string> pair)
	{
		if (GUILayout.Button(pair.Value)) {
			timeScale = pair.Key;
		}
	}

	private static void UpdateTimeScale()
	{
		#if DEVELOPMENT
		if (!EditorApplication.isPlaying || !isActive || Mathf.Approximately(Time.timeScale, timeScale)
		|| DebugManager.Instance.Paused) {
		return;
		}
		#else
		if (!EditorApplication.isPlaying || !isActive || Mathf.Approximately(Time.timeScale, timeScale)) {
			return;
		}
		#endif

		Time.timeScale = timeScale;
	}
}

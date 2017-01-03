//Unity上のTextのフォントを一括で変更するエディタ拡張 - Programming Serendipity http://q7z.hatenablog.com/entry/2016/01/06/201607
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class MyFont : ScriptableObject
{
	public Font font;
}

public class FontReplacer : EditorWindow
{
	static SerializedProperty sp;

	[MenuItem("Tools/Replace All Fonts")]
	public static void ShowWindow()
	{
		EditorWindow.GetWindow(typeof(FontReplacer), true, "Font Replacer");
		var obj = ScriptableObject.CreateInstance<MyFont>();
		var serializedObject = new UnityEditor.SerializedObject(obj);

		sp = serializedObject.FindProperty("font");

		Debug.Log("Replace All Fonts: Set font / " + sp.propertyType);
	}

	void OnGUI()
	{
		EditorGUILayout.PropertyField(sp);
		if (GUILayout.Button("Replace All Fonts") && sp != null && sp.objectReferenceValue != null) {
			Debug.Log("Replace All Fonts: you are trying to replace all fonts to new one");

			var textComponents = Resources.FindObjectsOfTypeAll(typeof(Text)) as Text[];
			int count = 0;
			foreach (var component in textComponents) {
				component.font = sp.objectReferenceValue as Font;
				count++;
			}
			// ※追記 : シーンに変更があることをUnity側に通知しないと、シーンを切り替えたときに変更が破棄されてしまうので、↓が必要
			EditorSceneManager.MarkAllScenesDirty();
			Debug.Log(string.Format("Replace All Fonts: Replaced {0} texts", count));
		}
	}
}
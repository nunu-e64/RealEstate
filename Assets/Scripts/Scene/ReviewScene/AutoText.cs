using UnityEngine;
using UnityEngine.UI;

public class AutoText : MonoBehaviour
{
	public Text text;
	public int count;
	public string str = "";

	public void AddText()
	{
		if (str.Length > count) {
			text.text += str[count++].ToString();
		}
	}
}

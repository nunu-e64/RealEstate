using UnityEngine;
using UnityEngine.UI;

public class UIResultTextLoad : MonoBehaviour
{
	public Text text;

	void Start()
	{
		int id = GameDataManager.Instance.CharacterIndex + 1;
		text.text = Resources.Load<TextAsset>(string.Format("Texts/result_character{0}", id)).text;
	}
}

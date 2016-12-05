using UnityEngine;
using UnityEngine.UI;

public class UISetNowCharacterFace : MonoBehaviour
{
	public Image alien;

	void Start()
	{
		alien.sprite = GameDataManager.Instance.CharacterFace;
	}
}

using UnityEngine;
using UnityEngine.UI;

public class UISetNowCharacter : MonoBehaviour
{
	public Image alien;

	void Start()
	{
		alien.sprite = GameDataManager.Instance.CharacterSprite;
	}
}

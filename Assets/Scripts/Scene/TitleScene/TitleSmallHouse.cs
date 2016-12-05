using UnityEngine;
using UnityEngine.UI;

public class TitleSmallHouse : MonoBehaviour
{
	public int alienNumber;
	public Image smallHouse;
	public Image alien;

	void Start()
	{
		if (!UserDataManager.Instance.GetClearArray(alienNumber - 1)) {
			this.gameObject.SetActive(false);
			return;
		}
		smallHouse.sprite = Resources.Load<Sprite>(string.Format("Images/House/TitleSmallHouse/alienHouse{0}", alienNumber));
		alien.sprite = Resources.Load<Sprite>(string.Format("{0}/character{1}", Global.PATH_TO_CHARACTER, alienNumber));
	}
}

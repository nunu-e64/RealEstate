using UnityEngine;
using UnityEngine.UI;

public class UIResultHomeLoad : MonoBehaviour
{
	public Image image;

	void Start()
	{
		if (GameDataManager.Instance.HouseIndex == -1) {
			GameDataManager.Instance.HouseIndex = 0;
		}
		image.sprite = Resources.Load<Sprite>(string.Format("Images/House/ResultHouse/resultHouse_{0}", GameDataManager.Instance.HouseIndex));
	}
}

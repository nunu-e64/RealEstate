using UnityEngine;
using UnityEngine.UI;

public class UIReviewStampLoad : MonoBehaviour
{
	public Image image;

	void Start()
	{
		if (GameDataManager.Instance.HouseIndex == -1) {
			GameDataManager.Instance.HouseIndex = 0;
		}

		Global.Grade grade = Global.GRADE_KVS[UserDataManager.Instance.PlayCount % Global.MAX_ALIEN][GameDataManager.Instance.HouseIndex];
		image.sprite = Resources.Load<Sprite>(string.Format("Images/Stamp/Stamp{0}", grade));
	}
}

using UnityEngine;
using UnityEngine.UI;

public class UIReviewParamLoad : MonoBehaviour
{
	public Image image;

	void Start()
	{
		image.sprite = GameDataManager.Instance.ReviewSprite;
	}
}

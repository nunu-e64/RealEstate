using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndingUIController : MonoBehaviour
{

	[SerializeField] private GameObject praise;
	[SerializeField] private BalloonWindow characterBalloon;
	[SerializeField] private BalloonWindow navigatorBalloon;
	[SerializeField] private GameObject character;

	private bool canTap = false;

	public void Start()
	{
		navigatorBalloon.gameObject.SetActive(false);
		characterBalloon.gameObject.SetActive(false);
		praise.gameObject.SetActive(false);

		setUpContent();
	}

	private void setUpContent()
	{
		//character image
		character.GetComponent<Image>().sprite = GameDataManager.Instance.CharacterSprite;

		//character comment
		characterBalloon.GetComponentInChildren<Text>().text = GameDataManager.Instance.CharacterEndingComment;
	}

	public void ShowContent()
	{
		// prase & balloon
		characterBalloon.SetShowFinishedCallback(() => {
			canTap = true;
		});
		praise.gameObject.SetActive(true);
		iTween.ScaleFrom(praise, iTween.Hash("scale", new Vector3(2, 2), "time", 0.5f, "easetype", "easeOutBack", "oncompletetarget", this.gameObject, "oncomplete", "showCharacterBalloon"));
	}

	private void showCharacterBalloon()
	{
		characterBalloon.Show();
	}

	public void Update()
	{
		if (!canTap) {
			return;
		}

		if (Input.GetMouseButton(0)) {
			navigatorBalloon.SetShowFinishedCallback(() => {
				this.GetComponent<EndingScene>().OnFinishAnimation();
			});
			navigatorBalloon.gameObject.SetActive(true);
			navigatorBalloon.transform.localScale = Vector3.one;
			navigatorBalloon.Show();
			canTap = false;
		}
	}
}

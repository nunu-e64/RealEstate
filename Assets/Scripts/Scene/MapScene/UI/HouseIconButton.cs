using UnityEngine;
using System.Collections;

public class HouseIconButton : CommonButton
{
	public delegate void OnClickedHouseCallback(int index);

	private OnClickedHouseCallback onClickedHouseCallback;

	[SerializeField] private int index;
	
	// Update is called once per frame
	public void OnHouceIconClicked()
	{

	}

	public void SetClickHouseCallback(OnClickedHouseCallback callback)
	{
		onClickedHouseCallback = callback;
		SetClickCallback(() => {
			OnClickHouse();
		});
	}

	public void OnClickHouse()
	{
		onClickedHouseCallback(index);
		AudioManager.Instance.PlaySE2("s-9_se");
	}

	public void Update()
	{
		iTween.ScaleTo(this.gameObject, iTween.Hash("scale", new Vector3(1.3f, 1.3f, 1), "time", 0.5f, "easetype", "easeInSine", "loopType", "pingPong"));
	}
}

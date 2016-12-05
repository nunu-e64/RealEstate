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
}

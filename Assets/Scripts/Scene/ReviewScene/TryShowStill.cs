using UnityEngine.Events;

public class TryShowStill : UIIF
{
	public void Run()
	{
		if (GameDataManager.Instance.HouseIndex == -1) {
			GameDataManager.Instance.HouseIndex = 0;
		}
		if (Global.GRADE_KVS[UserDataManager.Instance.PlayCount % Global.MAX_ALIEN][GameDataManager.Instance.HouseIndex] == Global.Grade.A) {
			UserDataManager.Instance.GameClear(1);
		} else {
			UserDataManager.Instance.GameOver(1);
		}
		Run(false);
	}
}

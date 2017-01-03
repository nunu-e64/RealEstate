using UnityEngine.Events;

public class TryShowStill : UIIF
{
	public void Run()
	{
		if (GameDataManager.Instance.HouseIndex == -1) {
			GameDataManager.Instance.HouseIndex = 0;
		}
		Global.Grade grade = GameDataManager.Instance.GetGrade();
		if (grade == Global.Grade.A) {
			UserDataManager.Instance.GameClear(1);
			Run(true);
		} else {
			UserDataManager.Instance.GameOver(1);
			Run(false);
		}
	}
}

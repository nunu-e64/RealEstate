using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Global
{
	public const int MAX_ALIEN = 3;

	public const string TITLE_SCENE = "TitleScene";
	public const string OPENING_SCENE = "OpeningScene";
	public const string MAP_SCENE = "MapScene";
	public const string REVIEW_SCENE = "ReviewScene";
	public const string REVIEW_PARAM_SCENE = "ReviewParamScene";
	public const string RESULT_SCENE = "ResultScene";
	public const string ENDING_SCENE = "EndingScene";
	public const string LEVEL_UP_SCENE = "LevelUpScene";
	public const string STILL_SCENE = "StillScene";

	public const string PATH_TO_CHARACTER = "Images/Character";
	public const string PATH_TO_HOUSE = "Images/House";
	public const string PATH_TO_TEXT = "Texts";

	public enum Grade
	{
		A,
		B,
		C,
	}

	public static readonly Dictionary<int, Grade[]> GRADE_KVS = new Dictionary<int, Grade[]>() {
		{ 0, new Grade[] { Grade.A, Grade.C, Grade.C, Grade.B, Grade.B, Grade.C } },
		{ 1, new Grade[] { Grade.C, Grade.A, Grade.B, Grade.B, Grade.B, Grade.C } },
		{ 2, new Grade[] { Grade.B, Grade.B, Grade.A, Grade.B, Grade.C, Grade.C } },
	};

	// House List for each character
	public static readonly int[,] HOUSE_LIST = new int[3, 3] {
		{ 0, 2, 4 },
		{ 0, 1, 3 },
		{ 1, 2, 5 }
	};
	public const int HOUSE_NUM = 6;
}

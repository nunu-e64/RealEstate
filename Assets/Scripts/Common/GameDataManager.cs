using UnityEngine;
using System.Collections;

public class GameDataManager : PersistentSingletonMonoBehaviour<GameDataManager>
{
	private int characterIndex = 0;
	// characterIndex : 0-2
	private int houseIndex = 0;
	// houseIndex : 0-5

	private bool isGetCharacter = false;

	private string characterName = "";
	private string characterIntro = "";
	private string characterWish = "";
	private string characterMapComment = "";
	private string characterEndingComment = "";
	private Sprite characterSprite;
	private Sprite characterFace;
	private Sprite reviewSprite;

	public bool IsGetCharacter {
		get { return isGetCharacter; }
		set{ isGetCharacter = value; }
	}

	public int CharacterIndex {
		get {
			characterIndex = UserDataManager.Instance.PlayCount % 3;
			return characterIndex; 
		}
	}

	public int HouseIndex {
		get { return houseIndex; }
		set { houseIndex = value; }
	}

	public string CharacterName {
		get { 
			characterName = Util.Choose(CharacterIndex + 1, "リリア", "ポロ", "カイト");
			return characterName;
		}
	}

	public string CharacterIntro {
		get { 
			string charaFile = "character" + (CharacterIndex + 1);
			characterIntro = Resources.Load<TextAsset>(Global.PATH_TO_TEXT + "/intro_" + charaFile).text;
			return characterIntro; 
		}
	}

	public string CharacterWish {
		get { 
			string charaFile = "character" + (CharacterIndex + 1);
			characterWish = Resources.Load<TextAsset>(Global.PATH_TO_TEXT + "/wish_" + charaFile).text;
			return characterWish; 
		}
	}

	public Sprite CharacterSprite {
		get { 
			string spritePath = Global.PATH_TO_CHARACTER + "/character" + (CharacterIndex + 1);
			characterSprite = Resources.Load<Sprite>(spritePath);
			return characterSprite;
		}
	}

	public Sprite CharacterFace {
		get { 
			string spritePath = Global.PATH_TO_CHARACTER + "/face_character" + (CharacterIndex + 1);
			characterFace = Resources.Load<Sprite>(spritePath);
			return characterFace;
		}
	}

	public string CharacterMapComment {
		get { 
			string charaFile = "character" + (CharacterIndex + 1);
			characterMapComment = Resources.Load<TextAsset>(Global.PATH_TO_TEXT + "/talk_" + charaFile).text;
			return characterMapComment; 
		}
	}

	public string CharacterEndingComment {
		get { 
			string charaFile = "character" + (CharacterIndex + 1);
			characterEndingComment = Resources.Load<TextAsset>(Global.PATH_TO_TEXT + "/praise_" + charaFile).text;
			return characterEndingComment; 
		}
	}

	public Sprite ReviewSprite {
		get { 
			string spritePath = "Images/Review/review_" + CharacterIndex + "_house" + HouseIndex;
			Debug.Log(spritePath);
			reviewSprite = Resources.Load<Sprite>(spritePath);
			return reviewSprite;
		}
	}

	public void Start()
	{
		Initialize();
	}

	public void Initialize()
	{
	}

}
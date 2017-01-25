using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public abstract class BaseScene<T> : SingletonMonoBehaviour<T> where T : MonoBehaviour
{
	[SerializeField]
	protected float fadeSecs = 1f;
	private bool isFadeInFinished;
	private bool loadSceneRequested;

	public bool IsFadeInFinished {
		get {
			return isFadeInFinished;
		}
	}

	public void Awake()
	{
//		AudioManager.Instance.Initialize();
	}

	public virtual void Start()
	{
		Initialize();
		ScreenFader.Instance.SnapOut();
		StartCoroutine(InitializeCoroutine());
	}

	protected virtual void Initialize()
	{
	}

	protected virtual IEnumerator InitializeCoroutine()
	{
		// This is so as not to threadblock the screen fade
		// to ensure it fades in smoothly
		yield return null;

		if (this.fadeSecs > 0f) {
			ScreenFader.Instance.FadeIn(this.fadeSecs, () => {
				OnFadeInFinished();
				isFadeInFinished = true;
			});
		} else {
			ScreenFader.Instance.SnapIn();
			OnFadeInFinished();
			isFadeInFinished = true;
		}
	}

	protected virtual void OnFadeInFinished()
	{
		// Put logic to run after screen fades in (after scene is visible) here
	}

	protected virtual void OnFadeOutFinished()
	{
		// Put logic to run after screen fades out (after scene is hide) here
	}

	public void LoadScene(string sceneName) {
		if (loadSceneRequested) {
			return;
		}
		loadSceneRequested = true;
		ScreenFader.Instance.FadeOut(this.fadeSecs, () => {
			OnFadeOutFinished();
			SceneManager.LoadScene(sceneName);
		});

		if (sceneName == Global.TITLE_SCENE) {
			UserDataManager.Instance.IncrementPlayerCount();
			UserDataManager.Instance.Save();
		}
	}
}

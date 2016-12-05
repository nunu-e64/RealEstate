using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScreenFader : SingletonMonoBehaviour<ScreenFader>
{
	private static Color lastUsedColor = Color.black;
	private readonly Color defaultColor = Color.black;

	private Image fadeImage;

	public Color CurrentColor {
		get {
			Color color = this.fadeImage.color;
			color.a = 1f;
			return color;
		}
	}

	public Color DefaultColor { get { return this.defaultColor; } }

	public void Awake()
	{
		this.fadeImage = GetComponentInChildren<Image>();

		SetColor(lastUsedColor);

		SnapOut();
	}

	public void SetColor(Color color)
	{
		Color c = this.fadeImage.color;
		c.r = color.r;
		c.g = color.g;
		c.b = color.b;
		this.fadeImage.color = c;

		lastUsedColor = color;
	}

	public void FadeOut(float fadeSecs, Color color, bool returnToDefaultColor, Action onFinished)
	{
		SetColor(color);
		StartCoroutine(FadeOutCoroutine(fadeSecs, returnToDefaultColor, onFinished));
	}

	public void FadeOut(float fadeSecs, Color color, Action onFinished)
	{
		FadeOut(fadeSecs, color, false, onFinished);
	}

	public void FadeOut(float fadeSecs, Action onFinished)
	{
		FadeOut(fadeSecs, this.defaultColor, false, onFinished);
	}

	public void FadeIn(float fadeSecs, Color color, Action onFinished)
	{
		SetColor(color);
		StartCoroutine(FadeInCoroutine(fadeSecs, onFinished));
	}

	public void FadeIn(float fadeSecs, Action onFinished)
	{
		FadeIn(fadeSecs, lastUsedColor, onFinished);
	}

	public void FadeCycle(float fadeOutSecs, float fadeInSecs, float fadeOutWaitSecs, Color color, Action onFadeOut, Action onFinished)
	{
		SetColor(color);
		StartCoroutine(FadeCycleCoroutine(fadeOutSecs, fadeInSecs, fadeOutWaitSecs, onFadeOut, onFinished));
	}

	public void FadeCycle(float fadeOutSecs, float fadeInSecs, float fadeOutWaitSecs, Action onFadeOut, Action onFinished)
	{
		FadeCycle(fadeOutSecs, fadeInSecs, fadeOutWaitSecs, this.defaultColor, onFadeOut, onFinished);
	}

	private IEnumerator FadeOutCoroutine(float secs, bool returnToDefaultColor, Action onFinished)
	{
		Color c = this.fadeImage.color;
		c.a = 0f;
		this.fadeImage.color = c;
		this.fadeImage.enabled = true;

		float t = 0f;

		while (t < 1f) {
			t += Time.unscaledDeltaTime / secs;

			float alpha = Mathf.Lerp(0f, 1f, t);
			c.a = alpha;
			this.fadeImage.color = c;

			yield return null;
		}

		if (returnToDefaultColor) {
			t = 0f;
			const float returnDurationSecs = 0.5f;
			Color fromC = c;
			while (t < 1f) {
				t += Time.unscaledDeltaTime / returnDurationSecs;

				this.fadeImage.color = c = Color.Lerp(fromC, this.defaultColor, t);
				yield return null;
			}
			lastUsedColor = c;
		}

		if (onFinished != null) {
			onFinished();
		}
	}

	private IEnumerator FadeInCoroutine(float secs, Action onFinished)
	{
		Color c = this.fadeImage.color;

		float t = 0f;

		while (t < 1f) {
			t += Time.unscaledDeltaTime / secs;

			float alpha = Mathf.Lerp(1f, 0f, t);
			c.a = alpha;
			this.fadeImage.color = c;

			yield return null;
		}

		this.fadeImage.enabled = false;

		if (onFinished != null) {
			onFinished();
		}
	}

	private IEnumerator FadeCycleCoroutine(float fadeOutSecs, float fadeInSecs, float waitSecs, Action onFadeOut, Action onFinished)
	{
		Color c = this.fadeImage.color;
		c.a = 0f;
		this.fadeImage.color = c;
		this.fadeImage.enabled = true;

		float t = 0f;

		while (t < 1f) {
			t += Time.unscaledDeltaTime / fadeOutSecs;

			float alpha = Mathf.Lerp(0f, 1f, t);
			c.a = alpha;
			this.fadeImage.color = c;

			yield return null;
		}

		if (onFadeOut != null) {
			onFadeOut();
		}

		t = 0f;
		while (t < waitSecs) {
			t += Time.unscaledDeltaTime;
			yield return null;
		}

		t = 0f;

		c = this.fadeImage.color;

		while (t < 1f) {
			t += Time.unscaledDeltaTime / fadeInSecs;

			float alpha = Mathf.Lerp(1f, 0f, t);
			c.a = alpha;
			this.fadeImage.color = c;

			yield return null;
		}

		this.fadeImage.enabled = false;

		if (onFinished != null) {
			onFinished();
		}
	}

	public void SnapOut(Color color)
	{
		SetColor(color);
		SnapOut();
	}

	public void SnapOut()
	{
		Color c = this.fadeImage.color;
		c.a = 1f;
		this.fadeImage.color = c;
		this.fadeImage.enabled = true;
	}

	public void SnapIn()
	{
		Color c = this.fadeImage.color;
		c.a = 0f;
		this.fadeImage.color = c;
		this.fadeImage.enabled = false;
	}
}

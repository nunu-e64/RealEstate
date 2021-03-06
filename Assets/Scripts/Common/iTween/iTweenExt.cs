﻿using UnityEngine;
using System.Collections;

public class iTweenExt : MonoBehaviour
{
	private System.Type type;

	protected System.Type GetTargetType(GameObject target)
	{
		if (target.GetComponent<SpriteRenderer>()) {
			return typeof(SpriteRenderer);
		} else if (target.GetComponent<UnityEngine.UI.Text>()) {
			return typeof(UnityEngine.UI.Text);
		} else if (target.GetComponent<UnityEngine.UI.Image>()) {
			return typeof(UnityEngine.UI.Image);
		} else {
			Debug.LogError("iTweenExt target type doesn't match any components");
			return null;
		}            
	}

	protected static void AddComponent(GameObject target)
	{
		iTweenExt me = target.GetComponent<iTweenExt>();
		if (me == null) {
			me = target.AddComponent<iTweenExt>();
		}
		me.type = me.GetTargetType(target);
	}

	public static void FadeTo(GameObject target, float from, float to, float time)
	{
		FadeTo(target, iTween.Hash("from", from, "to", to, "time", time));
	}

	public static void FadeTo(GameObject target, Hashtable args)
	{
		Debug.Assert(target != null && args.Contains("from") && args.Contains("to") && args.Contains("time"));
		AddComponent(target);
		args.Add("onupdate", "SetAlpha");
		iTween.ValueTo(target, args);
	}

	public static void ColorTo(GameObject target, Color from, Color to, float time)
	{
		ColorTo(target, iTween.Hash("from", from, "to", to, "time", time));
	}

	public static void ColorTo(GameObject target, Hashtable args)
	{
		Debug.Assert(target != null && args.Contains("from") && args.Contains("to") && args.Contains("time"));
		AddComponent(target);
		if (target.GetComponent<iTweenExt>() == null) {
			target.AddComponent<iTweenExt>();
		}

		args.Add("onupdate", "SetColor");
		iTween.ValueTo(target, args);
	}

	public static void FadeToWithChildren(GameObject target, Hashtable args)
	{
		Debug.Assert(target != null && args.Contains("from") && args.Contains("to") && args.Contains("time"));
		AddComponent(target);
		foreach (Transform child in target.transform) {
			AddComponent(child.gameObject);
		}

		args.Add("onupdate", "SetAlphaWithChildren");
		iTween.ValueTo(target, args);
	}

	protected void SetAlpha(float alpha)
	{
		Color color;
		if (this.type == typeof(SpriteRenderer)) {
			color = this.GetComponent<SpriteRenderer>().color;
			color.a = alpha;
			this.GetComponent<SpriteRenderer>().color = color;
		} else if (this.type == typeof(UnityEngine.UI.Text)) {
			color = this.GetComponent<UnityEngine.UI.Text>().color;
			color.a = alpha;
			this.GetComponent<UnityEngine.UI.Text>().color = color;
		} else if (this.type == typeof(UnityEngine.UI.Image)) {
			color = this.GetComponent<UnityEngine.UI.Image>().color;
			color.a = alpha;
			this.GetComponent<UnityEngine.UI.Image>().color = color;
		} else {
			Debug.LogError("iTweenExt target type doesn't match any components");
		}
	}

	protected void SetColor(Color color)
	{
		if (this.type == typeof(SpriteRenderer)) {
			this.GetComponent<SpriteRenderer>().color = color;
		} else if (this.type == typeof(UnityEngine.UI.Text)) {
			this.GetComponent<UnityEngine.UI.Text>().color = color;
		} else if (this.type == typeof(UnityEngine.UI.Image)) {
			this.GetComponent<UnityEngine.UI.Image>().color = color;
		} else {
			Debug.LogError("iTweenExt target type doesn't match any components");
		}
	}

	protected void SetAlphaWithChildren(float alpha)
	{
		this.SetAlpha(alpha);
		foreach (iTweenExt i in GetComponentsInChildren<iTweenExt>()) {
			i.SetAlpha(alpha);
		}
	}
}

using UnityEngine;

public class CopyPosition : MonoBehaviour
{
	public RectTransform rectTransform;

	void LateUpdate()
	{
		this.transform.position = rectTransform.position;
	}
}

using UnityEngine;

public class StartButton : MonoBehaviour
{
	public void Update()
	{
		iTween.ScaleTo(this.gameObject, iTween.Hash("scale", new Vector3(1.3f, 1.3f, 1), "time", 0.5f, "easetype", "easeInSine", "loopType", "pingPong"));
	}
}
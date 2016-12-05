using UnityEngine;
using UnityEngine.Events;

public class UIIF : MonoBehaviour
{
	public UnityEvent trueEvent;
	public UnityEvent falseEvent;

	public virtual void Run(bool flag)
	{
		if (flag) {
			trueEvent.Invoke();
		} else {
			falseEvent.Invoke();
		}
	}
}

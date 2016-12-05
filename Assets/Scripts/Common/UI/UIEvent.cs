using UnityEngine;
using UnityEngine.Events;

public class UIEvent : MonoBehaviour
{
	public UnityEvent[] events;

	public void Run(int id)
	{
		if (id < events.Length) {
			events[id].Invoke();
		}
	}
}

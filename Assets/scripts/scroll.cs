using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scroll : MonoBehaviour
{
	static ScrollRect scrollRect;

	public Image[] imagaeArray;

	void Start()
	{
		scrollRect = GetComponent<ScrollRect>();
		scrollRect.onValueChanged.AddListener(ListenerMethod);
	}

	public void ListenerMethod(Vector2 value)
	{
		Debug.Log("ListenerMethod: " + value);
		if(value.x < 0.4)
        {
			imagaeArray[0].color = Color.white;
			imagaeArray[1].color = Color.black;
			imagaeArray[2].color = Color.black;
		}
		if (value.x > 0.4 && value.x < 0.8f)
		{
			imagaeArray[0].color = Color.black;
			imagaeArray[1].color = Color.white;
			imagaeArray[2].color = Color.black;
		}
		if ( value.x > 0.8f)
		{
			imagaeArray[0].color = Color.black;
			imagaeArray[1].color = Color.black;
			imagaeArray[2].color = Color.white;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTimeOfDay : MonoBehaviour
{
	public Sprite DayIcon;
	public Sprite NightIcon;
	private SpriteRenderer sRenderer;
	
	void Start()
	{
		sRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.timeOfDay == "day") {
			sRenderer.sprite = DayIcon;
		}
		else {
			sRenderer.sprite = NightIcon;
		}
    }
}

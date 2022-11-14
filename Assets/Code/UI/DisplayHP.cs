using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHP : MonoBehaviour
{
	private SpriteRenderer sRenderer;
	public Sprite Heart0;
	public Sprite Heart1;
	public Sprite Heart2;
	public Sprite Heart3;
	
    void Start()
    {
		sRenderer = GetComponent<SpriteRenderer>();
    }
	
    void Update()
    {
        switch (PlayerHealth.HP) {
			case 0:
				sRenderer.sprite = Heart0;
				break;
			case 1:
				sRenderer.sprite = Heart1;
				break;
			case 2:
				sRenderer.sprite = Heart2;
				break;
			case 3:
				sRenderer.sprite = Heart3;
				break;				
		}
    }
}

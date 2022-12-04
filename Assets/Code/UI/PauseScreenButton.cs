using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreenButton : MonoBehaviour
{
	private Button button;
	private Image image;
	private RectTransform rect;
	
	void Start()
	{
		button = GetComponent<Button>();
		image = GetComponent<Image>();
		rect = GetComponent<RectTransform>();
		
		// Remove quit button for WebGL version
		if (gameObject.name == "QuitButton" &&
			Application.platform == RuntimePlatform.WebGLPlayer) {
			gameObject.SetActive(false);
		}
		
		// Determine position of button
		if (Application.platform == RuntimePlatform.WindowsPlayer ||
		Application.platform == RuntimePlatform.WindowsEditor) {
			if (gameObject.name == "ContinueButton") {
				rect.anchoredPosition = new Vector2(0, 120);
			}
			else if (gameObject.name == "RestartButton") {
				rect.anchoredPosition = new Vector2(0, -25);
			}
			else if (gameObject.name == "QuitButton") {
				rect.anchoredPosition = new Vector2(0, -170);
			}
		}
		else if (Application.platform == RuntimePlatform.WebGLPlayer) {
			if (gameObject.name == "ContinueButton") {
				rect.anchoredPosition = new Vector2(0, 80);
			}
			else if (gameObject.name == "RestartButton") {
				rect.anchoredPosition = new Vector2(0, -80);
			}
		}
	}
	
    void Update()
    {
		if (GlobalVariables.isPaused) {
			button.enabled = true;
			image.enabled = true;
		}
		else {
			button.enabled = false;
			image.enabled = false;
		}		
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public static void Continue() {
		GlobalVariables.isPaused = false;
	}
	
	public static void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public static void Quit() {
		Application.Quit();
	}
}
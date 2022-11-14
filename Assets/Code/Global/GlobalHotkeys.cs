using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalHotkeys : MonoBehaviour
{
    void Update()
    {
		// DEBUG ONLY:
		// Press R to restart.
		// The player shouldn't accidentally press R
		// and lose their hard-earned progress.
        if (Input.GetKeyDown(KeyCode.R)) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		
		// DEBUG ONLY:
		// Press = (same key as +) to add 1 to your cash.
		// Press - to subtract 1 from your cash.
		if (Input.GetKeyDown(KeyCode.Equals)) {
			GlobalVariables.playerMoney += 1;
		}
		if (Input.GetKeyDown(KeyCode.Minus)) {
			GlobalVariables.playerMoney -= 1;
		}
		
		// Press E to "Emergency sell" 10 corn for 5 cash.
		if (GlobalVariables.playerCorn >= 35
			&& GlobalVariables.playerMoney < GlobalVariables.moneyQuota
			&& Input.GetKeyDown(KeyCode.E)) {
			GlobalVariables.playerCorn -= 10;
			GlobalVariables.playerMoney += 5;
		}
    }
}

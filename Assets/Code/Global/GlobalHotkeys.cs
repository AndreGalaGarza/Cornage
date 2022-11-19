using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalHotkeys : MonoBehaviour
{
    void Update()
    {
		// Press Enter to start the game.
		if (Input.GetKeyDown(KeyCode.Return)
			&& !GlobalVariables.gameStarted) {
			GlobalVariables.gameStarted = true;
		}
		
		// Press R to restart.
		// The player shouldn't accidentally press R
		// and lose their hard-earned progress.
        if (Input.GetKeyDown(KeyCode.R) && PlayerHealth.HP == 0) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		
		// DEBUG ONLY:
		// Press = (same key as +) to add 1 to your cash.
		// Press - to subtract 1 from your cash.
		/*
		if (Input.GetKeyDown(KeyCode.Equals)) {
			GlobalVariables.playerMoney += 1;
		}
		if (Input.GetKeyDown(KeyCode.Minus)) {
			GlobalVariables.playerMoney -= 1;
		}
		*/
		
		// Press E to "Emergency sell" 50 corn for 5 cash.
		if (Input.GetKeyDown(KeyCode.E)
			&& GlobalVariables.playerMoney < GlobalVariables.moneyQuota
			&& PlayerHealth.HP > 0) {
			if (GlobalVariables.playerCorn >= 75) {
				GlobalVariables.playerCorn -= 50;
				GlobalVariables.playerMoney += 5;
			}
			else {
				DisplayMoreCornPrompt.NeedMoreCorn(ref DisplayMoreCornPrompt.fadeoutTime,
					ref DisplayMoreCornPrompt.alpha, ref DisplayMoreCornPrompt.audioSource,
					ref DisplayMoreCornPrompt.Buzzer);
			}

		}
    }
}

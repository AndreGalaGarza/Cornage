using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonContinue : MonoBehaviour
{
   void OnEnable()
    {
        GlobalVariables.isPaused = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public void QuitGame(InputAction.CallbackContext context)
    {
        if (context.started)
            Application.Quit();
    }
}

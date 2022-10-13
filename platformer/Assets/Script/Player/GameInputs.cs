using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputs : MonoBehaviour
{
    [HideInInspector] public float horizontalMove;
    [HideInInspector] public bool jump = false;

    public void MoveInputs(InputAction.CallbackContext context)
    {
        horizontalMove = context.ReadValue<Vector2>().x;
    }

    public void JumpInputs(InputAction.CallbackContext context)
    {
        if(context.started)
            jump = true;
    }
}

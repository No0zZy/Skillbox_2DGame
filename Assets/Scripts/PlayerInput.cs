using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private CharacterAnimation anim;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<CharacterAnimation>();
    }

    private void Update()
    {
        if (GameManager.Instance.State != GameState.Play)
        {
            if (anim.State == CharacterState.Run)
                anim.Idle();
            return;
        }

        float horizontalDirection = Input.GetAxis(GlobalVars.HorizontalAxis);
        bool isJumpPressed = Input.GetButtonDown(GlobalVars.JumpButton);

        playerMovement.Move(horizontalDirection, isJumpPressed);

        if (Input.GetButtonDown(GlobalVars.Fire1))
            playerMovement.Attack();
    }
}

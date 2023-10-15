using System;
using UnityEngine;

namespace RevenantRadiance.Player
{
    public class PlayerView : MonoBehaviour
    {
        private float horizontalInput;
        private PlayerController playerController;

        public void SetController(PlayerController _playerController)
        {
            playerController = _playerController;
        }
        

        // private void Update()
        // {
        //     horizontalInput = Input.GetAxisRaw("Horizontal");
        //
        //     if (Input.GetKey(KeyCode.Space) && groundCheck.isGrounded == true)
        //         isJumping = true;
        //     else
        //         isJumping = false;
        //
        // }
        //
        // private void FixedUpdate()
        // {
        //     HorizontalCharacterMovement(horizontalInput);
        //     PlayerJump();
        // }        
    }
}

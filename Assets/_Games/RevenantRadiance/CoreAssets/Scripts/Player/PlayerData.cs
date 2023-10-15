using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RevenantRadiance.Player
{
    public class PlayerData
    {
        public float speed;
        public float jumpHeightMax;
        public float playerHealth;
        public float dashSpeed;

        public PlayerData(PlayerMovementSO _playerMovementData)
        {
            speed = _playerMovementData.Speed;
            jumpHeightMax = _playerMovementData.JumpHeightMax;
            playerHealth = _playerMovementData.Health;
            dashSpeed = _playerMovementData.DashSpeed;
        }
    }
}

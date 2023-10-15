using UnityEngine;

namespace RevenantRadiance
{
    [CreateAssetMenu(menuName = "ScriptableObject/PlayerMovement", fileName = "PlayerMovementData", order = 1)]
    public class PlayerMovementSO : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private float jumpHeightMax;        
        [SerializeField] private float dashSpeed;
        [SerializeField] private float health;

        public float Speed => speed;
        public float JumpHeightMax => jumpHeightMax;
        public float DashSpeed => dashSpeed;
        public float Health => health;

    }
}

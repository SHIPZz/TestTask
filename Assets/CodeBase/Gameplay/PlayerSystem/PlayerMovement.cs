using UnityEngine;

namespace CodeBase.Gameplay.PlayerSystem
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private Vector3 _targetMovement;
        private float _speed;

        public void SetMovement(Vector2 targetMovement) =>
            _targetMovement = new Vector3(targetMovement.x, 0, targetMovement.y);

        public void SetSpeed(float speed) =>
            _speed = speed;

        private void FixedUpdate()
        {
            _rigidbody.velocity = _targetMovement * _speed;
            
            if (_targetMovement != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(_targetMovement);
        }
    }
}
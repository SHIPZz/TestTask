using UnityEngine;

namespace CodeBase.Gameplay.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
    
        private Transform _target;
     
        private void LateUpdate()
        {
            if(_target == null)
                return;
        
            transform.position = _target.position + _offset;
        }

        public void SetTarget(Transform target) =>
            _target = target;
    }
}

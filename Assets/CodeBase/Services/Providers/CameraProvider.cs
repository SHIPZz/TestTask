using CodeBase.Gameplay.Camera;
using UnityEngine;

namespace CodeBase.Services.Providers
{
    public class CameraProvider : MonoBehaviour
    {
        [field: SerializeField] public CameraFollower CameraFollower { get; private set; }
    }
}
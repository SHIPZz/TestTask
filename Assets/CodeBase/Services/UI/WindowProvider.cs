using System.Collections.Generic;
using CodeBase.Enums;
using CodeBase.UI;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

namespace CodeBase.Services.UI
{
    public class WindowProvider : SerializedMonoBehaviour
    {
        [OdinSerialize] private Dictionary<WindowTypeId, Window> _windows;

        public IReadOnlyDictionary<WindowTypeId, Window> Windows => _windows;
    }
}
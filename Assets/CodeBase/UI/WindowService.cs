using System.Collections.Generic;
using System.Linq;
using CodeBase.Enums;
using CodeBase.Services.UI;

namespace CodeBase.UI
{
    public class WindowService
    {
        private readonly Dictionary<WindowTypeId, Window> _windows;
        private readonly Dictionary<WindowTypeId, Window> _hudWindows;

        public WindowService(WindowProvider windowProvider) =>
            _windows = windowProvider.Windows
                .ToDictionary(x => x.Key, x => x.Value);

        public void Close(WindowTypeId windowTypeId) => 
            _windows[windowTypeId].Close(true);
        
        public void Open(WindowTypeId windowTypeId) => 
            _windows[windowTypeId].Open();

        public void CloseAll()
        {
            foreach (var window in _windows.Values) 
                window.Close(false);
        }
    }
}
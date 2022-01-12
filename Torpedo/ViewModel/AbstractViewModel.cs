using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.ViewModel
{
    public abstract class AbstractViewModel
    {
        public Action Close { get; set; }

        public void CloseWindow()
        {
            Close?.Invoke();
        }
    }
}

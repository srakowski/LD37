using Coldsteel;
using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class PointerBehavior : Behavior
    {
        private IPositionalControl _pointerControl;

        private IDirectionalControl _pointerDirControl;

        public override void Activate()
        {
            _pointerControl = Input.GetPositionalControl("pointer");
            _pointerDirControl = Input.GetDirectionalControl("pointerdir");
        }

        public override void Update()
        {
            this.Transform.Position = _pointerControl.GetPosition();
        }
    }
}

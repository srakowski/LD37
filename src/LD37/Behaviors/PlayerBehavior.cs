using Coldsteel;
using Coldsteel.Scripting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Behaviors
{
    class PlayerBehavior : Behavior
    {
        private IPositionalControl _pointerPosControl;

        private IButtonControl _pointerPrimaryControl;

        private IButtonControl _pointerSecondaryControl;

        public ChampionBehavior Champion { get; set; }

        public override void Activate()
        {
            // TODO: need input during activate
            //_pointerPosControl = Input.GetPositionalControl("Pointer");
            //_pointerPrimaryControl = Input.GetButtonControl("PointerPrimary");
            //_pointerSecondaryControl = Input.GetButtonControl("PointerSecondary");
        }

        public override void Update()
        {
            if (_pointerPrimaryControl == null)
            {
                _pointerPosControl = Input.GetPositionalControl("Pointer");
                _pointerPrimaryControl = Input.GetButtonControl("PointerPrimary");
                _pointerSecondaryControl = Input.GetButtonControl("PointerSecondary");
            }

            var pointerPosition = _pointerPosControl.GetPosition();
            this.Transform.Position = pointerPosition;
            
            // TODO: make these "WasPushed" instead.
            if (_pointerPrimaryControl.WasPressed())
            {
            }

            if (_pointerSecondaryControl.WasPressed())
            {
                // Check if over an enemy, if so, attack that enemy.
                // If not over enemy then the champion need to go to that place.
                Champion.MoveTo(pointerPosition); // TODO: take camera into account.
            }
        }
    }
}

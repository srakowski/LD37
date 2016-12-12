using Coldsteel;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class ChampionController : ChampionBehavior
    {
        private IPositionalControl _pointerControl;
        private IButtonControl _championAct;
        private MainCamera _camera;

        public override void Activate()
        {
            _pointerControl = Input.GetPositionalControl("pointer");
            _championAct = Input.GetButtonControl("champion-act");
            _camera = Scene.GameObjects.OfType<MainCamera>().First();
        }

        public override void Update()
        {
            if (_championAct.IsDown() || _championAct.WasPressed())
            {
                var pointerPos = _pointerControl.GetPosition();
                var clickWorldPoint = _camera.ToWorldCoords(pointerPos);

                var attack = Scene.GameObjects.OfType<IChampionAttackable>()
                    .FirstOrDefault(a => a.Bounds.Contains(clickWorldPoint));

                if (attack == null)
                {
                    Champion.SelectedAttackTarget = null;
                    Champion.TargetDestination = clickWorldPoint;
                }
                else
                {
                    Champion.SelectedAttackTarget = attack;
                    Champion.TargetDestination = null;
                }
            }
        }
    }
}

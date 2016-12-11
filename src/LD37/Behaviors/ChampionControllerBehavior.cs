using Coldsteel;
using Coldsteel.Physics;
using Coldsteel.Rendering;
using Coldsteel.Scripting;
using LD37.GameObjects;
using LD37.Models;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.Behaviors
{
    class ChampionControllerBehavior : Behavior
    {
        private IPositionalControl _pointerPosControl;

        private IButtonControl _pointerPrimaryControl;

        private IButtonControl _pointerSecondaryControl;

        private SpriteRenderer _spriteRenderer;

        private Texture2D _normalPointer;

        private Texture2D _attackPointer;

        public Champion Champion { get; set; }

        public Camera Camera { get; set; }

        public override void Activate()
        {
            _pointerPosControl = Input.GetPositionalControl("Pointer");
            _pointerPrimaryControl = Input.GetButtonControl("PointerPrimary");
            _pointerSecondaryControl = Input.GetButtonControl("PointerSecondary");
            _normalPointer = Content.Load<Texture2D>("sprites/pointer");
            _attackPointer = Content.Load<Texture2D>("sprites/attackpointer");
            _spriteRenderer = GameObject.Components.OfType<SpriteRenderer>().First();
        }

        public override void Update()
        {
            var pointerPosition = _pointerPosControl.GetPosition();
            this.Transform.Position = pointerPosition;

            var attackableGameObjects = Scene.GameObjects.OfType<IChampionTarget>();

            var attackables = attackableGameObjects.Where(IsUnderPointer);
            IChampionTarget thingToAttack = null;
            if (attackables.Any())
            {
                _spriteRenderer.Texture2D = _attackPointer;
                thingToAttack = attackables.First();
            }
            else
            {
                _spriteRenderer.Texture2D = _normalPointer;
            }

            // TODO: make these "WasPushed" instead.
            if (_pointerPrimaryControl.WasPressed())
            {
            }

            if (_pointerSecondaryControl.WasPressed())
            {
                if (thingToAttack != null)
                {
                    Champion.Attack(thingToAttack);
                }
                else
                {
                    var worldPos = Camera.ToWorldCoords(Transform.Position);
                    Champion.MoveTo(worldPos);
                }
            }
        }

        private bool IsUnderPointer(IChampionTarget attackable)
        {
            var worldPos = Camera.ToWorldCoords(Transform.Position);
            return attackable.Bounds.Contains(worldPos);
        }
    }
}

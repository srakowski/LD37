using Coldsteel.Rendering;
using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD37.GameObjects
{
    class ChampionLookBehavior : ChampionBehavior
    {
        private Pointer _pointer;
        private MainCamera _camera;
        private SpriteRenderer _spriteRenderer;

        public override void Activate()
        {
            _pointer = Scene.GameObjects.OfType<Pointer>().First();
            _spriteRenderer = GameObject.Components.OfType<SpriteRenderer>().First();
            _camera = Scene.GameObjects.OfType<MainCamera>().First();
        }

        public override void Update()
        {
            if (Champion.Hand.IsSwinging)
                return;

            var pointerWorldCoord = _camera.ToWorldCoords(_pointer.Transform.Position);
            if (pointerWorldCoord.X < this.Transform.Position.X)
            {
                _spriteRenderer.SpriteEffects = SpriteEffects.FlipHorizontally;
                foreach (var child in GameObject.Transform.Children)
                {
                    if (child.GameObject is Hand)
                    {
                        child.LocalRotation = MathHelper.ToRadians(-40);
                        (child.GameObject as Hand).IsLeft = true;
                    }
                }
            }
            else
            {
                _spriteRenderer.SpriteEffects = SpriteEffects.None;
                foreach (var child in GameObject.Transform.Children)
                {
                    if (child.GameObject is Hand)
                    {
                        child.LocalRotation = MathHelper.ToRadians(40);
                        (child.GameObject as Hand).IsLeft = false;
                    }
                }
            }
        }
    }
}

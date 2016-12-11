using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class SwingBehavior : Behavior
    {
        private const float _swingSpeed = 0.02f;

        public bool IsLeft { get; internal set; }

        public bool IsSwinging { get; private set; } = false;

        public void BeginSwing()
        {
            if (IsSwinging)
                return;

            IsSwinging = true;
            StartCoroutine(Swing());
        }

        private IEnumerator Swing()
        {
            if (IsLeft)
            {
                while (MathHelper.ToDegrees(this.Transform.LocalRotation) < 10)
                {
                    this.Transform.LocalRotation += _swingSpeed * Delta;
                    yield return null;
                }

                while (MathHelper.ToDegrees(this.Transform.LocalRotation) > -100)
                {
                    this.Transform.LocalRotation -= _swingSpeed * Delta;
                    yield return null;
                }

                while (MathHelper.ToDegrees(this.Transform.LocalRotation) < -40)
                {
                    this.Transform.LocalRotation += _swingSpeed * Delta;
                    yield return null;
                }
            }
            else
            {
                while (MathHelper.ToDegrees(this.Transform.LocalRotation) > 10)
                {
                    this.Transform.LocalRotation -= _swingSpeed * Delta;
                    yield return null;
                }

                while (MathHelper.ToDegrees(this.Transform.LocalRotation) < 100)
                {
                    this.Transform.LocalRotation += _swingSpeed * Delta;
                    yield return null;
                }

                while (MathHelper.ToDegrees(this.Transform.LocalRotation) > 40)
                {
                    this.Transform.LocalRotation -= _swingSpeed * Delta;
                    yield return null;
                }
            }
            IsSwinging = false;
        }
    }
}

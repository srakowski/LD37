using Coldsteel;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    public class MainCamera : GameObject
    {
        private Camera _camera;

        public MainCamera()
        {
            AddComponent(_camera = new Camera());
        }

        public Vector2 ToWorldCoords(Vector2 value) => _camera.ToWorldCoords(value);

    }
}

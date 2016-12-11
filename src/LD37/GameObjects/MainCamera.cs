using Coldsteel;
using Coldsteel.Rendering;
using LD37.Behaviors;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.GameObjects
{
    class MainCamera : GameObject
    {
        public MainCamera()
        {
            AddComponent(new Camera());
            AddComponent(new CameraController());
        }
    }
}

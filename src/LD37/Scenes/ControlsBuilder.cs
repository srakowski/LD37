using Coldsteel.Composition;
using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel;
using Coldsteel.Input;

namespace LD37.Scenes
{
    public class ControlsBuilder : IControlsBuilder
    {
        private List<IControl> Controls { get; } = new List<IControl>();

        public void ConfigureControls()
        {
            var pointerControl = new PositionalControl("pointer");
            pointerControl.AddBinding(new MousePositionalControlBinding());
            Controls.Add(pointerControl);

            var pointerDirControl = new DirectionalControl("pointerdir");
            pointerDirControl.AddBinding(new MouseDirectionalControlBinding());
            Controls.Add(pointerDirControl);

            var championActControl = new ButtonControl("champion-act");
            championActControl.AddBinding(new MouseButtonControlBinding(MouseButton.Right));
            Controls.Add(championActControl);
        }

        public IEnumerable<IControl> GetResult() => Controls;
    }
}

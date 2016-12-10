using Coldsteel.Composition;
using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel;
using Coldsteel.Input;

namespace LD37.Game
{
    public class ControlsBuilder : IControlsBuilder
    {
        public PositionalControl Pointer = new PositionalControl("Pointer");

        public ButtonControl PointerPrimary = new ButtonControl("PointerPrimary");

        public ButtonControl PointerSecondary = new ButtonControl("PointerSecondary");

        public void ConfigureControls()
        {
            Pointer.AddBinding(new MousePositionalControlBinding());
            PointerPrimary.AddBinding(new MouseButtonControlBinding(MouseButton.Left));
            PointerSecondary.AddBinding(new MouseButtonControlBinding(MouseButton.Right));
        }

        public IEnumerable<IControl> GetResult()
        {
            return new IControl[]
            {
                Pointer,
                PointerPrimary,
                PointerSecondary
            };
        }
    }
}

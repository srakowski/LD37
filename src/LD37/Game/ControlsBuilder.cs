using Coldsteel.Composition;
using System;
using System.Collections.Generic;
using System.Text;
using Coldsteel;
using Coldsteel.Input;
using Microsoft.Xna.Framework.Input;

namespace LD37.Game
{
    public class ControlsBuilder : IControlsBuilder
    {
        public ButtonControl Up { get; } = new ButtonControl("Up");
        public ButtonControl Down { get; } = new ButtonControl("Down");
        public ButtonControl Left { get; } = new ButtonControl("Left");
        public ButtonControl Right { get; } = new ButtonControl("Right");

        public PositionalControl Pointer = new PositionalControl("Pointer");
        public ButtonControl PointerPrimary = new ButtonControl("PointerPrimary");
        public ButtonControl PointerSecondary = new ButtonControl("PointerSecondary");

        public void ConfigureControls()
        {
            Up.AddBinding(new KeyboardButtonControlBinding(Keys.Up));
            Down.AddBinding(new KeyboardButtonControlBinding(Keys.Down));
            Left.AddBinding(new KeyboardButtonControlBinding(Keys.Left));
            Right.AddBinding(new KeyboardButtonControlBinding(Keys.Right));

            Pointer.AddBinding(new MousePositionalControlBinding());
            PointerPrimary.AddBinding(new MouseButtonControlBinding(MouseButton.Left));
            PointerSecondary.AddBinding(new MouseButtonControlBinding(MouseButton.Right));
        }

        public IEnumerable<IControl> GetResult()
        {
            return new IControl[]
            {
                Up, Down, Left, Right,
                Pointer, PointerPrimary, PointerSecondary
            };
        }
    }
}

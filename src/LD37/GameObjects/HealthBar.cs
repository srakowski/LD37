using Coldsteel;
using Coldsteel.Rendering;
using Microsoft.Xna.Framework;

namespace LD37.GameObjects
{
    class HealthBar : GameObject
    {
        private BoxRenderer _healthBox;

        public float HealthPercentage
        {
            set
            {
                _healthBox.Shape = 
                    new Rectangle(_healthBox.Shape.X,
                    _healthBox.Shape.Y,
                    (int)(78 * value),
                    _healthBox.Shape.Height);
            }
        }

        public HealthBar(IStatsHolder statsHolder)
        {
            AddComponent(new BoxRenderer(-40, -100, 80, 8) { Color = Color.Black });
            AddComponent(_healthBox = new BoxRenderer()
            {
                Shape = new Rectangle(-39, -99, 78, 6),
                Color = Color.Lime
            });

            AddComponent(new HealthBarBehavior(statsHolder));
        }
    }
}

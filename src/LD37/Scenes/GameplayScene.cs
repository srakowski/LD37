using Coldsteel;
using Coldsteel.Composition;
using Coldsteel.Fluent;
using Coldsteel.Rendering;
using LD37.Behaviors;
using Microsoft.Xna.Framework;

namespace LD37.Scenes
{
    public class GameplayScene : ReflectiveSceneBuilder
    {
        public override Color BackgroundColor => Color.Black;

        public GameObject Champion { get; } = new GameObject()
            .SetPosition(100, 100)
            .Add(new SpriteRenderer("sprites/champion"));

        public GameObject Player { get; } = new GameObject()
            .Add(new SpriteRenderer("sprites/pointer"));

        protected override void Compose()
        {
            var championBehavior = new ChampionBehavior();
            Champion.Add(championBehavior);
            Player.Add(new PlayerBehavior()
            {
                Champion = championBehavior
            });
        }
    }
}

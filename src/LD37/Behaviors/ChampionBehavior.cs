using Coldsteel.Scripting;
using Microsoft.Xna.Framework;
using System.Collections;

namespace LD37.Behaviors
{
    class ChampionBehavior : Behavior
    {
        private Coroutine _currentActivity;

        internal void MoveTo(Vector2 worldPosition)
        {
            _currentActivity?.Stop();
            _currentActivity = StartCoroutine(WalkToPosition(worldPosition));
        }

        private IEnumerator WalkToPosition(Vector2 worldPosition)
        {
            while (Vector2.Distance(this.Transform.Position, worldPosition) > 3.0f)
            {
                var direction = worldPosition - this.Transform.Position;
                direction.Normalize();
                this.Transform.Position += direction * 0.3f * Delta;
                yield return null;
            }
        }
    }
}

using Coldsteel;
using Coldsteel.Composition;
using Coldsteel.Fluent;
using LD37.GameObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LD37.Scenes
{
    public class GameplayScene : ReflectiveSceneBuilder
    {
        public Layer PointerLayer { get; } = new Layer("pointer", int.MaxValue)
        {
            IsCameraSticky = true
        };

        public MainCamera Camera { get; } = new MainCamera();

        public Pointer Pointer { get; } = new Pointer();

        public Champion Champion { get; } = new Champion();

        public Hand Hand { get; } = new Hand();

        public Creep Creep { get; } = new Creep();

        public Sword Sword { get; } = new Sword();

        protected override void Compose()
        {
            Champion.SetPosition(200, 200);

            Champion.Hand = Hand;
            Hand.SetParent(Champion);

            Champion.Sword = Sword;
            Sword.SetParent(Hand);
        }
    }
}

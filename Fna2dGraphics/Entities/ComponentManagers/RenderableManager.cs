using Fna2dGraphics.Entities.Components;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Fna2dGraphics.Entities.ComponentManagers
{
    class RenderableManager
    {
        readonly Dictionary<long, Renderable> Renderables = new Dictionary<long, Renderable>();
        readonly TransformManager TransformManager;

        public RenderableManager(TransformManager transformManager)
        {
            TransformManager = transformManager;
        }

        public void Insert(long id, Renderable renderable)
        {
            if (Renderables.ContainsKey(id))
                throw new ArgumentException($"Renderable with id {id} already exists");

            Renderables.Add(id, renderable);
        }

        public void Update(long id, Renderable renderable)
        {
            if (!Renderables.ContainsKey(id))
                throw new ArgumentException($"Renderable with the id {id} doesn't exist");

            Renderables[id] = renderable;
        }

        public Renderable Get(long id)
        {
            if (Renderables.TryGetValue(id, out Renderable outRenderable))
                return outRenderable;

            throw new ArgumentException($"Renderable with the id {id} doesn't exist");
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (var kvp in Renderables)
            {
                var transform = TransformManager.Get(kvp.Key);
                var renderable = kvp.Value;

                batch.Draw(renderable.Texture,
                    transform.Position,
                    renderable.TextureRectangle,
                    renderable.Color,
                    transform.Rotation,
                    renderable.Origin,
                    transform.Scale,
                    renderable.Effect,
                    CalculateDepth(transform.Position.Y, 720));
            }
        }

        float CalculateDepth(float y, float screenHeight)
        {
            return y / screenHeight;
        }

    }
}

using Fna2dGraphics.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fna2dGraphics.Entities.ComponentManagers
{
    class TransformManager
    {
        readonly Dictionary<long, Transform> Transforms = new Dictionary<long, Transform>();

        public void Insert(long id, Transform transform)
        {
            if (Transforms.ContainsKey(id))
                throw new ArgumentException($"Transform with id {id} already exists");

            Transforms.Add(id, transform);
        }

        public void Update(long id, Transform transform)
        {
            if (!Transforms.ContainsKey(id))
                throw new ArgumentException($"Transform with the id {id} doesn't exist");

            Transforms[id] = transform;
        }

        public Transform Get(long id)
        {
            if (Transforms.TryGetValue(id, out Transform outTransform))
                return outTransform;

            throw new ArgumentException($"Transform with the id {id} doesn't exist");
        }
    }
}

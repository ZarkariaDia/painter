﻿using System.Linq;
using System.Threading.Tasks;

namespace Painter.Core
{
    public class CombinedDrawingMechanism : IDrawingMechanism
    {
        private readonly IDrawingMechanism[] drawingMechanisms;

        public CombinedDrawingMechanism(IDrawingMechanism[] drawingMechanisms)
        {
            this.drawingMechanisms = drawingMechanisms;
        }

        public Task MoveToAsync(Position position)
        {
            return Task.WhenAll(drawingMechanisms.Select(m => m.MoveToAsync(position)));
        }

        public Task UpAsync()
        {
            return Task.WhenAll(drawingMechanisms.Select(m => m.UpAsync()));
        }

        public Task DownAsync()
        {
            return Task.WhenAll(drawingMechanisms.Select(m => m.DownAsync()));
        }
    }
}
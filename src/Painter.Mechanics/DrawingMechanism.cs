using System.Threading.Tasks;
using Painter.Geometry;

namespace Painter.Mechanics
{
    public class DrawingMechanism : IDrawingMechanism
    {
        private readonly IServo leftServo;
        private readonly IServo rightServo;

        public DrawingMechanism(IServo leftServo, IServo rightServo)
        {
            this.leftServo = leftServo;
            this.rightServo = rightServo;
        }

        public async Task MoveToAsync(VectorPosition position)
        {
            // throw new System.NotImplementedException();
        }

        public async Task UpAsync()
        {
            // throw new System.NotImplementedException();
        }

        public async Task DownAsync()
        {
            // throw new System.NotImplementedException();
        }
    }
}
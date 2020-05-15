using System.Threading.Tasks;

namespace Painter.Core
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

        public Task MoveToAsync(Position position)
        {
            throw new System.NotImplementedException();
        }

        public Task UpAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task DownAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
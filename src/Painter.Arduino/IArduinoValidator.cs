using Painter.Core;

namespace Painter.Arduino
{
    public interface IArduinoValidator
    {
        ValidationResult ValidateRequest(ArduinoRequest request, ArduinoConfiguration configuration);
    }

    public class ArduinoConfiguration
    {
        // Ports, model, etc
    }

    public class ValidationResult : ResultBase
    {
        private ValidationResult(bool isSuccessful, string? error) : base(isSuccessful, error) { }

        public static ValidationResult Success() => new ValidationResult(true, null);

        public static ValidationResult Error(string error) => new ValidationResult(false, error);
    }
}
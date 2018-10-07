using BusinesLayer.Models;

namespace BusinesLayer.Contracts
{
    interface IValidationAttribute
    {
        ValidationModel IsValid(object value);
    }
}

using BusinesLayer.Models;
using System.Collections.Generic;

namespace BusinesLayer.Contracts
{
    public interface IValidationService<T>
    {
       List<ValidationModel> Validate(T obj);
    }
}

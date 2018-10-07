using SPP.Validation.PresentasionLayer;
using System.Collections.Generic;
using BusinesLayer.Models;

namespace SPP.ValidationService.Pl
{
    class Program
    {
        static void Main(string[] args)
        {
            User test = new User("sdfsdfsdfsdfsdfsd",123,null);
            BusinesLayer.Contracts.IValidationService<User> validationService = new BusinesLayer.ValidationService<User>();
            IList<ValidationModel> errors = validationService.Validate(test);
            if (errors.Count > 0)
            {
                foreach (ValidationModel error in errors)
                {
                    System.Console.WriteLine(error.ErrorMessage);
                }
            }
            System.Console.Read();
        }
    }
}

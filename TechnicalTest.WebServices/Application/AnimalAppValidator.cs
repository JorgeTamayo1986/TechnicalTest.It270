using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.DTO;
using TechnicalTest.WebServices.Properties;

namespace TechnicalTest.WebServices.Application
{
    public static class AnimalAppValidator
    {
        public static RequestResponse<bool> IsValid(AnimalDTO animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Name))
                return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATENAME);

            if(!string.IsNullOrWhiteSpace(animal.Gender))
            {
                if(animal.Gender != "M" && animal.Gender != "H")
                    return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATEGENDER);
            }

            if (!string.IsNullOrWhiteSpace(animal.BirthDate))
            {
                if (!DateTime.TryParse(animal.BirthDate, out DateTime date))
                    return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATEDATE);
            }

            if (animal.Price <= 0)
                return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATEPRICE);


            return new RequestResponse<bool>().CreateSuccessful(true);
        }

        public static RequestResponse<bool> IsValidUpdate(AnimalUpdateDTO animal)
        {
            if (animal.Id <= 0)
                return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATENUMBER);

            if (!string.IsNullOrWhiteSpace(animal.Gender))
            {
                if (animal.Gender != "M" && animal.Gender != "H")
                    return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATEGENDER);
            }

            if (!string.IsNullOrWhiteSpace(animal.BirthDate))
            {
                if (!DateTime.TryParse(animal.BirthDate, out DateTime date))
                    return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATEDATE);
            }

            if (animal.Price <= 0)
                return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATEPRICE);

            return new RequestResponse<bool>().CreateSuccessful(true);
        }

        public static RequestResponse<bool> IsValidId(int id)
        {
            if (id <= 0)
                return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATENUMBER);

            return new RequestResponse<bool>().CreateSuccessful(true);
        }


        
    }
}

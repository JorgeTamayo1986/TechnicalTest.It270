using TechnicalTest.WebServices.Common;
using TechnicalTest.WebServices.DTO;
using TechnicalTest.WebServices.Properties;

namespace TechnicalTest.WebServices.Application
{
    public static class RaceAppValidator
    {
        public static RequestResponse<bool> IsValid(RaceDTO race)
        {
            if (string.IsNullOrWhiteSpace(race.Name))
                return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATENAME);

            return new RequestResponse<bool>().CreateSuccessful(true);
        }

        public static RequestResponse<bool> IsValidUpdate(RaceUpdateDTO race)
        {
            if (race.Id <= 0)
                return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATENUMBER);

            if (string.IsNullOrWhiteSpace(race.Description))
                return new RequestResponse<bool>().CreateUnsuccessful(Resources.MSGVALIDATENAME);

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

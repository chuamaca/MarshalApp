namespace MarshalApp.Net.Rest.Infrastructure.CrossCutting.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset, DateTimeOffset? dateOfDeath)
        {
            var dateToCaculateTo = DateTime.UtcNow;
            if (dateOfDeath != null)
            {
                dateToCaculateTo = dateOfDeath.Value.UtcDateTime;
            }

            int age = dateToCaculateTo.Year - dateTimeOffset.Year;

            if (dateToCaculateTo < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}

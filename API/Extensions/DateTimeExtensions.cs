namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateOnly dob)
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = today.Year - dob.Year;

            // If user already has it's birthday decrease the age
            if (dob > today.AddYears(-1)) age--;

            return age;
        }
    }
}
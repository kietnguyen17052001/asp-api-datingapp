namespace dating_app.api.Extensions
{
    public static class DateTimeExtension
    {
        public static int calculateAge(this DateTime dateOfBirth)
        {
            var today = DateTime.Now;
            var age = today.Year - dateOfBirth.Year;
            return age;
        }
    }
}
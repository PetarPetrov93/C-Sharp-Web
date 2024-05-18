namespace HouseRentingSystem.Infrastructure.Constants
{
    public static class DataConstants
    {
        public static class ForCategory
        {
            public const int NameMaxLength = 50;
        }

        public static class ForHouse
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AddressMinLength = 30;
            public const int AddressMaxLength = 150;
            
            public const int DescriptionMinLength = 50;
            public const int DescriptionMaxLength = 500;

            public const string MinimumPrice = "0";
            public const string MaximumPrice = "2000";
            public const string PriceErrorMessage = "Price Per Month must be a positive number and less than {2} leva.";
        }

        public static class ForAgent
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class ForApplicationUser
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 30;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 30;
        }
    }
}

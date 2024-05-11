﻿namespace HouseRentingSystem.Infrastructure.Constants
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

            public const string MinimumPrice = "0.0";
            public const string MaximumPrice = "2000.0";
        }

        public static class ForAgent
        {
            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
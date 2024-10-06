namespace GameZone.Common
{
    public static class ValidationConstants
    {
        public static class ForGame
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 500;

            public const string DateTimeFormat = "yyyy-MM-dd";
        }

        public static class ForGenre 
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 25;
        }

    }
}

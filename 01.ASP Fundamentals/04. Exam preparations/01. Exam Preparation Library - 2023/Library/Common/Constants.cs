namespace Library.Common
{
    public static class Constants
    {
        public static class BookConstants
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 50;

            public const int AuthorMinLength = 5;
            public const int AuthorMaxLength = 50;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 5000;

            public const decimal RatingMinValue = 0.0m;
            public const decimal RatingMaxValue = 10.0m;
        }

        public static class  CategoryConstants
        {
            public const int CategoryNameMinLength = 5;
            public const int CategoryNameMaxLength = 50;
        }

    }
}

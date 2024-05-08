namespace TaskBoardApp.Data
{
    public static class ValidationConstants
    {
        public static class ForTask
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 70;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            public const string ErrorMsg = "{0} should be at least {2} characters long.";
        }

        public static class ForBoard
        {
            public const int BoardNameMinLength = 3;
            public const int BoardNameMaxLength = 30;
            public const string ErrorMsg = "{0} should be at least {2} characters long.";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.Constants
{
    /// <summary>
    /// Validation constants
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Constants for Post
        /// </summary>
        public static class PostValidationConstants
        {
            /// <summary>
            /// Max and min length for Title
            /// </summary>
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            /// <summary>
            /// Max and min length for Content
            /// </summary>
            public const int ContentMaxLength = 1500;
            public const int ContentMinLength = 30;
        }

        /// <summary>
        /// Constants for PostModel
        /// </summary>
        public static class PostModelValidationConstants
        {
            /// <summary>
            /// Error message for required properties in PostModel
            /// </summary>
            public const string RequiredErrorMessage = "The {0} field is required!";

            /// <summary>
            /// Max and min length for PostModel Title
            /// </summary>
            public const int TitleMaxLength = 50;
            public const int TitleMinLength = 10;

            /// <summary>
            /// Max and min length for PostModel Content
            /// </summary>
            public const int ContentMaxLength = 1500;
            public const int ContentMinLength = 30;

            /// <summary>
            /// Error message for min-max length
            /// </summary>
            public const string ErrorMessage = "The {0} length should be between {2} and {1} symbols!";
        }
    }
}

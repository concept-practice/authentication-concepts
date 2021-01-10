namespace SecurityPractice.Common.Validation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public static class ObjectVerification
    {
        /// <summary>
        /// Validates an object against its attributes.
        /// </summary>
        /// <param name="entity">The object to be validated.</param>
        /// <returns>An ObjectVerificationResult that represents either a success or failure.</returns>
        public static ObjectVerificationResult Validate(object entity)
        {
            var context = new ValidationContext(entity, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(entity, context, results, true))
            {
                return ObjectVerificationResult.Failure(results.Select(validationResult => validationResult.ErrorMessage));
            }

            return ObjectVerificationResult.Successful();
        }
    }
}

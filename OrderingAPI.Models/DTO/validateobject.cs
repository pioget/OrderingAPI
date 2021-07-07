using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace OrderingAPI.Models.DTO
{
    public class validate
    {
        public class ValidPhoneNumber : ValidationAttribute
        {
            public ValidPhoneNumber()
                : base("{0} value is not a valid phone number")
            {
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                bool valid = false;

                if (value == null)
                {
                    return null;
                }

                if (value.ToString().Length > 0)
                {
                    valid = Regex.Match(value.ToString(), @"^(?:(?:\(?(?:0(?:0|11)\)?[\s-]?\(?|\+)44\)?[\s-]?(?:\(?0\)?[\s-]?)?)|(?:\(?0))(?:(?:\d{5}\)?[\s-]?\d{4,5})|(?:\d{4}\)?[\s-]?(?:\d{5}|\d{3}[\s-]?\d{3}))|(?:\d{3}\)?[\s-]?\d{3}[\s-]?\d{3,4})|(?:\d{2}\)?[\s-]?\d{4}[\s-]?\d{4}))(?:[\s-]?(?:x|ext\.?|\#)\d{3,4})?$", RegexOptions.IgnoreCase).Success;
                }
                else
                {
                    valid = true;
                }
                if (valid)
                    return null;

                return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                    , new string[] { validationContext.MemberName });
            }
        }

        public class ValidEmailAddress : ValidationAttribute
        {
            public ValidEmailAddress()
                : base("{0} value is not a valid email")
            {
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                bool valid = false;

                if (value == null)
                {
                    return null;
                }

                if (value.ToString().Length > 0)
                {
                    valid = Regex.Match(value.ToString(), @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                                               + "@"
                                                               + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", RegexOptions.IgnoreCase).Success;
                }
                else
                {
                    valid = true;
                }

                if (valid)
                    return null;

                return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                    , new string[] { validationContext.MemberName });
            }
        }

        public class ValidPostCode : ValidationAttribute
        {
            public ValidPostCode()
                : base("{0} value is not a valid Post Code")
            {
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                bool valid = false;

                if (value == null)
                {
                    return null;
                }

                if (value.ToString().Length > 0)
                {

                    valid = Regex.Match(value.ToString(), @"^([A-Za-z][A-Ha-hJ-Yj-y]?[0-9][A-Za-z0-9]? ?[0-9][A-Za-z]{2}|[Gg][Ii][Rr] ?0[Aa]{2})$", RegexOptions.IgnoreCase).Success;
                }
              
                if (valid)
                    return null;

                return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                    , new string[] { validationContext.MemberName });
            }
        }

        public class GreaterThanZero : ValidationAttribute
        {
            public GreaterThanZero()
                : base("{0} Must be Greater than 0")
            {
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                bool valid = false;

                if (value == null)
                {
                    return null;
                }



                int result = Convert.ToInt32(value);

                if (result > 0)
                {
                    valid = true;
                }

                if (valid)
                    return null;

                return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                    , new string[] { validationContext.MemberName });
            }
        }

        public class ValidateEachItemAttribute : ValidationAttribute
        {
            protected readonly List<ValidationResult> validationResults = new List<ValidationResult>();

            public override bool IsValid(object value)
            {
                var list = value as IEnumerable;
                if (list == null) return true;

                var isValid = true;

                foreach (var item in list)
                {
                    var validationContext = new ValidationContext(item);
                    var isItemValid = Validator.TryValidateObject(item, validationContext, validationResults, true);
                    isValid &= isItemValid;
                }
                return isValid;
            }

            // I have ommitted error message formatting
        }
    }
 
}

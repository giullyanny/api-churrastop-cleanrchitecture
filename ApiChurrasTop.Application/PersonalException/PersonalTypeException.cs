using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiChurrasTop.Application.PersonalException
{
    public class PersonalTypeException : Exception
    {
        public PersonalTypeException(string error) : base(error) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new PersonalTypeException(error);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using APIChurrasTop.Application.Message;

namespace ApiChurrasTop.Application.Type
{
    public struct Celular
    {
        private readonly string _value;

        private Celular(string celular) { _value = celular; }

        public static Celular Parse(string celular)
        {
            Celular _return;

            if (TryParse(celular, out _return))
            {
                return _return;
            }
            throw new PersonalException.PersonalTypeException(ERROR.CELULAR);
        }

        public static bool TryParse(string celular, out Celular _return)
        {
            Regex Rgx = new Regex(@"^\(\d{2}\)\d{5}-\d{4}$"); //formato (XX)XXXXX-XXXX

            if (!Rgx.IsMatch(celular))
            {
                _return = new Celular(string.Empty);
                return false;
            }

            _return = new Celular(celular);
            return true;
        }

        public static implicit operator Celular(string celular)
          => Parse(celular);
    }
}
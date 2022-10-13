using System;
using APIChurrasTop.Application.Message;

namespace ApiChurrasTop.Application.Type
{
    public struct CPF
    {
        private readonly string _value;

        private CPF(string value) { _value = value; }

        public static CPF Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }
            throw new PersonalException.PersonalTypeException(ERROR.CPF);
        }

        public static bool TryParse(string cpf, out CPF _return)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11){
                _return = string.Empty;
                return false;
            }

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;

            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (cpf.EndsWith(digito)){
                _return = new CPF(cpf);
                return true;
            }

            _return = new CPF(String.Empty);
            return false;
        }

        public static implicit operator CPF(string cpf)
          => Parse(cpf);
    }
}
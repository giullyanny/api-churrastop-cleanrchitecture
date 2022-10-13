namespace APIChurrasTop.Application.Message
{
    public struct ERROR
    {
        public static string CPF = "CPF não é válido!";
        public static string NOME_PESSOA_VAZIO = "Nome completo deve ser definido!";
        public static string NOME_PESSOA_MIN = "Nome deve ter ao menos 10 caracteres!";
        public static string NOME_PESSOA_MAX = "Nome deve ter ao máximo 70 caracteres!";
        public static string NOME_DESCRICAO_VAZIO = "Nome completo deve ser definido!";
        public static string NOME_DESCRICAO_MIN = "Nome deve ter ao menos 3 caracteres!";
        public static string NOME_DESCRICAO_MAX = "Nome deve ter ao máximo 70 caracteres!";
        public static string NOME_OBSERVACAO_VAZIO = "Nome completo deve ser definido!";
        public static string NOME_OBSERVACAO_MIN = "Nome deve ter ao menos 3 caracteres!";
        public static string NOME_OBSERVACAO_MAX = "Nome deve ter ao máximo 70 caracteres!";
        public static string CELULAR = "Número celular no formato incorreto! Use o formato: (XX)XXXXX-XXXX";
        public static string EMAIL_INVALIDO = "E-mail é inválido!";
        public static string NOME_EMAIL_MAX = "E-mail deve ter ao máximo 100 caracteres!";
        public static string SENHA_INVALIDA = "Senha é inválido! Deve conter entre 10 e 20 caracteres";
    }
}
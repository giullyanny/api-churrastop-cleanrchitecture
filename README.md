# API ChurrasTop

## Iniciar o banco
1. dotnet ef migrations add Inicial --project .\ApiChurrasTop.Infra.Data\ -s .\ApiChurrasTop.Api\ -c ApplicationDbContext --verbose
2. dotnet ef database update -c ApplicationDbContext -s ..\ApiChurrasTop.Api\

## O que gostaria de terminar
- Faltou terminar os teste, iniciei, mas fazer todos os teste demoraria. Terminarei em um futuro
- Padrão CQRS, em leituras no Balta.io e Macoratti vi este padrão, mas nunca apliquei
- Segurança, pretendo ainda aplicar uma validação JWT, em grandes aplicações faz mais sentido isso ficar no gatway
- Uso do Dapper para consultar para melhorar a performance.

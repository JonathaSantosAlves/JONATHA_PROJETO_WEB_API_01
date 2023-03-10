C# ASP.NET CORE 6.0 WEB API - CONCEITOS DDD Design Patterns - IOC - Inje��o de Dependencia
Meu PortFolio 
https://www.jonatha.com.br/

Os Links para consulta coloquei em meu site, ou se preferir pode baixar o projeto no github https://github.com/JonathaSantosAlves/JONATHA_PROJETO_WEB_API_01

Obter diferen�as
GET /v1/diff/{id}
https://www.jonatha.com.br/projetoapi01/v1/diff/10

https://prnt.sc/NkEY4h3BxPC6


Adicionar dados direito
POST /v1/diff/{id}/right
https://www.jonatha.com.br/projetoapi01/v1/diff/10/right

https://prnt.sc/2jp2CLSz6i74


Endpoints
Adicionar dados esquerdo
POST /v1/diff/{id}/left
https://www.jonatha.com.br/projetoapi01/v1/diff/10/left

https://prnt.sc/k2D8G0e5O3Dj

Compara��o de Dados Bin�rios
Este projeto implementa uma API para comparar dados bin�rios codificados em base64.

https://prnt.sc/7MH84g22IvWs

Endpoints
Adicionar dados esquerdo
POST /v1/diff/{id}/left

https://prnt.sc/2OXALAl7Jytj
https://prnt.sc/T7dXM-FOWH_P

Adiciona os dados esquerdo para a compara��o.

Requisi��o
Corpo da requisi��o deve ser uma string contendo os dados bin�rios codificados em base64.

json
Copy code
{ "base64Data": "A3ZhbHVlIGlzIGJpbmFyeSBkYXRvcw==" }
Resposta
Retorna 200 OK se os dados foram armazenados com sucesso.

Adicionar dados direito
POST /v1/diff/{id}/right

https://prnt.sc/lSFiMiiV6JEN
https://prnt.sc/LPMqJh5zwU6c

Adiciona os dados direito para a compara��o.

Requisi��o
Corpo da requisi��o deve ser uma string contendo os dados bin�rios codificados em base64.

json
Copy code
{ "base64Data": "A3ZhbHVlIGlzIGJpbmFyeSBkYXRvcw==" }
Resposta
Retorna 200 OK se os dados foram armazenados com sucesso.

Obter diferen�as
GET /v1/diff/{id}

https://prnt.sc/kyZXGY_T7pEH

Compara os dados armazenados anteriormente e retorna as diferen�as.

Resposta
Se os dados forem iguais, retorna:

json
Copy code
{
    "equal": true
}
Se os dados n�o forem do mesmo tamanho, retorna:

json
Copy code
{
    "equal": false,
    "alert": "Os dados n�o possuem o mesmo tamanho."
}
Se os dados tiverem o mesmo tamanho, retorna:

json
Copy code
{
    "equal": false,
    "alert": [
        {
            "offset": 3,
            "length": 5
        },
        {
            "offset": 11,
            "length": 2
        }
    ]
}
Erros
Se ocorrer um erro durante a execu��o da API, a resposta ser� um c�digo de status HTTP apropriado com uma mensagem de erro no corpo da resposta.
https://prnt.sc/JaOnnuP5hjgi

Tecnologias Utilizadas
(ASP.NET Core 6.0) - 
(Microsoft.AspNetCore.Mvc.Newtonsoft) - 
(Microsoft.Extensions.Primitives) - 
(Microsoft.NET.Test.Sdk) - 
(Moq) - 
(xunit) - 
(Swashbuckle.AspNetCore) - 
(xunit.runner.visualstudio) - 

Autor
Jonatha Santos Alves - GitHub - https://github.com/JonathaSantosAlves
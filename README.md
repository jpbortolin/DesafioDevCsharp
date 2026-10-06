# Desafio Técnico — C#

Resolução de três exercícios em C#, organizados em projetos de console independentes.

## Exercícios

### 1. Cálculo de comissões

Lê as vendas de um arquivo JSON e calcula a comissão total de cada vendedor conforme as regras:

- Vendas abaixo de R$ 100,00: sem comissão.
- Vendas de R$ 100,00 até menos de R$ 500,00: comissão de 1%.
- Vendas a partir de R$ 500,00: comissão de 5%.

A comissão é calculada por venda e arredondada para duas casas decimais antes da soma por vendedor.

### 2. Movimentação de estoque

Carrega os produtos de um arquivo JSON e permite:

- Consultar o estoque.
- Registrar entradas e saídas.
- Consultar o histórico de movimentações.

Cada movimentação possui um identificador numérico único durante a execução, uma descrição e o saldo final do produto.

O programa valida as informações e impede saídas superiores ao estoque disponível. Os dados ficam em memória e são reiniciados ao abrir o programa novamente.

### 3. Cálculo de juros

Recebe um valor e uma data de vencimento e calcula os juros até a data atual do computador.

Foi adotado o cálculo de juros simples de 2,5% por dia corrido de atraso, pois o enunciado não especifica capitalização. Vencimentos na data atual ou no futuro não geram juros.

## Tecnologias

- C#
- .NET 8
- System.Text.Json
- LINQ

## Como executar

É necessário ter o SDK do .NET 8 instalado.

Na pasta principal do repositório, execute o comando correspondente ao exercício:

**Exercício 1:**
```bash
dotnet run --project Exercicio1.Comissoes
```

**Exercício 2:**
```bash
dotnet run --project Exercicio2.Estoque
```

**Exercício 3:**
```bash
dotnet run --project Exercicio3.Juros
```

## Observações:

> *Para informar valores monetários, utilize vírgula como separador decimal;*

> *As datas devem ser digitadas no formato `dd/MM/aaaa`.*

## Validação

Os três programas foram executados manualmente no ambiente local.
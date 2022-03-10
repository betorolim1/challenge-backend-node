## Sobre a API

Esta API foi desenvolvida em .Net com o propósito de buscar os dados de filmes e séries da OMDb API e traze-los para qualquer aplicação os consumir.

## Como funciona?

1. Clone (baixe) o projeto em seu computador
2. Abra o projeto e roda normalmente (F5) (Verifique se a API está definida como projeto de inicialização)

## Endpoints

1. GET: http://localhost:65380/api/v1/movies/{id}?plot={p}
* Busca o filme/série pelo Id passado
  
2. GET: http://localhost:65380/api/v1/movies/title/{title}?year={y}&plot={p}
* Busca o filme/série pelo título e ano passado

## Propriedades

* id -> Id do filme/série (imdbID). Não pode ser nulo.
* title -> Título do filme/série. Não pode ser nulo.
* y -> Ano do filme/série.
* p -> Plot completo ou simplificado. 0: Simplificado. 1: Completo


# CRUD-ADO.NET

**CRUD:** (Create, Read, Update e Delete) são as quatro operações básicas utilizadas em bases de dados relacionais (RDBMS) ou em interface para utilizadores para criação, consulta, atualização e destruição de dados. 

**ADO.NET:** ADO.NET (ou a nova tecnologia ActiveX Data Objects) consiste num conjunto de classes definidas pela .NET framework (localizadas no namespace System.Data) que pode ser utilizado para aceder aos dados armazenados numa base de dados remota.
O “modelo desconectado” ADO.NET utiliza dois tipos de objetos para aceder à base de dados: os objetos Dataset, que podem conter um ou mais Data Table, e os .NET Data Provider.

**.NET Data Provider:** Um provedor de dados do .NET Framework é usado para se conectar a um banco de dados, executar comandos e recuperar resultados. Os resultados são processados diretamente, colocados no DataSet para serem expostos ao usuário conforme o necessário, combinados com os dados de várias fontes ou colocados remotamente entre camadas. Os provedores de dados .NET Framework são leves, criando uma camada mínima entre a fonte de dados e o código, aumentando o desempenho sem sacrificar a funcionalidade.

**NpgSQL Provider:** Npgsql é um provider .NET para PostgreSQL. Ele permite que qualquer aplicação desenvolvida em .NET Framework acesse o banco de dados. Seu código foi escrito totalmente em C#. É compatível com banco de dados PostgreSQL 7.x ou versões superiores.

<p align="center">

<img src="https://image.slidesharecdn.com/ado-160824160940/95/adonet-tutorial-5-638.jpg?cb=1472055843" width="50%" height="50%"/>

</p>

**TABELAS SQL:**

```SQL
CREATE TABLE public.tab_categoria
(
  cod_categoria SERIAL NOT NULL,
  desc_categoria character varying(150) NOT NULL,
  CONSTRAINT tab_categoria_pkey PRIMARY KEY (cod_categoria),
  CONSTRAINT tab_categoria_desc_categoria_key UNIQUE (desc_categoria)
)
```
```SQL
CREATE TABLE public.tab_diretor
(
  cod_diretor SERIAL NOT NULL,
  nome_diretor character varying(250) NOT NULL,
  CONSTRAINT tab_diretor_pkey PRIMARY KEY (cod_diretor)
)
```

```SQL
CREATE TABLE public.tab_filme
(
  cod_filme SERIAL NOT NULL,
  nome_filme character varying(250) NOT NULL,
  data_filme date NOT NULL,
  cod_categoria integer NOT NULL,
  CONSTRAINT tab_filme_pkey PRIMARY KEY (cod_filme),
  CONSTRAINT tab_filme_cod_categoria_fkey FOREIGN KEY (cod_categoria)
      REFERENCES public.tab_categoria (cod_categoria) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
```

```SQL
CREATE TABLE public.tab_filme_diretor
(
  cod_filme integer NOT NULL,
  cod_diretor integer NOT NULL,
  CONSTRAINT tab_filme_diretor_pkey PRIMARY KEY (cod_filme, cod_diretor),
  CONSTRAINT tab_filme_diretor_cod_diretor_fkey FOREIGN KEY (cod_diretor)
      REFERENCES public.tab_diretor (cod_diretor) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION,
  CONSTRAINT tab_filme_diretor_cod_filme_fkey FOREIGN KEY (cod_filme)
      REFERENCES public.tab_filme (cod_filme) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
```

**MODELO LÓGICO:**

<p align="center">

<img src="https://github.com/DoisLucas/CRUD-ADO.NET/blob/master/resources/modelo.PNG?raw=true" width="150%" height="150%"/>

</p>

*Clique na imagem para dar zoom*


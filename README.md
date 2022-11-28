# API para a Aplicação Mobile Spring Library

![Logo_Tema_Claro](https://user-images.githubusercontent.com/80417466/204097070-12365f5d-71a3-43c0-b86c-458c84d15c1b.png)


## Perfil da desenvolvedora e seus respectivos contribuinte:

| [<img src="https://avatars.githubusercontent.com/u/80417466?v=4" width=115><br><sub>Leticia Resina</sub>](https://github.com/letyresina) | [<img src="https://avatars.githubusercontent.com/u/82532010?v=4" width=115><br><sub>Gustavo Pereira</sub>](https://github.com/PereiraGus) | [<img src="https://avatars.githubusercontent.com/u/82535458?v=4" width=115><br><sub>Larissa Sonoda</sub>](https://github.com/LarissaSonoda) |
| :---: | :---: | :---: 

## Objetivo

Essa API tem como enfoque a entrega do TCC, que une os conhecimentos desde o Primeiro Ano do Ensino Médio integrado ao Desenvolvimento de sistemas na ETEC Professor Basilides de Godoy. Essa é a entrega final.

Essa API servirá para consumir a aplicação Mobile, presente no repositório dessa organização, com dados vindo diretamente do Banco MYSQL, localizado na pasta de Scripts.

## Linguagens utilizadas
 | <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/C_Sharp_wordmark.svg/200px-C_Sharp_wordmark.svg.png" witdh=115 /> | <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/Javascript-shield.svg/397px-Javascript-shield.svg.png" width=115> | <img src="https://miro.medium.com/max/1400/1*DZyivhX9QpnKxovKyQjZEw.png" width=115 /> |
| :---: | :---: | :---: 

## Plataforma de desenvolvimento

![image](https://user-images.githubusercontent.com/80417466/204288648-490a8bdb-f4a0-43aa-b72e-ba259aad94b0.png)

Visual Studio 2022.

## Manual para acesso à API 

É válido ressaltar que a API, nesta situação, está localizado localmente. Este manual é para a execução local + utilização do swagger. 

Para utilizar à API é necessário a execução do banco de dados, tanto do "dbSpringLibrary" tanto do "dbPopulate". Segue o manual passo a passo: 

1. Vá até "<> Code", copie o link presente em HTTPS e clone o projeto. Você pode optar por clonar tanto pelo git bash, onde você criará uma pasta vazia, clicará com botão direito do mouse, selecionar git bash here e escreverá no terminal "git clone 'link aqui'", ou pelo git desktop, crie uma pasta vazia e clone o projeto nessa pasta;
2. Após a conclusão, abra a pasta que está clonado o projeto e para encontrar os dois scripts do banco vá pelo caminho: API_SpringLibrary\API_SpringLibrary\Scripts. Abra o MySql e abra os bancos "dbSpringLibrary" e "dbPopulate";
3. Execute, linha por linha, procedure por procedure, view por view para não ter nenhum problema. Em seguida, execute o dbPopulate, que popula o banco com os dados necessários para a execução da API;
4. Volte para a pasta inicial "API_SpringLibrary" e abra o API_SpringLibrary.sln. De preferência, na IDE Visual Studio 2022 ou 2019;
5. Espere o projeto carregar. Caso dê o erro de "ISO" pela versão, clique em Compilação e limpe o projeto;
6. Execute o projeto clicando no IIS Express (Google Chrome) e espee a página do google abrir;
7. Quando a página carregar, abra já o swagger inspector para auxiliar nos processos a seguir. Link para acesso: https://inspector.swagger.io/builder;
7.1 Caso não tenha a extensão de swagger inspector em seu computador, baixe-a. Usualmente, o próprio swagger avisa quando não há a extensão;
8. Copie o link presente na Home, e copie novamente no swagger nessa barra: ![image](https://user-images.githubusercontent.com/80417466/204278181-10a582ce-1110-4873-8922-64a9f6f67d1a.png)
9. A exemplo, assim: ![image](https://user-images.githubusercontent.com/80417466/204284491-6fb134ea-0c32-428d-b97a-e8aff88c3fbb.png)
10. Depois, clique em "API" e escolha um dos métodos, copie e cole juntamente. Em casos de não for um que pega um nome em específico, só copie o metódo como exemplo: ![image](https://user-images.githubusercontent.com/80417466/204285253-87d1c117-423a-4c37-984b-5dc62e642366.png)
11. Clique em send e espere retornar em Json. Esse exemplo é para os metódos que retornam tudo. Caso seja um de ID ou nome ou qualquer especificação, segue esse exemplo:![image](https://user-images.githubusercontent.com/80417466/204288300-2c1f1d10-f136-43d1-92a9-b663389adde6.png)
12. Depois de executar toda a API, clique em fechar a página do google e pare a execução. Feche o Visual Studio caso necessário. 

## Andamento do projeto

<p align = "center">
<img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>
</p>

## Copyright

Copyright :copyright: 2022 - Spring Library.


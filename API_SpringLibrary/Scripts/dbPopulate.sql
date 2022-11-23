
/* tbEditora */
CALL spcadEdit("Seguinte", 1137073500, 'contato@seguinte.com.br');
CALL spcadEdit("BooKsa", 99999999999, "contato@booksa.com");
CALL spcadEdit("Primier", 45944886612, "primier.contato@gmail.com");
CALL spcadEdit("Darkside", 1136189809, 'vc@darksidebooks.com');
CALL spcadEdit("Intrínseca", 2132067400, 'contato@intrinseca.com.br');
CALL spcadEdit('Arqueiro', 1134560987, 'arqueiro@contato.com.br');

CALL spcheckAllEdit();

CALL spaltEdit(3, "Primier", 1137777777, "primier.contato@gmail.com");

CALL spcheckEditById(3);

/* tbGenero */
CALL spcadGen("Fantasia");
CALL spcadGen("Fikisão-Cientifika");
CALL spcadGen("Distopia");
CALL spcadGen("Ação e Aventura");
CALL spcadGen("Ficção Policial");
CALL spcadGen("Horror");
CALL spcadGen("Thriller e Suspense");
CALL spcadGen("Ficção Histórica");
CALL spcadGen("Romance");
CALL spcadGen("Ficção feminina");
CALL spcadGen("LGBTQ+");
CALL spcadGen("Ficção Comtemporânea");
CALL spcadGen("Realismo Mágico");
CALL spcadGen("Graphic Novel");
CALL spcadGen("Conto");
CALL spcadGen("Young Adult");
CALL spcadGen("New Adult");
CALL spcadGen("Infantil");
CALL spcadGen("Memórias e Autobiografia");
CALL spcadGen("Biografia");
CALL spcadGen("Gastronomia");
CALL spcadGen("Arte e Fotografia");
CALL spcadGen("Autoajuda");
CALL spcadGen("História");
CALL spcadGen("Viajem");
CALL spcadGen("Crimes Reais");
CALL spcadGen("Humor");
CALL spcadGen("Ensaios");
CALL spcadGen("Guias");
CALL spcadGen("Religião e Espiritualidade");
CALL spcadGen("Humanidades e Ciências Sociais");
CALL spcadGen("Paternidade e Família");

CALL spcheckAllGen();

CALL spaltGen(2, "Ficção Científica");

CALL spcheckGenById(2);

/* tbAutor */
CALL spcadAut("Ozcar Wailde");
CALL spcadAut("Lucy Foley");
CALL spcadAut("Mary Shelley");
CALL spcadAut('Lucinda Riley');

CALL spcheckAllAut();

CALL spaltAut(1, "Oscar Wilde");

CALL spcheckAutById(1);

CALL spcadFunc("Leticia", "12345670325", "/Photos/imgFunc/d61d8a0b25028f787123bfff542d3051.png", "11987643239", 'Gerente', "leticiaresina@email.com", "$2a$10$UdE/dABUzjWipHLkC9cy8.TewWva7vGkon0zl1yKrej8.n0Uqz9CO", true);
CALL spcadFunc("Larissa", "34587595128", "/Photos/imgFunc/b96eee05bcc624dfa15a61c5c62e47cb.png", "11987643819", 'Gerente', "larii@email.com", "$2a$10$cVTPmbucXk6J5zC4plf5uOW/nwfbQNCUCpQ/hxl/Eh1KRt.mlCswC", true);
CALL spcadFunc("Gus", "48387121847", "/Photos/imgFunc/3ea38e723c590aabf186367e1eb7e6a1.png", "11958694851", 'Bibliotecário', "pearGus@email.com", "$2a$10$b7goyg40iN95uw9PKMtX2.700UGqpfpHs6V3L5feaI.Q2QAks09xa", true);
CALL spcadFunc("Taveira", "32593825201", "/Photos/imgFunc/e2bb3f9679fec6d4836fcf8abcc3eeac.png", "11987642312", 'Logístico', "taveira.mateus@email.com", "$2a$10$L169gxfwclPif1x6nh8qP.Sxwny6Q5DAtgRMqAe9oSR/1xhVdDUhO", true);
CALL spcadFunc("Erin", "12313821561", "/Photos/imgFunc/96a033ac6a432dcf1e701c9febfe4687.png", "11987643819", 'Logístico', "eriin@email.com", "$2a$10$uvkAzdQ/8aSmhSq7vMjj1up7fKx6yLSuzcWShGcNtlInU7LlHOdz.", true);
CALL spcadFunc("Wesley", "23238210228", "/Photos/imgFunc/b23f665210a1914cab61bc8eba4c9ae0.png", "11987643819", 'Caixa', "wes@email.com", "$2a$10$YP2EW/RL4nNsmcksie454.7r/K6wqAraDMhC5wTkoSm2byQo/Q6zW", true);

CALL spaltFunc(3, "Gustavo", "48387121847", "/Photos/imgFunc/3ea38e723c590aabf186367e1eb7e6a1.png", "11958694851", 'Bibliotecário', "novoEmaildoGus@email.com", "$2a$10$b7goyg40iN95uw9PKMtX2.700UGqpfpHs6V3L5feaI.Q2QAks09xa", true);
CALL spaltFunc(5, "Erin", "12313821561", "/Photos/imgFunc/96a033ac6a432dcf1e701c9febfe4687.png", "11987643819", 'Bibliotecário', "eriin@email.com", "$2a$10$uvkAzdQ/8aSmhSq7vMjj1up7fKx6yLSuzcWShGcNtlInU7LlHOdz.", true);

CALL checkFuncById(3);

SELECT * FROM vwCheckAllFuncs;

/* tbLivro */
call spcadLiv(
	9786555980004,
	'O Retrato de Dorian Gray', 'The Picture of Dorian Gray',
	'Único romance de Oscar Wilde, O Retrato de Dorian Gray combina o apuro literário e estético de seu autor com uma trama sombria, 
	pontuada por paixões, crimes e a brilhante e sarcástica verve wildeana. Publicado em 1890 na revista norte-americana Lippincott’s, 
	o romance foi relançado em livro um ano depois em uma edição que censurou diversos trechos da obra. Dorian Gray primeiramente ofendeu 
	uma geração vitoriana que encontrou na relação entre os amigos Dorian, o jovem retratado, Basil, o pintor apaixonado, e Henry, o lorde 
	cínico, “o amor que não ousava dizer o seu nome”. Depois, fascinou leitores, críticos e artistas, que viram no enredo que remete ao mito 
	de Fausto o Evangelho de um decadentismo que acredita em uma vida de arte, prazer e fascínio sensorial. Tudo isso em meio a um fim de 
	século no qual a convenção e a moralidade corroíam qualquer prazer que a existência humana poderia desfrutar.',
	'https://darkside.vteximg.com.br/arquivos/ids/176889-519-519/o-retrato-de-dorian-gray-0.png?v=637655004666100000',
    1,320,1,2021,30.00,200,true,4,9, 1
);
call spinsertAutLiv(9786555980004, 1);

call spcadLiv('9788594540188','Frankenstin',null,'Sinopse','linkImg',1,283,2,1991,39.99,300,true,4,7, 2);
call spinsertAutLiv(9788594540188, 2);
call spinsertAutLiv(9788594540188, 3);

call spCadLiv(
	'9786555652956',
    'Morte no internato','The Murders at Fleat House',
	'Obra inédita da aclamada Lucinda Riley, Morte no internato é um romance policial com uma 
	trama instigante e a escrita envolvente que se tornaram marca registrada da autora.',
	'https://www.editoraarqueiro.com.br/media/livros_livro/9786555652956.png.200x300_q85_upscale.jpg',
	4,384,1,2022,39.99,29,true,6,7, 2
);
call spinsertAutLiv(9786555652956, 4);

-- Retificando o nome do livro e retirando/recolocando a autora de ID 2
call spaltLivro('9788594540188','Frankenstein',null,'Sinopse','linkImg',1,283,2,1991,39.99,300,0,2,4,7);

select * from vwcheckAllLiv;

select * from vwcheckAllAutInLiv;

/* tbCliFis */
call spcadCliFis('Jesus Youssef', '1199209832', 'jesuscristo@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06300187", 33, 'Casa', 45982221311, '1990-12-25');
call spcadCliFis('Gabriel Bohm Santos', '1199209882', 'kamikat@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06309687", 34, 'Casa', 45226661311, '1996-04-02');
call spcadCliFis('Bianca Lula', '1199309833', 'thaigaloud@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06200087", 22, 'Casa', 45982221333, '1996-01-03');
call spcadCliFis('Thiago Sartori', '1199340822', 'tinownsthiago@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06200087", 22, 'Casa', 45912632311, '1999-05-06');

call spaltCliFis(2, 'Gus Rodrigues', '1194320943', 'gusthienx@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06300187", 33, 'Casa', 45982221222, '1990-12-25');

select * from vwcheckCliFis;

select * from vwcheckAllCli;

call spCheckCliByEmail('jesuscristo@gmail.com');

/* tbCliJur */
call spcadCliJur('Loud', '1136570927', 'loud@suporte.com.br', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', '06210027', 10, 'Bloco 10', "01345846258741", 'LOUD GG', 'Thaiga');
call spcadCliJur('Jornal BG News', '11958424397', 'bgnews@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', '05089000', 678 , null, "15485248562154", 'MIDIAS BGNEWS', 'Madu Gaspar');

call spautCliJur(5, 'Loud e-sports', '11365709287', 'loud@suporte.com.br', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', '06239487', 124, 'Casa', "01345846258741", 'LOUD GG', 'Playhard');
call spautCliJur(6, 'Jornal BG News', '11958424397', 'bgnews@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', '05089000', 678 , null, "15485248562154", 'MIDIAS BGNEWS', 'Madu Gaspar');

select * from vwcheckCliJur;

/* tbCliente */
call spcheckCliByName("Gabriel Bohm Santos");
call spcheckCliByName("Gus Rodrigues");
call spcheckCliByName("Bianca Lula");
call spcheckCliByName("Thiago Sartori");

select * from vwcheckAllCli;

/* tbVenda */
-- Abrindo vendas, colocando, tirando produtos e alterando o status de delivery delas
-- SEMPRE SETAR SET FOREIGN_KEY_CHECKS=0 ANTES DE RODAR OS TESTES --
call spcomecVenda("Dinheiro", 1, false, null);
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555652956",1);

call spcomecVenda("Transferência", 2, true, '2022-10-24');
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004",1);
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004",1);
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555652956",1);
call spaltStatusDeliv((select idDel from tbDelivery order by idVen desc limit 1),2);

call spcomecVenda("Crédito", 3, true, '2022-10-26');
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004",1);
call spdelLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004");
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9788594540188",1);
call spaltStatusDeliv((select idDel from tbDelivery order by idVen desc limit 1),1);

select * from vwcheckAllVenda;

call spcheckAllItemVenda(2);

select * from vwcheckAllDeliv;
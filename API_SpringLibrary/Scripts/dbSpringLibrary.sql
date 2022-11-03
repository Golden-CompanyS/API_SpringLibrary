/* PADRONIZAÇÃO PARA EVITAR INCOERÊNCIAS ENTRE AS APLICAÇÕES
	TABELAS		: tb<NomeDaTabela> ...
	COLUNAS		: <nomeDaColuna><AbrevicaoDoNomeDaTabela> ...
    PROCEDURES	: sp<nomeDaProcedure>(...);
    VARIÁVEIS	: $<nomeDaVariavel>
    
    !! ATENTAR-SE AO CAPSLOCK !!
*/

SET SQL_SAFE_UPDATES = 0;
SET FOREIGN_KEY_CHECKS=0;

create user if not exists 'SpringLibrary'@'localhost' identified with mysql_native_password BY '12345678';
grant all privileges on dbSpringLibrary.* TO 'SpringLibrary'@'localhost' with grant option;

drop database if exists dbspringlibrary;
create database dbspringlibrary;
use dbspringlibrary;

-- =========================================== --
-- == -- == -- == -- Editora -- == -- == -- == --
-- =========================================== --
CREATE TABLE tbEditora(
	idEdit int primary key auto_increment,
    nomEdit varchar(30) not null unique, 
    celEdit char(11) not null,
    emailEdit varchar(30) not null
);

-- cadEditIfNotExists
DELIMITER $$
CREATE PROCEDURE spcadEdit(
	$nomEdit varchar(30),
    $celEdit char(11),
    $emailEdit varchar(30)
)
BEGIN
	IF NOT EXISTS (SELECT nomEdit FROM tbEditora WHERE nomEdit = $nomEdit) THEN
		INSERT INTO tbEditora(nomEdit, celEdit, emailEdit) 
			VALUES ($nomEdit, $celEdit, $emailEdit);
	END IF;
END$$

-- checkAllEdit
DELIMITER $$
CREATE PROCEDURE spcheckAllEdit()
BEGIN
	SELECT * FROM tbEditora;
END$$

-- altEdit
DELIMITER $$
CREATE PROCEDURE spaltEdit(
	$idEdit int,
	$nomEdit varchar(30),
    $celEdit char(11),
    $emailEdit varchar(30)
)
BEGIN
	UPDATE tbEditora SET nomEdit = $nomEdit, celEdit = $celEdit, emailEdit = $emailEdit WHERE idEdit = $idEdit;
END$$

-- checkEditById
DELIMITER $$
CREATE PROCEDURE spcheckEditById(
	$idEdit int
)
BEGIN
	SELECT * FROM tbEditora WHERE idEdit = $idEdit;
END$$

-- ========================================== --
-- == -- == -- == -- Genero -- == -- == -- == --
-- ========================================== --
CREATE TABLE tbGenero(
	idGen int primary key auto_increment,
    nomGen varchar(30) not null
);

-- cadGenIfNotExists
DELIMITER $$
CREATE PROCEDURE spcadGen(
	$nomGen varchar(30)
)
BEGIN
	IF NOT EXISTS (SELECT nomGen FROM tbGenero WHERE nomGen = $nomGen) THEN
		INSERT INTO tbGenero(nomGen) 
			VALUES ($nomGen);
	END IF;
END$$

-- checkAllGen
DELIMITER $$
CREATE PROCEDURE spcheckAllGen()
BEGIN
	SELECT * FROM tbGenero;
END$$

-- altGen
DELIMITER $$
CREATE PROCEDURE spaltGen(
	$idGen int,
	$nomGen varchar(30)
)
BEGIN
	UPDATE tbGenero SET nomGen = $nomGen WHERE idGen = $idGen;
END$$

-- checkGenById
DELIMITER $$
CREATE PROCEDURE spcheckGenById(
	$idGen int
)
BEGIN
	SELECT * FROM tbGenero WHERE idGen = $idGen;
END$$


-- ========================================= --
-- == -- == -- == -- Autor -- == -- == -- == --
-- ========================================= --
CREATE TABLE tbAutor(
	idAut int primary key auto_increment,
    nomAut varchar(100) not null
);

-- cadAutIfNotExists
DELIMITER $$
CREATE PROCEDURE spcadAut(
	$nomAut varchar(100)
)
BEGIN
	IF NOT EXISTS (SELECT nomAut FROM tbAutor WHERE nomAut = $nomAut) THEN
		INSERT INTO tbAutor(nomAut) 
			VALUES ($nomAut);
	END IF;
END$$

-- checkAllAut
DELIMITER $$
CREATE PROCEDURE spcheckAllAut()
BEGIN
	SELECT * FROM tbAutor;
END$$

-- altGen
DELIMITER $$
CREATE PROCEDURE spaltAut(
	$idAut int,
	$nomAut varchar(100)
)
BEGIN
	UPDATE tbAutor SET nomAut = $nomAut WHERE idAut = $idAut;
END$$

-- checkAutById
DELIMITER $$
CREATE PROCEDURE spcheckAutById(
	$idAut int
)
BEGIN
	SELECT * FROM tbAutor WHERE idAut = $idAut;
END$$


-- =============================================== --
-- == -- == -- == -- Funcionário -- == -- == -- == -- 
-- =============================================== --
create table tbFuncionario(
	idFunc int primary key auto_increment,
    nomFunc varchar(50) not null,
    CPFFunc char(11) not null,
    imgFunc varchar(256),
    celFunc char(11) not null,
	cargoFunc varchar(30) not null,
    emailFunc varchar(125) not null,
    senhaFunc varchar(260) not null,
    ativoFunc boolean not null
);

DELIMITER $$
create procedure spcadFunc(
	$nomFunc varchar(50),
	$CPFFunc char(11),
	$imgFunc varchar(256),
	$celFunc char(11),
	$cargoFunc varchar(30),
	$emailFunc varchar(125),
	$senhaFunc varchar(260),
    $ativoFunc boolean)
BEGIN
	insert into tbFuncionario (nomFunc, CPFFunc, imgFunc, cargoFunc, celFunc, emailFunc, senhaFunc, ativoFunc)
    values ($NomFunc, $CPFFunc, $imgFunc, $cargoFunc, $celFunc, $emailFunc, $senhaFunc, $ativoFunc);
END $$

-- spaltFunc
DELIMITER $$
create procedure spaltFunc(
    $idFunc int,
    $nomFunc varchar(50),
    $CPFFunc char(11),
    $imgFunc varchar(256),
    $celFunc char(11),
    $cargoFunc varchar(30),
    $emailFunc varchar(125),
    $senhaFunc varchar(260),
    $ativoFunc boolean)
    BEGIN
         update tbFuncionario set nomFunc=$nomFunc, CPFFunc=$CPFFunc, imgFunc=$imgFunc, 
         cargoFunc=$cargoFunc, celFunc=$celFunc, emailFunc=$emailFunc, senhaFunc=$senhaFunc, ativoFunc = $ativoFunc where idFunc=$idFunc;
    END
$$

-- checkFuncById
DELIMITER $$
CREATE PROCEDURE checkFuncById(
	$idFunc int
)
BEGIN
	SELECT * FROM tbFuncionario WHERE idFunc = $idFunc;
END$$

-- vwCheckAllFuncs
create view vwCheckAllFuncs as select 
	IdFunc as 'ID', 
    nomFunc as 'Nome',
    CPFFunc as 'CPF',
    imgFunc as 'Imagem',
    celFunc 'Telefone Celular',
	cargoFunc as 'Cargo',
    emailFunc as 'Email',
    senhaFunc as 'Senha',
    ativoFunc as 'Situação contratual'
		from tbFuncionario;


-- =============================================== --
-- == -- == -- == -- Livro -- == -- == -- == -- == --
-- =============================================== --
CREATE TABLE tbLivro (
    ISBNLiv CHAR(13) PRIMARY KEY,
    titLiv VARCHAR(100) NOT NULL,
    titOriLiv VARCHAR(100),
    sinopLiv VARCHAR(1500) NOT NULL,
    imgLiv VARCHAR(500) NOT NULL,
	pratLiv SMALLINT NOT NULL,
	numPagLiv SMALLINT NOT NULL,
    numEdicaoLiv SMALLINT NOT NULL,
    anoLiv SMALLINT NOT NULL,
    precoLiv FLOAT(10,2) NOT NULL,
    qtdLiv INT DEFAULT(0),
    ativoLiv boolean,
    idEdit INT NOT NULL,
    FOREIGN KEY (idEdit)
        REFERENCES tbEditora (idEdit),
    idGen INT NOT NULL,
    FOREIGN KEY (idGen)
        REFERENCES tbGenero (idGen),
	idFunc INT NOT NULL,
    FOREIGN KEY (idFunc)
		REFERENCES tbFuncionario (idFunc)
);

-- Tabela necessária para intermediar a relação entre livros e seu(s) atore(s)
CREATE TABLE tbLivroAutor (
	ISBNLiv char(13),
    idAut INT,
    FOREIGN KEY (ISBNLiv)
        REFERENCES tbLivro (ISBNLiv),
    FOREIGN KEY (idAut)
        REFERENCES tbAutor (idAut)
);

-- cadLivIfNotExists
DELIMITER $$
CREATE PROCEDURE spcadLiv(
	$ISBNLiv char(13),
	$titLiv varchar(100),
	$titOriLiv varchar(100), 
	$sinopLiv varchar(1500), 
    $imgLiv varchar(500),
	$pratLiv smallint, 
	$numPagLiv smallint, 
	$numEdicaoLiv smallint, 
	$anoLiv smallint, 
    $precoLiv float(10,2),
    $qtdLiv int,
	$ativoLiv boolean,
	$idEdit int, 
	$idGen int, 
	$idFunc int
)
BEGIN
	IF NOT EXISTS (SELECT ISBNLiv FROM tbLivro WHERE ISBNLiv = $ISBNLiv) THEN
		INSERT INTO tbLivro VALUES
        ($ISBNLiv, $titLiv, $titOriLiv, $sinopLiv, $imgLiv, $pratLiv, $numPagLiv, $numEdicaoLiv, $anoLiv, $precoLiv, $qtdLiv, $ativoLiv, $idEdit, $idGen, $idFunc);
	END IF;
END$$

-- inserir autor no livro
DELIMITER $$
CREATE PROCEDURE spinsertAutLiv(
	$ISBNLiv char(13),
	$idAut int
)
BEGIN
	IF NOT EXISTS (SELECT ISBNLiv FROM tbLivroAutor WHERE ISBNLiv = @ISBNLiv and idAut = $idAut) THEN
        INSERT INTO tbLivroAutor
			VALUES ($ISBNLiv, $idAut);
	END IF;
END $$

DELIMITER $$
create procedure spaltLivro(
	$ISBNLiv char(13),
	$titLiv varchar(100),
	$titOriLiv varchar(100), 
	$sinopLiv varchar(1500), 
    $imgLiv varchar(500),
	$pratLiv smallint, 
	$numPagLiv smallint, 
	$numEdicaoLiv smallint, 
	$anoLiv smallint, 
    $precoLiv float(10,2),
    $qtdLiv int,
	$ativoLiv boolean,
	$idAut int, 
	$idEdit int, 
	$idGen int)
	BEGIN
		UPDATE tbLivro SET
			titLiv = $titLiv, titOriLiv = $titOriLiv, sinopLiv = $sinopLiv, imgLiv = $imgLiv, pratLiv = $pratLiv,
            numPagLiv = $numPagLiv, numEdicaoLiv = $numEdicaoLiv, anoLiv = $anoLiv, precoLiv = $precoLiv, qtdLiv = $qtdLiv,
            ativoLiv = $ativoLiv
            WHERE (ISBNLiv = $ISBNLiv);
		IF EXISTS(SELECT idAut FROM tbLivroAutor WHERE ISBNLiv = $ISBNLiv AND idAut = $idAut) THEN
			DELETE FROM tbLivroAutor WHERE(idAut = $idAut AND ISBNLiv = $ISBNLiv);
        ELSE
			INSERT INTO tbLivroAutor VALUES($ISBNLiv, $idAut);
        END IF;
    END
$$

-- vwcheckAllLiv
create view vwcheckAllLiv as select
	lv.ISBNLiv as 'ISBN',
	titLiv as 'Título', 
    titOriLiv as 'Título original',
    sinopLiv as 'Sinopse',
    imgLiv as 'Link da imagem da capa',
    pratLiv as 'Prateleira',
    numPagLiv as 'Número de páginas',
    numEdicaoLiv as 'Número da edição',
    anoLiv as 'Ano de publicação',
	precoLiv as 'Preço',
    qtdLiv as 'Quantidade no estoque',
    ativoLiv as "Está à venda?",
    nomGen as 'Gênero do livro',
	nomEdit as 'Nome da editora',
    nomFunc as 'Quem cadastrou',
    celEdit as 'Telefone da editora',
    emailEdit as 'Email da editora'
    from tbLivro as lv
			left join tbGenero as gen on lv.IdGen = gen.IdGen
            left join tbEditora as edit on lv.IdEdit = edit.IdEdit
            left join tbFuncionario as func on lv.IdFunc = func.IdFunc;
            
-- vwcheckAllAutInLiv - Ver livros e todos os seus autores
create view vwcheckAllAutInLiv as select
	lv.ISBNLiv as 'ISBN',
	titLiv as 'Título', 
	nomAut as 'Nome do autor'
    from tbAutor as aut
            inner join tbLivroAutor as lva on aut.idAut = lva.idAut
            inner join tbLivro as lv on lva.ISBNLiv = lv.ISBNLiv;


-- =============================================== --
-- == -- == -- == -- Cliente -- == -- == -- == -- ==
-- =============================================== --
CREATE TABLE tbCliente (
	idCli int primary key auto_increment,
    nomCli varchar(100) not null,
    tipoCli boolean not null, -- FALSE para FÍSICO  ///  TRUE para JURÍDICO
	celCli char(11),
    emailCli varchar(125) not null unique,
    senhaCli varchar(260) not null,
	CEPCli char(8) not null,
    numEndCli smallint not null,
    compEndCli varchar(30)
);

-- vwSelectAllCli
create view vwcheckAllCli as select
	idCli as 'ID',
	nomCli as 'Nome', 
    celCli as 'Celular',
    emailCli as 'Email', 
	senhaCli as 'Senha',
    CEPCli as 'CEP',
    numEndCli as 'Número do endereço', 
    compEndCli as 'Complemento' 
		from tbCliente;

-- spCheckCliByUsername
DELIMITER $$
CREATE PROCEDURE spcheckCliByName($vnomCli varchar(100))
BEGIN
	select * from tbCliente WHERE(nomCli = $vnomCli);
END$$

/* Como a tabela tbLivroAutor é composta por foreign keys, FOREIGN_KEY_CHECKS deve ser
mudado para 0, desativando proibição quanto à alteração/exclusão destas */


-- =============================================== --
-- == -- == -- == -- Cliente Físico -- == -- == -- ==
-- =============================================== --
create table tbCliFis(
	CPFCliF char(11) primary key,
	idCli int unique,
    foreign key (idCli) references tbCliente (idCli),
    dtNascCliF date not null
);

-- spInsertCliFis
DELIMITER $$
create procedure spcadCliFis(
	$nomCli varchar(100),
	$celCli char(11),
	$emailCli varchar(125),
	$senhaCli varchar(260),
	$CEPCli char(8),
	$numEndCli smallint,
	$compEndCli varchar(30),
	$CPFCliF char(11),
	$dtNascCliF date)
begin
	if not exists (select CPFCliF from tbCliFis where CPFCliF = $CPFCliF) then
    	insert into tbCliente (nomCli, tipoCli, celCli, emailCli, senhaCli, CEPCli, numEndCli, compEndCli) values 
			 ($nomCli, false, $celCli, $emailCli, $senhaCli, $CEPCli, $numEndCli, $compEndCli);
		insert into tbCliFis (CPFCliF, idCli, dtNascCliF) values
			($CPFCliF, (select idCli from tbCliente order by idCli desc limit 1), $dtNascCliF);
    end if;
end $$

-- spUpdateCliFis
DELIMITER $$
create procedure spaltCliFis(
	$idCli smallint,
	$nomCli varchar(100),
	$celCli varchar(11),
	$emailCli varchar(125),
	$senhaCli varchar(260),
	$CEPCli char(8),
	$numEndCli smallint,
	$compEndCli varchar(30),
	$CPFCliF char(11),
	$dtNascCliF date)
BEGIN
	update tbCliFis set CPFCliF=$CPFCliF, dtNascCliF=$dtNascCliF where idCli=$idCli;
	update tbCliente set nomCli=$nomCli, celCli=$celCli, emailCli=$emailCli, senhaCli=$senhaCli, 
	CEPCli=$CEPCli, numEndCli=$numEndCli, compEndCli=$compEndCli where idCli=$idCli;
END$$

-- vwCheckCliFis
create view vwcheckCliFis as select
	tbCliente.idCli as 'ID',
	nomCli as 'Nome', 
    celCli as 'Celular',
    emailCli as 'Email', 
	senhaCli as 'Senha',
    CEPCli as 'CEP',
    numEndCli as 'Número do endereço', 
    compEndCli as 'Complemento', 
    CPFCliF as 'CPF', 
    dtNascCliF as 'Data de nascimento'
		from tbCliente 
                inner join tbCliFis on tbCliente.idCli = tbCliFis.idCli;

-- =============================================== --
-- == -- == -- == -- Cliente Jurídico -- == -- == -- 
-- =============================================== --
create table tbCliJur(
	CNPJCli char(14) primary key, 
	idCli int unique,
    foreign key (idCli) references tbCliente (idCli),
    fantaCliJ varchar(100) not null,
    represCliJ varchar(50) not null 
);

-- spInsertCliJur
DELIMITER $$
create procedure spcadCliJur(
	$nomCli varchar(100),
	$celCli char(11),
	$emailCli varchar(125),
	$senhaCli varchar(260),
	$CEPCli char(8),
	$numEndCli smallint,
	$compEndCli varchar(30),
	$CNPJCli char(14),
	$fantaCliJ varchar(100),
	$represCliJ varchar(50))
begin
	if not exists (select CNPJCli from tbCliJur where CNPJCli = $CNPJCli) then
    	insert into tbCliente (nomCli, tipoCli, celCli, emailCli, senhaCli, numEndCli, CEPCli, compEndCli) values 
			($nomCli, true, $celCli, $emailCli, $senhaCli, $numEndCli, $CEPCli, $compEndCli);
		insert into tbCliJur (CNPJCli, idCli, fantaCliJ, represCliJ) values
			($CNPJCli, (select idCli from tbCliente order by idCli desc limit 1), $fantaCliJ,  $represCliJ);
    end if;
end $$

-- spUpdateCliJur
DELIMITER $$
	create procedure spautCliJur(
    $idCli smallint,
    $nomCli varchar(100),
    $celCli char(11),
    $emailCli varchar(125),
	$senhaCli varchar(260),
    $CEPCli char(8),
    $numEndCli smallint,
    $compEndCli varchar(30),
	$CNPJCli char(14),
	$fantaCliJ varchar(100),
    $represCliJ varchar(50))
BEGIN
	update tbCliJur set CNPJCli=$CNPJCli, fantaCliJ=$fantaCliJ, represCliJ = $represCliJ where idCli=$idCli;

	update tbCliente set nomCli=$nomCli, celCli=$celCli, emailCli=$emailCli, senhaCli=$senhaCli, 
	CEPCli=$CEPCli, numEndCli=$numEndCli, compEndCli=$compEndCli where idCli=$idCli;
END$$

-- vwCheckCliFis
create view vwcheckCliJur as select
	tbCliente.idCli as 'ID',
	nomCli as 'Nome', 
    celCli as 'Celular',
    emailCli as 'Email', 
	senhaCli as 'Senha',
    CEPCli as 'CEP',
    numEndCli as 'Número do endereço', 
    compEndCli as 'Complemento', 
    CNPJCli as 'CNPJ', 
    fantaCliJ as 'Data de nascimento',
    represCliJ as 'Nome do representante'
		from tbCliente 
                inner join tbCliJur on tbCliente.idCli = tbCliJur.idCli;


-- =============================================== --
-- == -- == -- == -- Venda -- == -- == -- == -- ==
-- =============================================== --
create table tbVenda(
	idVen int primary key auto_increment,
    valTotVen float(10,2),
    delivVen boolean not null,
    dtHoraVen datetime default(current_timestamp()),
    tipoPgtVen varchar(20) not null,
    IdCli int not null,
    foreign key (idCli) references tbCliente(idCli)
);

-- Tabela intermediária necessária para representar itens de uma venda
create table tbItemVenda(
    ISBNLiv char(13) not null,
	idVen int not null,
    qtdIV int not null,
    valTotIV float(10,2) not null,
    foreign key (ISBNLiv) references tbLivro(ISBNLiv),
    foreign key (idVen) references tbVenda(idVen)
);

create table tbDelivery(
	idDel int primary key auto_increment,
    idVen int not null,
    foreign key (idVen) references tbVenda (idVen),
    statDel char(1) not null,
    dtPrevDel date not null,
    dtFinDel date
);

-- spcomecVenda - Abre a venda.
DELIMITER $$
create procedure spcomecVenda(
    $tipoPgtVen varchar(20), 
    $idCli int,
    $delivVen boolean,
    $dtPrevDel date)
begin
	insert into tbVenda (valTotVen, delivVen, dtHoraVen, tipoPgtVen, idCli) values
		(null, $delivVen, default, $tipoPgtVen, $idCli);
	if $delivVen = true then
		insert into tbDelivery(idVen, statDel, dtPrevDel, dtFinDel) values
			((select idVen from tbVenda order by idVen desc limit 1), 0, $dtPrevDel, null);
		end if;
end$$

-- spputLivVenda - Coloca livros numa venda.
DELIMITER $$
create procedure spputLivVenda(
	$idVen int,
	$ISBNLiv char(13),
    $qtdIV int)
begin
	update tbLivro set qtdLiv = qtdLiv - $qtdIV
			where ISBNLiv = $ISBNLiv;
	if not exists (select ISBNLiv from tbItemVenda where ISBNLiv = $ISBNLiv and idVen = $idVen) then
		insert into tbItemVenda values
			($ISBNLiv, $idVen, $qtdIV,
			(select precoLiv * $qtdIV from tbLivro where (ISBNLiv = $ISBNLiv)));
	else
		update tbItemVenda set qtdIV = qtdIV + $qtdIV,
			valTotIV = (select precoLiv * $qtdIV + valTotIV from tbLivro where (ISBNLiv = $ISBNLiv)) 
        where (ISBNLiv = $ISBNLiv and idVen = $idVen);
	end if;
    
	update tbVenda
		set valTotVen = 
        (select sum(valTotIV) from tbItemVenda where
				(idVen = $idVen))
		where idVen = $idVen;
end $$

-- spdelLivVenda - Retira livros de uma venda.
DELIMITER $$
create procedure spdelLivVenda(
	$idVen int,
	$ISBNLiv char(13))
begin
	if exists (select ISBNLiv from tbItemVenda where ISBNLiv = $ISBNLiv and idVen = $idVen) then
		update tbLivro set qtdLiv = qtdLiv - (select qtdIV from tbItemVenda where ISBNLiv = $ISBNLiv and idVen = $idVen)
			where ISBNLiv = $ISBNLiv;
		delete from tbItemVenda where idVen = $idVen and ISBNLiv = $ISBNLiv;
	end if;
    
	update tbVenda
		set valTotVen = 
        (select sum(valTotIV) from tbItemVenda where
				(idVen = $idVen))
		where idVen = $idVen;
end $$

-- spaltStatusDeliv - Altera o status do delivery
DELIMITER $$
create procedure spaltStatusDeliv(
	$idDel int,
	$statDel char(1))
begin
	if $statDel = "2" then
		update tbDelivery set statDel = $statDel, dtFinDel = current_timestamp where idDel = $idDel;
	else
		update tbDelivery set statDel = $statDel where idDel = $idDel;
    end if;
end $$

-- vwcheckAllVenda - Ver todas as vendas
create view vwcheckAllVenda as select 
	idVen as 'ID',
    dtHoraVen as 'Data e hora',
	tbCliente.NomCli as 'Nome do cliente',
    tipoPgtVen as 'Situação de pagamento', 
    valTotVen as 'Valor total',
	delivVen as 'É Delivery?'
		From tbVenda
            inner join tbCliente on tbVenda.idCli = tbCliente.idCli;
     
-- spcheckAllItemVenda - Ver todas os itens de uma venda
DELIMITER $$
create procedure spcheckAllItemVenda($idVen int)
begin
	select 
	tbVenda.idVen as 'ID da venda',
	tbVenda.idVen as 'ID do produto',
	tbLivro.ISBNLiv as 'ISBN',
	tbLivro.titLiv as 'Título',
    tbLivro.precoLiv as 'Preço unitário',
    tbItemVenda.qtdIV as 'Quantidade',
    tbItemVenda.valTotIV as 'Preço'
		from tbVenda
			inner join tbItemVenda on tbVenda.idVen = tbItemVenda.idVen
            inner join tbLivro on tbItemVenda.ISBNLiv = tbLivro.ISBNLiv
		where(tbVenda.idVen = $idVen);
end$$
     
-- vwcheckAllDeliv - Ver todas as vendas com delivery e sua situação
create view vwcheckAllDeliv as select 
	tbVenda.idVen as 'ID',
    dtHoraVen as 'Data e hora',
	tbCliente.NomCli as 'Nome do cliente',
    tipoPgtVen as 'Situação de pagamento', 
    valTotVen as 'Valor total',
    statDel as 'Status do delivery',
    dtPrevDel as 'Previsão de entrega',
    dtFinDel as 'Data de entrega'
		From tbVenda
            inner join tbCliente on tbVenda.idCli = tbCliente.idCli
            inner join tbDelivery on tbVenda.idVen = tbDelivery.idVen;
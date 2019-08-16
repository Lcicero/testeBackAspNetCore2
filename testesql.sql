-- --------------------------------------------------------
-- Servidor:                     localhost
-- Versão do servidor:           5.7.19-log - MySQL Community Server (GPL)
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              10.2.0.5599
-- --------------------------------------------------------


-- Copiando estrutura do banco de dados para teste2
CREATE DATABASE IF NOT EXISTS `teste2` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `teste2`;


-- Copiando estrutura para tabela teste2.livro
CREATE TABLE IF NOT EXISTS `livro` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `Titulo` varchar(100) NOT NULL,
  `Genero` varchar(200) NOT NULL,
  `DataPublicacao` datetime DEFAULT NULL,
  `Pagina` varchar(200) NOT NULL,
  `Autor` varchar(200) NOT NULL,
  `Editora` varchar(200) NOT NULL,
  `LinkURL` varchar(200) DEFAULT NULL,
  `CapaURL` varchar(200) DEFAULT NULL,
  `Descricao` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8 AVG_ROW_LENGTH=630;



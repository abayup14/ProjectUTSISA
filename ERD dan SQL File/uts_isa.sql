CREATE DATABASE  IF NOT EXISTS `uts_isa` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `uts_isa`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: uts_isa
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.25-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `jenis_penggunas`
--

DROP TABLE IF EXISTS `jenis_penggunas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jenis_penggunas` (
  `kode_jenis` varchar(3) NOT NULL,
  `nama` varchar(45) NOT NULL,
  PRIMARY KEY (`kode_jenis`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jenis_penggunas`
--

LOCK TABLES `jenis_penggunas` WRITE;
/*!40000 ALTER TABLE `jenis_penggunas` DISABLE KEYS */;
INSERT INTO `jenis_penggunas` VALUES ('EMP','Employee'),('NSB','Nasabah');
/*!40000 ALTER TABLE `jenis_penggunas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jenis_transaksis`
--

DROP TABLE IF EXISTS `jenis_transaksis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jenis_transaksis` (
  `kode_jenisTransaksi` varchar(45) NOT NULL,
  `nama` varchar(45) NOT NULL,
  PRIMARY KEY (`kode_jenisTransaksi`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jenis_transaksis`
--

LOCK TABLES `jenis_transaksis` WRITE;
/*!40000 ALTER TABLE `jenis_transaksis` DISABLE KEYS */;
INSERT INTO `jenis_transaksis` VALUES ('KRM','Kirim'),('TRM','Terima');
/*!40000 ALTER TABLE `jenis_transaksis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `penggunas`
--

DROP TABLE IF EXISTS `penggunas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `penggunas` (
  `nik` varchar(255) NOT NULL,
  `nama_lengkap` varchar(255) NOT NULL,
  `alamat` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `nomor_telepon` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `foto_diri` varchar(255) NOT NULL,
  `jenis_pengguna_id` varchar(3) NOT NULL,
  PRIMARY KEY (`nik`),
  KEY `fk_pengguna_jenis_pengguna_idx` (`jenis_pengguna_id`),
  CONSTRAINT `fk_pengguna_jenis_pengguna` FOREIGN KEY (`jenis_pengguna_id`) REFERENCES `jenis_penggunas` (`kode_jenis`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `penggunas`
--

LOCK TABLES `penggunas` WRITE;
/*!40000 ALTER TABLE `penggunas` DISABLE KEYS */;
INSERT INTO `penggunas` VALUES ('1','Dummy','Surabaya','dummy@gmail.com','08123123','12345','d','EMP'),('GFUQgojSFjMXUGz/f8aOGw==','VLWSJXreNvPHGo40EtQEMQ==','BNOq/1BWk/sas9tpWV4WYQ==','uPQY97ia6OITfHG0ll8Sig==','oLIhDg677wZ5I6hpvElUhQ==','PKW9Cl19A+V5vMVlQ/oOFw==','D:\\GitHub\\ProjectUTSISA\\foto_stegano\\16_0000000001.png','NSB'),('VakkX+UX9yJrx9w6yyBF2A==','vauqXGia0D2Mk6F95uXbaA==','eZthhzIW9TNvyf3fYhDPvw==','EJzhF0LDcyBG1Hq2oZ3Fu+6LROQJwBZmS4CcdR+ePqA=','QK4FAnLOw7w9ApNoM9/j9A==','JxeYHtOM23r5EzudGmU1SA==','D:\\GitHub\\ProjectUTSISA\\foto_stegano\\16_emp.png','EMP'),('ZHoYpe9eG0RO+QnePfWErA==','hS0Ootoh8VLuTeVeqQrT1g==','P6EIM2vWd7JrX2lnZ1LIzg==','kUfAKun3HqYCm58OrT88zQ==','09cIW44WBV1gBB/nFhjy+Q==','sOqHppQlGTTj3DItR7lwmg==','D:\\GitHub\\ProjectUTSISA\\foto_stegano\\17_0000000002.png','NSB');
/*!40000 ALTER TABLE `penggunas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `public_keys`
--

DROP TABLE IF EXISTS `public_keys`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `public_keys` (
  `public_key` varchar(255) NOT NULL,
  `iv` varchar(255) NOT NULL,
  `penggunas_nik` varchar(255) NOT NULL,
  PRIMARY KEY (`penggunas_nik`),
  KEY `fk_key_penggunas1_idx` (`penggunas_nik`),
  CONSTRAINT `fk_key_penggunas1` FOREIGN KEY (`penggunas_nik`) REFERENCES `penggunas` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `public_keys`
--

LOCK TABLES `public_keys` WRITE;
/*!40000 ALTER TABLE `public_keys` DISABLE KEYS */;
INSERT INTO `public_keys` VALUES ('shQKfQvAJXxYsVTFVLaTLsHg9IxLa9Saa7DATij+kqE=','QWHScyFfN/MiVWnDIiQWhw==','GFUQgojSFjMXUGz/f8aOGw=='),('bSkxVLWiJcQAjiiBoAsWuyHaTlYNTaRNF8tg53OH+eo=','/Olc6C59gjlODkLY49OxEA==','VakkX+UX9yJrx9w6yyBF2A=='),('HitjBUl1QoV+qa5ZEdrZmKpLC8ZjS2hqddnuy2SzGqA=','1+hMmNOTGFLmR4cKdNV9tQ==','ZHoYpe9eG0RO+QnePfWErA==');
/*!40000 ALTER TABLE `public_keys` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rekenings`
--

DROP TABLE IF EXISTS `rekenings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rekenings` (
  `nomor_rekening` varchar(12) NOT NULL,
  `saldo` double NOT NULL,
  `pin` varchar(255) NOT NULL,
  `pengguna_id` varchar(255) NOT NULL,
  PRIMARY KEY (`nomor_rekening`),
  KEY `fk_rekening_pengguna1_idx` (`pengguna_id`),
  CONSTRAINT `fk_rekening_pengguna1` FOREIGN KEY (`pengguna_id`) REFERENCES `penggunas` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rekenings`
--

LOCK TABLES `rekenings` WRITE;
/*!40000 ALTER TABLE `rekenings` DISABLE KEYS */;
INSERT INTO `rekenings` VALUES ('0000000001',1100000,'78k+OB55sIbJeIScaSGv5A==','GFUQgojSFjMXUGz/f8aOGw=='),('0000000002',1900000,'jTepkjs68BicICprQwYsAA==','ZHoYpe9eG0RO+QnePfWErA==');
/*!40000 ALTER TABLE `rekenings` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaksis`
--

DROP TABLE IF EXISTS `transaksis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaksis` (
  `rek_sumber` varchar(12) NOT NULL,
  `rek_tujuan` varchar(12) NOT NULL,
  `waktu_transaksi` datetime NOT NULL,
  `nominal` double NOT NULL,
  `pesan` varchar(50) NOT NULL,
  `jenis_transaksis_id` varchar(45) NOT NULL,
  `nomor_transaksi` varchar(45) NOT NULL,
  PRIMARY KEY (`rek_sumber`,`rek_tujuan`,`nomor_transaksi`),
  KEY `fk_rekening_rekening_rekening2_idx` (`rek_tujuan`),
  KEY `fk_rekening_rekening_rekening1_idx` (`rek_sumber`),
  KEY `fk_transaksis_jenis_transaksis1_idx` (`jenis_transaksis_id`),
  CONSTRAINT `fk_rekening_rekening_rekening1` FOREIGN KEY (`rek_sumber`) REFERENCES `rekenings` (`nomor_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rekening_rekening_rekening2` FOREIGN KEY (`rek_tujuan`) REFERENCES `rekenings` (`nomor_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaksis_jenis_transaksis1` FOREIGN KEY (`jenis_transaksis_id`) REFERENCES `jenis_transaksis` (`kode_jenisTransaksi`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaksis`
--

LOCK TABLES `transaksis` WRITE;
/*!40000 ALTER TABLE `transaksis` DISABLE KEYS */;
INSERT INTO `transaksis` VALUES ('0000000001','0000000002','2023-05-10 14:24:27',100000,'','KRM','0000000001'),('0000000002','0000000001','2023-05-10 14:24:27',100000,'','TRM','0000000002');
/*!40000 ALTER TABLE `transaksis` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-05-10 15:19:47

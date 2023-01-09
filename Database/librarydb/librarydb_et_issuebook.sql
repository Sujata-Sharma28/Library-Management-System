-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: librarydb
-- ------------------------------------------------------
-- Server version	5.7.9-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `et_issuebook`
--

DROP TABLE IF EXISTS `et_issuebook`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `et_issuebook` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `std_enroll` varchar(45) DEFAULT NULL,
  `std_name` varchar(45) DEFAULT NULL,
  `std_dep` varchar(45) DEFAULT NULL,
  `std_sem` varchar(45) DEFAULT NULL,
  `std_contact` varchar(45) DEFAULT NULL,
  `std_email` varchar(45) DEFAULT NULL,
  `book_name` varchar(45) DEFAULT NULL,
  `book_issue_date` varchar(45) DEFAULT NULL,
  `book_return_date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `et_issuebook`
--

LOCK TABLES `et_issuebook` WRITE;
/*!40000 ALTER TABLE `et_issuebook` DISABLE KEYS */;
INSERT INTO `et_issuebook` VALUES (1,'2184200021','Ayush Sharma','2184200021','CS','1st','9123450987','abc','02 December 2022','11 December 2022'),(2,'2184200021','Ayush Sharma','2184200021','CS','1st','9123450987','de','02 December 2022',NULL),(3,'2184200021','Ayush Sharma','2184200021','CS','1st','9123450987','def','02 December 2022',NULL);
/*!40000 ALTER TABLE `et_issuebook` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-09 13:40:35

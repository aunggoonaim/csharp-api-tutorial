-- MySQL dump 10.13  Distrib 8.0.31, for macos12 (x86_64)
--
-- Host: 127.0.0.1    Database: tutorial
-- ------------------------------------------------------
-- Server version	8.0.31

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
-- Table structure for table `user_address_info`
--

DROP TABLE IF EXISTS `user_address_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_address_info` (
  `id` int NOT NULL AUTO_INCREMENT,
  `addr_1` varchar(60) COLLATE utf8mb3_unicode_ci DEFAULT NULL,
  `addr_2` varchar(60) COLLATE utf8mb3_unicode_ci DEFAULT NULL,
  `region` varchar(75) COLLATE utf8mb3_unicode_ci NOT NULL,
  `province` varchar(150) COLLATE utf8mb3_unicode_ci NOT NULL,
  `district` varchar(150) COLLATE utf8mb3_unicode_ci NOT NULL,
  `sub_district` varchar(150) COLLATE utf8mb3_unicode_ci NOT NULL,
  `postcode` varchar(6) COLLATE utf8mb3_unicode_ci NOT NULL,
  `created_user_id` int NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_address_info`
--

LOCK TABLES `user_address_info` WRITE;
/*!40000 ALTER TABLE `user_address_info` DISABLE KEYS */;
/*!40000 ALTER TABLE `user_address_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_info`
--

DROP TABLE IF EXISTS `user_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_info` (
  `id` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `lastname` varchar(100) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `password_hash` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `user_addr_home_id` int DEFAULT NULL,
  `user_addr_current_id` int DEFAULT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `is_actived` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `user_addr_home_idx` (`user_addr_home_id`),
  KEY `user_addr_current_idx` (`user_addr_current_id`),
  CONSTRAINT `user_addr_current` FOREIGN KEY (`user_addr_current_id`) REFERENCES `user_address_info` (`id`),
  CONSTRAINT `user_addr_home` FOREIGN KEY (`user_addr_home_id`) REFERENCES `user_address_info` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_info`
--

LOCK TABLES `user_info` WRITE;
/*!40000 ALTER TABLE `user_info` DISABLE KEYS */;
INSERT INTO `user_info` VALUES (1,'Aunggoon','Arpasunun','aunggoon.a@gmail.com',' ',NULL,NULL,'2022-12-30 08:18:53',1),(2,'Bigboss','Rojjanatinda','bigboss.r@gmail.com',' ',NULL,NULL,'2022-12-30 08:18:53',1);
/*!40000 ALTER TABLE `user_info` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_role`
--

DROP TABLE IF EXISTS `user_role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_role` (
  `id` int NOT NULL AUTO_INCREMENT,
  `role_code` varchar(6) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `role_name` varchar(60) CHARACTER SET utf8mb3 COLLATE utf8mb3_unicode_ci NOT NULL,
  `role_level` int NOT NULL,
  `is_actived` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_role`
--

LOCK TABLES `user_role` WRITE;
/*!40000 ALTER TABLE `user_role` DISABLE KEYS */;
INSERT INTO `user_role` VALUES (1,'ADM','Admin',100,1),(2,'MD','MD',99,1),(3,'GSM','GSM',90,1),(4,'RSM','RSM',80,1),(5,'ASM','ASM',70,1),(6,'SLM','Sales',40,1),(7,'SOP','SalesOperator',50,1),(8,'COM','Company',20,1),(9,'DRI','Driver',10,1),(10,'USR','User',0,1);
/*!40000 ALTER TABLE `user_role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_role_info`
--

DROP TABLE IF EXISTS `user_role_info`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_role_info` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_info_id` int NOT NULL,
  `user_role_id` int NOT NULL,
  `created_date` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `user_id_idx` (`user_info_id`),
  KEY `role_id_idx` (`user_role_id`),
  CONSTRAINT `role_id` FOREIGN KEY (`user_role_id`) REFERENCES `user_role` (`id`),
  CONSTRAINT `user_id` FOREIGN KEY (`user_info_id`) REFERENCES `user_info` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_role_info`
--

LOCK TABLES `user_role_info` WRITE;
/*!40000 ALTER TABLE `user_role_info` DISABLE KEYS */;
INSERT INTO `user_role_info` VALUES (1,1,1,'2022-12-30 08:08:06'),(2,1,9,'2022-12-30 08:08:06');
/*!40000 ALTER TABLE `user_role_info` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-12-30 15:22:40

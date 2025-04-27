CREATE DATABASE  IF NOT EXISTS `dev` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dev`;
-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: dev
-- ------------------------------------------------------
-- Server version	8.0.41

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
-- Table structure for table `codigo`
--

DROP TABLE IF EXISTS `codigo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `codigo` (
  `id` int NOT NULL AUTO_INCREMENT,
  `lenguaje_id` int DEFAULT NULL,
  `nivel` int DEFAULT NULL,
  `segmento` int DEFAULT NULL,
  `codigo` varchar(500) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `lenguaje_id_idx` (`lenguaje_id`),
  CONSTRAINT `lenguaje_id` FOREIGN KEY (`lenguaje_id`) REFERENCES `lenguajes` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `codigo`
--

LOCK TABLES `codigo` WRITE;
/*!40000 ALTER TABLE `codigo` DISABLE KEYS */;
INSERT INTO `codigo` VALUES (8,1,0,1,' '),(9,1,0,2,'public class Main {\n    public static void main(String[] args) {'),(10,1,0,3,'public class Main {\n    public static void main(String[] args) {\n        String nombre = \"Ana\";\n        System.out.println(\"Nombre: \" + nombre);\n    }\n}'),(11,1,1,1,' '),(12,1,1,2,'public class Main {\n    public static void main(String[] args) {\n        private String nombre;\n    }\n}'),(13,1,1,3,'public class Main {\n    public static void main(String[] args) {\n        private String nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n}'),(14,1,1,4,'public class Main {\n    public static void main(String[] args) {\n        private String nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}');
/*!40000 ALTER TABLE `codigo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `estadisticas`
--

DROP TABLE IF EXISTS `estadisticas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `estadisticas` (
  `id` int NOT NULL AUTO_INCREMENT,
  `jugador_estadistica_id` int NOT NULL,
  `prestigio_lenguaje` int DEFAULT '1',
  `bits` bigint DEFAULT '0',
  `clics_totales` int DEFAULT '0',
  `mejoras_totales` int DEFAULT '0',
  `tiempo_jugado` int DEFAULT '0',
  `codigo_nivel` int DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `jugador_estadistica_id_idx` (`jugador_estadistica_id`),
  KEY `prestigio_lenguaje_idx` (`prestigio_lenguaje`),
  CONSTRAINT `jugador_estadistica_id` FOREIGN KEY (`jugador_estadistica_id`) REFERENCES `jugadores` (`id`),
  CONSTRAINT `prestigio_lenguaje` FOREIGN KEY (`prestigio_lenguaje`) REFERENCES `lenguajes` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `estadisticas`
--

LOCK TABLES `estadisticas` WRITE;
/*!40000 ALTER TABLE `estadisticas` DISABLE KEYS */;
INSERT INTO `estadisticas` VALUES (2,1,1,35704747,0,0,0,1),(3,2,1,212,0,0,0,0),(4,3,1,84,0,0,0,0),(5,4,1,8,0,0,0,0),(6,5,1,3736,0,0,0,0),(7,6,1,88,0,0,0,0),(8,7,1,0,0,0,0,0),(9,8,1,0,0,0,0,0),(10,9,1,0,0,0,0,0),(11,10,1,8,0,0,0,0),(12,11,1,0,0,0,0,0),(13,12,1,14679504,0,0,0,0),(14,13,1,0,0,0,0,0),(15,14,1,161,0,0,0,0),(16,15,1,0,0,0,0,0),(17,16,1,0,0,0,0,0),(18,17,1,23533,0,0,0,0),(19,18,1,3304415,0,0,0,0),(20,19,1,278554536,0,0,0,0);
/*!40000 ALTER TABLE `estadisticas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jugadores`
--

DROP TABLE IF EXISTS `jugadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `jugadores` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) COLLATE utf8mb4_spanish_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  UNIQUE KEY `nombre_UNIQUE` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jugadores`
--

LOCK TABLES `jugadores` WRITE;
/*!40000 ALTER TABLE `jugadores` DISABLE KEYS */;
INSERT INTO `jugadores` VALUES (4,'123123'),(14,'12oj34p1'),(10,'ajshdjkashd'),(6,'alksjd'),(12,'alwqe'),(5,'asdasd'),(11,'asdkjasd'),(16,'asdqwe14'),(9,'asfasf'),(17,'askdja+}'),(19,'diego'),(2,'hola'),(13,'iu3qioeqw'),(1,'jorge'),(18,'jorge2'),(3,'kasljda'),(8,'lkajsdkl'),(7,'ñllas'),(15,'qwdq');
/*!40000 ALTER TABLE `jugadores` ENABLE KEYS */;
UNLOCK TABLES;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
/*!50003 CREATE*/ /*!50017 DEFINER=`root`@`localhost`*/ /*!50003 TRIGGER `jugadores_AFTER_INSERT` AFTER INSERT ON `jugadores` FOR EACH ROW BEGIN
    -- Insertar en estadisticas
    INSERT INTO estadisticas (jugador_estadistica_id)
    VALUES (NEW.id);
    
    -- Insertar 6 mejoras para el nuevo jugador
    INSERT INTO mejoras_jugadores (jugador_id, mejora_id, nivel) VALUES
    (NEW.id, 1, 0),
    (NEW.id, 2, 0),
    (NEW.id, 3, 0),
    (NEW.id, 4, 0),
    (NEW.id, 5, 0),
    (NEW.id, 6, 0);
END */;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Table structure for table `lenguajes`
--

DROP TABLE IF EXISTS `lenguajes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lenguajes` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(20) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `descripcion` varchar(200) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lenguajes`
--

LOCK TABLES `lenguajes` WRITE;
/*!40000 ALTER TABLE `lenguajes` DISABLE KEYS */;
INSERT INTO `lenguajes` VALUES (1,'Java','ava es un lenguaje de programación de propósito general, orientado a objetos, multiplataforma y de código abierto');
/*!40000 ALTER TABLE `lenguajes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mejoras`
--

DROP TABLE IF EXISTS `mejoras`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mejoras` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(45) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `descripcion` varchar(200) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  `costo` int DEFAULT NULL,
  `tipo` varchar(20) COLLATE utf8mb4_spanish_ci DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mejoras`
--

LOCK TABLES `mejoras` WRITE;
/*!40000 ALTER TABLE `mejoras` DISABLE KEYS */;
INSERT INTO `mejoras` VALUES (1,'Encapsulamiento','Es la técnica de ocultar la implementación interna de una clase, de modo que solo se puedan acceder y modificar sus datos a través de métodos específicos.',200,'Principios'),(2,'Clases','Es una plantilla o modelo que define las características y comportamientos de un tipo de objeto.',1000,'Principios'),(3,'Herencia','Mecanismo que permite a una clase (clase derivada o subclase) obtener los atributos y métodos de otra clase (clase base o superclase) para reutilizarlos y ampliar su funcionalidad.',5000,'Relaciones'),(4,'Agregación','Forma de asociar objetos donde un objeto \"tiene\" otro, pero la existencia del objeto \"parte\" no depende del objeto \"total\".',10000,'Relaciones'),(5,'Asociación','Relación entre clases que permite a instancias de una clase interactuar con instancias de otra clase.',50000,'Relaciones'),(6,'Bucles','Estructura de control que permite ejecutar un bloque de código repetidamente hasta que se cumpla una condición determinada.',500,'Control');
/*!40000 ALTER TABLE `mejoras` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mejoras_jugadores`
--

DROP TABLE IF EXISTS `mejoras_jugadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `mejoras_jugadores` (
  `jugador_id` int NOT NULL,
  `mejora_id` int NOT NULL,
  `nivel` int DEFAULT '0',
  PRIMARY KEY (`jugador_id`,`mejora_id`),
  KEY `mejora_id_idx` (`mejora_id`),
  CONSTRAINT `jugador_id` FOREIGN KEY (`jugador_id`) REFERENCES `jugadores` (`id`),
  CONSTRAINT `mejora_id` FOREIGN KEY (`mejora_id`) REFERENCES `mejoras` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_spanish_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mejoras_jugadores`
--

LOCK TABLES `mejoras_jugadores` WRITE;
/*!40000 ALTER TABLE `mejoras_jugadores` DISABLE KEYS */;
INSERT INTO `mejoras_jugadores` VALUES (1,1,19),(1,2,16),(1,3,9),(1,4,1),(1,5,2),(1,6,1),(2,1,1),(2,2,0),(2,3,0),(2,4,0),(2,5,0),(2,6,0),(3,1,0),(3,2,0),(3,3,0),(3,4,0),(3,5,0),(3,6,0),(4,1,1),(4,2,0),(4,3,0),(4,4,0),(4,5,0),(4,6,0),(5,1,4),(5,2,0),(5,3,0),(5,4,0),(5,5,0),(5,6,0),(6,1,1),(6,2,0),(6,3,0),(6,4,0),(6,5,0),(6,6,0),(7,1,0),(7,2,0),(7,3,0),(7,4,0),(7,5,0),(7,6,0),(8,1,0),(8,2,0),(8,3,0),(8,4,0),(8,5,0),(8,6,0),(9,1,0),(9,2,0),(9,3,0),(9,4,0),(9,5,0),(9,6,0),(10,1,1),(10,2,0),(10,3,0),(10,4,0),(10,5,0),(10,6,0),(11,1,0),(11,2,0),(11,3,0),(11,4,0),(11,5,0),(11,6,0),(12,1,0),(12,2,0),(12,3,0),(12,4,0),(12,5,0),(12,6,0),(13,1,0),(13,2,0),(13,3,0),(13,4,0),(13,5,0),(13,6,0),(14,1,2),(14,2,2),(14,3,0),(14,4,0),(14,5,0),(14,6,0),(15,1,0),(15,2,0),(15,3,0),(15,4,0),(15,5,0),(15,6,0),(16,1,0),(16,2,0),(16,3,0),(16,4,0),(16,5,0),(16,6,0),(17,1,15),(17,2,10),(17,3,4),(17,4,0),(17,5,0),(17,6,10),(18,1,13),(18,2,0),(18,3,7),(18,4,2),(18,5,6),(18,6,2),(19,1,2),(19,2,0),(19,3,2),(19,4,2),(19,5,8),(19,6,13);
/*!40000 ALTER TABLE `mejoras_jugadores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'dev'
--

--
-- Dumping routines for database 'dev'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-27 16:51:20

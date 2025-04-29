-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema dev
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema dev
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `dev` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_spanish_ci ;
USE `dev` ;

-- -----------------------------------------------------
-- Table `dev`.`lenguajes`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dev`.`lenguajes` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(20) NULL DEFAULT NULL,
  `descripcion` VARCHAR(200) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_spanish_ci;


-- -----------------------------------------------------
-- Table `dev`.`codigo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dev`.`codigo` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `lenguaje_id` INT NULL DEFAULT NULL,
  `nivel` INT NULL DEFAULT NULL,
  `segmento` INT NULL DEFAULT NULL,
  `codigo` VARCHAR(2000) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `lenguaje_id_idx` (`lenguaje_id` ASC) VISIBLE,
  CONSTRAINT `lenguaje_id`
    FOREIGN KEY (`lenguaje_id`)
    REFERENCES `dev`.`lenguajes` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 378
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_spanish_ci;


-- -----------------------------------------------------
-- Table `dev`.`jugadores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dev`.`jugadores` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  UNIQUE INDEX `nombre_UNIQUE` (`nombre` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 32
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_spanish_ci;


-- -----------------------------------------------------
-- Table `dev`.`estadisticas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dev`.`estadisticas` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `jugador_estadistica_id` INT NOT NULL,
  `prestigio_lenguaje` INT NULL DEFAULT '1',
  `bits` BIGINT NULL DEFAULT '0',
  `clics_totales` INT NULL DEFAULT '0',
  `mejoras_totales` INT NULL DEFAULT '0',
  `tiempo_jugado` INT NULL DEFAULT '0',
  `codigo_nivel` INT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE,
  INDEX `jugador_estadistica_id_idx` (`jugador_estadistica_id` ASC) VISIBLE,
  INDEX `prestigio_lenguaje_idx` (`prestigio_lenguaje` ASC) VISIBLE,
  CONSTRAINT `jugador_estadistica_id`
    FOREIGN KEY (`jugador_estadistica_id`)
    REFERENCES `dev`.`jugadores` (`id`),
  CONSTRAINT `prestigio_lenguaje`
    FOREIGN KEY (`prestigio_lenguaje`)
    REFERENCES `dev`.`lenguajes` (`id`))
ENGINE = InnoDB
AUTO_INCREMENT = 33
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_spanish_ci;


-- -----------------------------------------------------
-- Table `dev`.`mejoras`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dev`.`mejoras` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NULL DEFAULT NULL,
  `descripcion` VARCHAR(200) NULL DEFAULT NULL,
  `costo` INT NULL DEFAULT NULL,
  `tipo` VARCHAR(20) NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 7
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_spanish_ci;


-- -----------------------------------------------------
-- Table `dev`.`mejoras_jugadores`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dev`.`mejoras_jugadores` (
  `jugador_id` INT NOT NULL,
  `mejora_id` INT NOT NULL,
  `nivel` INT NULL DEFAULT '0',
  PRIMARY KEY (`jugador_id`, `mejora_id`),
  INDEX `mejora_id_idx` (`mejora_id` ASC) VISIBLE,
  CONSTRAINT `jugador_id`
    FOREIGN KEY (`jugador_id`)
    REFERENCES `dev`.`jugadores` (`id`),
  CONSTRAINT `mejora_id`
    FOREIGN KEY (`mejora_id`)
    REFERENCES `dev`.`mejoras` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_spanish_ci;

USE `dev`;

DELIMITER $$
USE `dev`$$
CREATE
DEFINER=`root`@`localhost`
TRIGGER `dev`.`jugadores_AFTER_INSERT`
AFTER INSERT ON `dev`.`jugadores`
FOR EACH ROW
BEGIN
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
END$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;

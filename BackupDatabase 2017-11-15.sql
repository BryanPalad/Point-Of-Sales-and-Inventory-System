-- MySqlBackup.NET 2.0.9.2
-- Dump Time: 2017-11-15 19:11:54
-- --------------------------------------
-- Server version 5.6.12-log MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of addproduct
-- 

DROP TABLE IF EXISTS `addproduct`;
CREATE TABLE IF NOT EXISTS `addproduct` (
  `ProductNo` int(11) NOT NULL AUTO_INCREMENT,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Units` varchar(50) NOT NULL,
  PRIMARY KEY (`ProductNo`,`Productname`)
) ENGINE=InnoDB AUTO_INCREMENT=994505 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table addproduct
-- 

/*!40000 ALTER TABLE `addproduct` DISABLE KEYS */;
INSERT INTO `addproduct`(`ProductNo`,`Productname`,`Category`,`Units`) VALUES
(994504,'Semento','Cements','Sack');
/*!40000 ALTER TABLE `addproduct` ENABLE KEYS */;

-- 
-- Definition of audit
-- 

DROP TABLE IF EXISTS `audit`;
CREATE TABLE IF NOT EXISTS `audit` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Userlevel` varchar(50) NOT NULL,
  `Access` varchar(50) NOT NULL,
  `Time` varchar(50) NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=177 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table audit
-- 

/*!40000 ALTER TABLE `audit` DISABLE KEYS */;
INSERT INTO `audit`(`ID`,`Username`,`Userlevel`,`Access`,`Time`,`Date`) VALUES
(1,'','Administrator','The Administrator removed category''Tiles''','1:51:12 PM','2017-10-24 00:00:00'),
(2,'','Administrator','The Administrator saved category''''','1:53:07 PM','2017-10-24 00:00:00'),
(3,'','Administrator','The Administrator removed''Concrete''','12:55:08 PM','2017-10-25 00:00:00'),
(4,'','Administrator','The Administrator add product''Boysen''','1:21:38 PM','2017-10-25 00:00:00'),
(5,'','Administrator','The Administrator add product''Concrete''','3:00:06 PM','2017-10-25 00:00:00'),
(6,'','Administrator','The Administrator removed''Boysen''','10:29:36 AM','2017-10-26 00:00:00'),
(7,'','Administrator','The Administrator removed''Eagle''','10:29:41 AM','2017-10-26 00:00:00'),
(8,'','Administrator','The Administrator add product''Boysen''','10:31:36 AM','2017-10-26 00:00:00'),
(9,'','Administrator','The Administrator add product''Eagle''','10:31:46 AM','2017-10-26 00:00:00'),
(10,'','Administrator','The Administrator add product''Concrete''','10:31:53 AM','2017-10-26 00:00:00'),
(11,'','Administrator','The Administrator removed''Boysen''','10:39:27 AM','2017-10-26 00:00:00'),
(12,'','Administrator','The Administrator removed''Concrete''','10:39:29 AM','2017-10-26 00:00:00'),
(13,'','Administrator','The Administrator removed''Eagle''','10:45:57 AM','2017-10-26 00:00:00'),
(14,'','Administrator','The Administrator removed''Concrete''','10:57:12 AM','2017-10-26 00:00:00'),
(15,'','Administrator','The Administrator modified ''Eagle''','11:00:43 AM','2017-10-26 00:00:00'),
(16,'','Administrator','The Administrator modified ''Eagle''','11:05:05 AM','2017-10-26 00:00:00'),
(17,'','Administrator','The Administrator add product''Boysen''','11:06:49 AM','2017-10-26 00:00:00'),
(18,'','Administrator','The Administrator modified ''Boysen''','11:08:58 AM','2017-10-26 00:00:00'),
(19,'','Administrator','The Administrator add product''Concrete''','11:11:11 AM','2017-10-26 00:00:00'),
(20,'','Administrator','The Administrator modified ''Concrete''','11:12:40 AM','2017-10-26 00:00:00'),
(21,'','Administrator','The Administrator removed''Boysen''','11:12:44 AM','2017-10-26 00:00:00'),
(22,'','Administrator','The Administrator removed''Eagle''','11:12:46 AM','2017-10-26 00:00:00'),
(23,'','Administrator','The Administrator updated ''Boysen''','11:17:25 AM','2017-10-26 00:00:00'),
(24,'','Administrator','The Administrator updated ''Boysen''','11:18:54 AM','2017-10-26 00:00:00'),
(25,'','Administrator','The Administrator returned ''Boysen''','11:32:01 AM','2017-10-26 00:00:00'),
(26,'','Administrator','The Administrator prints all the products ','11:33:44 AM','2017-10-26 00:00:00'),
(27,'','Administrator','The Administrator prints all the products ','11:34:22 AM','2017-10-26 00:00:00'),
(28,'','Administrator','The Administrator prints all the products ','11:35:07 AM','2017-10-26 00:00:00'),
(29,'','Administrator','The Administrator added supplier''Paint Company''','11:41:35 AM','2017-10-26 00:00:00'),
(30,'','Administrator','The Administrator add product''Davies''','11:45:59 AM','2017-10-26 00:00:00'),
(31,'','Administrator','The Administrator add product''Palochina''','11:55:09 AM','2017-10-26 00:00:00'),
(32,'','Administrator','The Administrator added supplier''Wood Company''','11:55:33 AM','2017-10-26 00:00:00'),
(33,'','Administrator','The Administrator add product''Palochina''','12:30:26 PM','2017-10-26 00:00:00'),
(34,'','Administrator','The Administrator add product''Davies''','12:30:36 PM','2017-10-26 00:00:00'),
(35,'','Administrator','The Administrator removed''Davies''','12:33:58 PM','2017-10-26 00:00:00'),
(36,'','Administrator','The Administrator add product''Davies''','12:36:25 PM','2017-10-26 00:00:00'),
(37,'','Administrator','The Administrator removed''Davies''','12:38:03 PM','2017-10-26 00:00:00'),
(38,'','Administrator','The Administrator removed''Palochina''','12:38:06 PM','2017-10-26 00:00:00'),
(39,'','Administrator','The Administrator add product''Davies''','12:38:27 PM','2017-10-26 00:00:00'),
(40,'','Administrator','The Administrator add product''Palochina''','12:38:41 PM','2017-10-26 00:00:00'),
(41,'','Administrator','The Administrator removed''Palochina''','1:14:34 PM','2017-10-26 00:00:00'),
(42,'','Administrator','The Administrator add product''Palochina''','1:14:59 PM','2017-10-26 00:00:00'),
(43,'','Administrator','The Administrator add product''Palochina''','1:16:15 PM','2017-10-26 00:00:00'),
(44,'','Administrator','The Administrator add product''Palochina''','1:19:08 PM','2017-10-26 00:00:00'),
(45,'','Administrator','The Administrator add product''Aldrin''','2:34:41 PM','2017-10-27 00:00:00'),
(46,'','Administrator','The Administrator returned ''Concrete''','3:22:08 PM','2017-10-27 00:00:00'),
(47,'','Administrator','The Administrator returned ''Concrete''','10:32:01 AM','2017-10-28 00:00:00'),
(48,'','Administrator','The Administrator unavailable ''Concrete''','10:35:49 AM','2017-10-28 00:00:00'),
(49,'','Administrator','The Administrator returned ''Boysen''','2:13:32 PM','2017-10-28 00:00:00'),
(50,'','Administrator','The Administrator modified ''Palochina''','2:14:49 PM','2017-10-28 00:00:00'),
(51,'','Administrator','The Administrator modified ''Aldrin''','3:10:20 PM','2017-10-28 00:00:00'),
(52,'','Administrator','The Administrator available the product''Concrete''','3:13:57 PM','2017-10-28 00:00:00'),
(53,'','Administrator','The Administrator add product''Boysen''','4:01:58 PM','2017-10-28 00:00:00'),
(54,'','Administrator','The Administrator add product''Eagle ''','4:04:27 PM','2017-10-28 00:00:00'),
(55,'','Administrator','The Administrator add product''Davies''','4:04:44 PM','2017-10-28 00:00:00'),
(56,'','Administrator','The Administrator add product''Concrete''','4:04:58 PM','2017-10-28 00:00:00'),
(57,'','Administrator','The Administrator add product''Palochina''','4:05:38 PM','2017-10-28 00:00:00'),
(58,'','Administrator','The Administrator modified ''Boysen''','4:46:34 PM','2017-10-28 00:00:00'),
(59,'','Administrator','The Administrator modified ''Concrete''','4:46:51 PM','2017-10-28 00:00:00'),
(60,'','Administrator','The Administrator modified ''Davies''','4:47:08 PM','2017-10-28 00:00:00'),
(61,'','Administrator','The Administrator modified ''Eagle ''','4:47:32 PM','2017-10-28 00:00:00'),
(62,'','Administrator','The Administrator modified ''Palochina''','4:47:44 PM','2017-10-28 00:00:00'),
(63,'','Administrator','The Administrator add stocks in product''Davies''','1:49:44 PM','2017-10-29 00:00:00'),
(64,'','Administrator','The Administrator returned ''Boysen''','2:40:19 PM','2017-10-29 00:00:00'),
(65,'','Administrator','The Administrator returned ''Davies''','2:42:28 PM','2017-10-29 00:00:00'),
(66,'','Administrator','The Administrator returned ''Davies''','2:42:35 PM','2017-10-29 00:00:00'),
(67,'','Administrator','The Administrator returned ''Eagle ''','2:42:43 PM','2017-10-29 00:00:00'),
(68,'','Administrator','The Administrator add product''Firefly''','11:31:56 PM','2010-01-09 00:00:00'),
(69,'','Administrator','The Administrator added supplier''Bulb Company''','11:36:21 PM','2010-01-09 00:00:00'),
(70,'Time Here','Administrator','The Administrator get items from''Bulb Company''','9:13:06 PM','2017-10-29 00:00:00'),
(71,'','Administrator','The Administrator added supplier''Cement Company''','8:20:09 PM','2017-10-31 00:00:00'),
(72,'','Administrator','The Administrator added supplier''Paint Company''','8:23:44 PM','2017-10-31 00:00:00'),
(73,'','Administrator','The Administrator added supplier''Nail Company''','8:24:22 PM','2017-10-31 00:00:00'),
(74,'','Administrator','The Administrator added supplier''Bulb Company''','8:25:05 PM','2017-10-31 00:00:00'),
(75,'','Administrator','The Administrator added supplier''Wood Company''','8:25:38 PM','2017-10-31 00:00:00'),
(76,'','Administrator','The Administrator removed''Firefly''','8:26:39 PM','2017-10-31 00:00:00'),
(77,'','Administrator','The Administrator add product''Firefly''','8:26:57 PM','2017-10-31 00:00:00'),
(78,'','Administrator','The Administrator add product''Rizal ''','8:28:04 PM','2017-10-31 00:00:00'),
(79,'Time Here','Administrator','The Administrator get all items from''Bulb Company''','8:44:50 PM','2017-10-31 00:00:00'),
(80,'Time Here','Administrator','The Administrator get all items from''Cement Compan','8:44:53 PM','2017-10-31 00:00:00'),
(81,'','Administrator','The Administrator modified ''Firefly''','8:45:18 PM','2017-10-31 00:00:00'),
(82,'','Administrator','The Administrator modified ''Rizal ''','8:45:38 PM','2017-10-31 00:00:00'),
(83,'Time Here','Administrator','The Administrator get all items from''Bulb Company''','12:23:12 PM','2017-11-02 00:00:00'),
(84,'','Administrator','The Administrator removed''Firefly''','12:43:30 PM','2017-11-02 00:00:00'),
(85,'','Administrator','The Administrator add product''Pako''','12:44:42 PM','2017-11-02 00:00:00'),
(86,'Time Here','Administrator','The Administrator get items from''Nail Company''','2:35:27 PM','2017-11-02 00:00:00'),
(87,'','Administrator','The Administrator add product''Pako''','2:40:47 PM','2017-11-02 00:00:00'),
(88,'','Administrator','The Administrator add product''Semento''','10:34:25 AM','2017-11-03 00:00:00'),
(89,'Time Here','Administrator','The Administrator get items from''Cement Company''','10:36:36 AM','2017-11-03 00:00:00'),
(90,'','Administrator','The Administrator saved category''norris''','11:14:42 AM','2017-11-03 00:00:00'),
(91,'','Administrator','The Administrator saved category''tae''','11:15:22 AM','2017-11-03 00:00:00'),
(92,'','Administrator','The Administrator add product''asdasd''','11:16:24 AM','2017-11-03 00:00:00'),
(93,'','Administrator','The Administrator add product''asd''','11:19:26 AM','2017-11-03 00:00:00'),
(94,'','Administrator','The Administrator add product''kasdhs''','11:19:33 AM','2017-11-03 00:00:00'),
(95,'','Administrator','The Administrator add product''hgasdhgas''','11:19:40 AM','2017-11-03 00:00:00'),
(96,'','Administrator','The Administrator saved category''gg''','11:47:18 AM','2017-11-03 00:00:00'),
(97,'','Administrator','The Administrator add''bry'' to categories','11:47:51 AM','2017-11-03 00:00:00'),
(98,'','Administrator','The Administrator add''CHE'' to categories','12:43:38 PM','2017-11-03 00:00:00'),
(99,'','Administrator','The Administrator removed category''bry''','7:51:53 PM','2017-11-03 00:00:00'),
(100,'','Administrator','The Administrator removed category''CHE''','7:51:58 PM','2017-11-03 00:00:00'),
(101,'','Administrator','The Administrator removed category''gg''','7:52:01 PM','2017-11-03 00:00:00'),
(102,'','Administrator','The Administrator removed category''tae''','7:52:05 PM','2017-11-03 00:00:00'),
(103,'','Administrator','The Administrator removed category''norris''','7:52:10 PM','2017-11-03 00:00:00'),
(104,'','Administrator','The Administrator add product''Langis''','7:52:50 PM','2017-11-03 00:00:00'),
(105,'','Administrator','The Administrator add product''Bubong''','7:53:10 PM','2017-11-03 00:00:00'),
(106,'','Administrator','The Administrator add product''Semento''','8:09:04 PM','2017-11-03 00:00:00'),
(107,'','Administrator','The Administrator add product''Lagare''','8:09:53 PM','2017-11-03 00:00:00'),
(108,'Time Here','Administrator','The Administrator get all items from''Nail Company''','8:48:41 PM','2017-11-03 00:00:00'),
(109,'Time Here','Administrator','The Administrator get all items from''Cement Compan','9:04:33 PM','2017-11-03 00:00:00'),
(110,'','Administrator','The Administrator add product''Pako''','9:05:21 PM','2017-11-03 00:00:00'),
(111,'','Administrator','The Administrator add product''Semento''','9:05:35 PM','2017-11-03 00:00:00'),
(112,'','Administrator','The Administrator add product''Pako''','9:08:40 PM','2017-11-03 00:00:00'),
(113,'','Administrator','The Administrator add product''Semento''','9:09:00 PM','2017-11-03 00:00:00'),
(114,'','Administrator','The Administrator add product''Semento''','9:44:13 PM','2017-11-03 00:00:00'),
(115,'','Administrator','The Administrator add product''Pako''','9:44:21 PM','2017-11-03 00:00:00'),
(116,'','Administrator','The Administrator add product''Pako''','12:19:49 PM','2017-11-04 00:00:00'),
(117,'','Administrator','The Administrator add product''Semento''','12:20:12 PM','2017-11-04 00:00:00'),
(118,'','Administrator','The Administrator added supplier''Clyde Company''','12:21:29 PM','2017-11-04 00:00:00'),
(119,'','Administrator','The Administrator add product''Semento''','12:39:50 PM','2017-11-04 00:00:00'),
(120,'','Administrator','The Administrator add product''Pako''','12:57:07 PM','2017-11-04 00:00:00'),
(121,'','Administrator','The Administrator add product''Semento''','12:57:22 PM','2017-11-04 00:00:00'),
(122,'','Administrator','The Administrator add product''Rhea''','2:12:48 PM','2017-11-04 00:00:00'),
(123,'','Administrator','The Administrator add product''Bry''','2:12:55 PM','2017-11-04 00:00:00'),
(124,'','Administrator','The Administrator add product''asd''','2:17:59 PM','2017-11-04 00:00:00'),
(125,'Time Here','Administrator','The Administrator get items from''Clyde Company''','2:19:00 PM','2017-11-04 00:00:00'),
(126,'','Administrator','The Administrator add product''wqdasd''','2:20:12 PM','2017-11-04 00:00:00'),
(127,'','Administrator','The Administrator add product''asd''','2:40:28 PM','2017-11-04 00:00:00'),
(128,'','Administrator','The Administrator add product''ALDRIN''','4:30:45 PM','2017-11-04 00:00:00'),
(129,'','Administrator','The Administrator add product''Allen''','4:32:16 PM','2017-11-04 00:00:00'),
(130,'','Administrator','The Administrator add product''asDASD''','5:17:08 PM','2017-11-04 00:00:00'),
(131,'','Administrator','The Administrator add product''Boy''','6:46:44 PM','2017-11-04 00:00:00'),
(132,'','Administrator','The Administrator add product''Bubong''','9:03:35 PM','2017-11-04 00:00:00'),
(133,'','Administrator','The Administrator add product''Pako''','9:08:01 PM','2017-11-04 00:00:00'),
(134,'','Administrator','The Administrator add product''Bubong''','9:11:47 PM','2017-11-04 00:00:00'),
(135,'','Administrator','The Administrator add product''Pako''','9:12:20 PM','2017-11-04 00:00:00'),
(136,'','Administrator','The Administrator add product''Bubong''','9:12:27 PM','2017-11-04 00:00:00'),
(137,'','Administrator','The Administrator add product''Pako''','9:17:39 PM','2017-11-04 00:00:00'),
(138,'','Administrator','The Administrator add product''Bubong''','9:17:44 PM','2017-11-04 00:00:00'),
(139,'','Administrator','The Administrator add product''Pako''','9:19:45 PM','2017-11-04 00:00:00'),
(140,'','Administrator','The Administrator add product''Bubong''','9:19:50 PM','2017-11-04 00:00:00'),
(141,'','Administrator','The Administrator add product''Pako''','9:26:22 PM','2017-11-04 00:00:00'),
(142,'','Administrator','The Administrator add product''Bubong''','9:26:27 PM','2017-11-04 00:00:00'),
(143,'','Administrator','The Administrator add product''Pako''','9:28:31 PM','2017-11-04 00:00:00'),
(144,'','Administrator','The Administrator add product''Bubong''','9:28:36 PM','2017-11-04 00:00:00'),
(145,'','Administrator','The Administrator add product''Pako''','9:29:54 PM','2017-11-04 00:00:00'),
(146,'','Administrator','The Administrator add product''Bubong''','9:30:00 PM','2017-11-04 00:00:00'),
(147,'Time Here','Administrator','The Administrator get all items from''Cement Compan','9:35:48 PM','2017-11-04 00:00:00'),
(148,'Time Here','Administrator','The Administrator get all items from''Cement Compan','9:49:14 PM','2017-11-04 00:00:00'),
(149,'','Administrator','The Administrator add product''Pako''','9:50:05 PM','2017-11-04 00:00:00'),
(150,'','Administrator','The Administrator add product''Bubong''','9:50:10 PM','2017-11-04 00:00:00'),
(151,'Time Here','Administrator','The Administrator get all items from''Cement Compan','9:52:46 PM','2017-11-04 00:00:00'),
(152,'','Administrator','The Administrator removed''Bubong''','10:08:35 PM','2017-11-04 00:00:00'),
(153,'','Administrator','The Administrator add product''Bubong''','10:08:45 PM','2017-11-04 00:00:00'),
(154,'','Administrator','The Administrator add product''Pako''','10:08:51 PM','2017-11-04 00:00:00'),
(155,'Time Here','Administrator','The Administrator get items from''Cement Company''','10:10:09 PM','2017-11-04 00:00:00'),
(156,'Time Here','Administrator','The Administrator get items from''Cement Company''','10:10:25 PM','2017-11-04 00:00:00'),
(157,'','Administrator','The Administrator modified ''Bubong''','10:11:59 PM','2017-11-04 00:00:00'),
(158,'','Administrator','The Administrator modified ''Pako''','10:12:08 PM','2017-11-04 00:00:00'),
(159,'','Administrator','The Administrator add product''pako''','9:42:16 AM','2017-11-06 00:00:00'),
(160,'','Administrator','The Administrator add product''Bubong''','9:42:28 AM','2017-11-06 00:00:00'),
(161,'Time Here','Administrator','The Administrator get all items from''Cement Compan','10:00:27 AM','2017-11-06 00:00:00'),
(162,'Time Here','Administrator','The Administrator get all items from''Cement Compan','10:00:33 AM','2017-11-06 00:00:00'),
(163,'','Administrator','The Administrator removed''Bubong''','10:01:15 AM','2017-11-06 00:00:00'),
(164,'','Administrator','The Administrator removed''Pako''','10:01:19 AM','2017-11-06 00:00:00'),
(165,'','Administrator','The Administrator add product''Concrete 1''','10:01:51 AM','2017-11-06 00:00:00'),
(166,'','Administrator','The Administrator add product''Pako''','10:02:05 AM','2017-11-06 00:00:00'),
(167,'','Administrator','The Administrator add product''RainOrShine''','10:02:30 AM','2017-11-06 00:00:00'),
(168,'','Administrator','The Administrator add product''Concrete 1''','7:14:14 PM','2017-11-06 00:00:00'),
(169,'Time Here','Administrator','The Administrator get all items from''Cement Compan','7:15:18 PM','2017-11-06 00:00:00'),
(170,'','Administrator','The Administrator add product''Tae''','8:04:46 PM','2017-11-06 00:00:00'),
(171,'','Administrator','The Administrator add product''asd''','8:05:55 PM','2017-11-06 00:00:00'),
(172,'Time Here','Administrator','The Administrator get items from''Cement Company''','8:07:37 PM','2017-11-06 00:00:00'),
(173,'','Administrator','The Administrator modified ''Concrete 1''','8:10:24 PM','2017-11-06 00:00:00'),
(174,'','Administrator','The Administrator add product''Pako''','2:17:33 PM','2017-11-09 00:00:00'),
(175,'','Administrator','The Administrator add product''Semento''','2:17:44 PM','2017-11-09 00:00:00'),
(176,'','Administrator','The Administrator returned ''Davies''','2:20:33 PM','2017-11-09 00:00:00');
/*!40000 ALTER TABLE `audit` ENABLE KEYS */;

-- 
-- Definition of backorder
-- 

DROP TABLE IF EXISTS `backorder`;
CREATE TABLE IF NOT EXISTS `backorder` (
  `Supplier_id` int(11) NOT NULL,
  `suppliercompany` varchar(50) NOT NULL,
  `Productno` int(11) NOT NULL,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Units` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `ponumber` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table backorder
-- 

/*!40000 ALTER TABLE `backorder` DISABLE KEYS */;
INSERT INTO `backorder`(`Supplier_id`,`suppliercompany`,`Productno`,`Productname`,`Category`,`Units`,`Quantity`,`ponumber`) VALUES
(1,'Cement Company',648017,'asd','Bulbs','Kilo',50,123456),
(1,'Cement Company',961414,'Boysen','Paints','Gallon',200,0);
/*!40000 ALTER TABLE `backorder` ENABLE KEYS */;

-- 
-- Definition of categories
-- 

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `Number` int(11) NOT NULL AUTO_INCREMENT,
  `Category` varchar(250) NOT NULL,
  PRIMARY KEY (`Number`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table categories
-- 

/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories`(`Number`,`Category`) VALUES
(1,'Screws'),
(2,'Wires'),
(5,'Locks'),
(6,'Bulbs'),
(7,'Paints'),
(10,'Cements'),
(11,'Brushes'),
(12,'Faucet'),
(13,'Saw'),
(16,'Oils'),
(17,'Doorknobs'),
(18,'Woods'),
(19,'Nails'),
(20,'Roofs'),
(21,'Steels'),
(23,'Doors');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;

-- 
-- Definition of defect
-- 

DROP TABLE IF EXISTS `defect`;
CREATE TABLE IF NOT EXISTS `defect` (
  `Date` date NOT NULL,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table defect
-- 

/*!40000 ALTER TABLE `defect` DISABLE KEYS */;
INSERT INTO `defect`(`Date`,`Productname`,`Category`,`Quantity`) VALUES
('2017-10-12 00:00:00','Rain or Shine','Paints',2),
('2017-10-13 00:00:00','Firefly','Bulbs',300),
('2017-10-13 00:00:00','Boysen','Paints',40),
('2017-10-13 00:00:00','Rain or Shine','Paints',490),
('2017-10-14 00:00:00','Rain or Shine','Paints',150),
('2017-10-14 00:00:00','Rain or Shine','Paints',5),
('2017-10-14 00:00:00','Firefly','Bulbs',230),
('2017-10-14 00:00:00','Boysen','Paints',100),
('2017-10-14 00:00:00','Firefly','Bulbs',100),
('2017-10-14 00:00:00','Boysen','Paints',300),
('2017-10-14 00:00:00','Boysen','Paints',200),
('2017-10-14 00:00:00','Boysen','Paints',300),
('2017-10-15 00:00:00','Firefly','Bulbs',130),
('2017-10-15 00:00:00','Davies','Paints',400),
('2017-10-15 00:00:00','Palochina','Woods',200),
('2017-10-15 00:00:00','Rizal Cement','Cements',500),
('2017-10-15 00:00:00','Boysen','Paints',400),
('2017-10-15 00:00:00','Rain or Shine','Paints',100),
('2017-10-15 00:00:00','Rain or Shine','Paints',50),
('2017-10-15 00:00:00','Bakal','Steels',500),
('2017-10-17 00:00:00','Boysen','Paints',300),
('2017-10-17 00:00:00','Palochina','Woods',200),
('2017-10-17 00:00:00','Palochina','Woods',30),
('2017-10-17 00:00:00','Davies','Paints',23),
('2017-10-19 00:00:00','Firefly','Bulbs',100),
('2017-10-20 00:00:00','Boysen','Paints',200),
('2017-10-21 00:00:00','Davies','Paints',400),
('2017-10-21 00:00:00','Davies','Paints',200),
('2017-10-21 00:00:00','Davies','Paints',150),
('2017-10-21 00:00:00','Davies','Paints',999),
('2017-10-21 00:00:00','Davies','Paints',499),
('2017-10-21 00:00:00','Davies','Paints',199),
('2017-10-21 00:00:00','Bakal','Steels',40),
('2017-10-21 00:00:00','Firefly','Bulbs',10),
('2017-10-21 00:00:00','Firefly','Bulbs',5),
('2017-10-21 00:00:00','Rain or Shine','Paints',100),
('2017-10-21 00:00:00','Rain or Shine','Paints',50),
('2017-10-21 00:00:00','Boysen','Paints',200),
('2017-10-21 00:00:00','Palochina','Woods',400),
('2017-10-26 00:00:00','Boysen','Paints',100),
('2017-10-27 00:00:00','Concrete','Nails',100),
('2017-10-28 00:00:00','Concrete','Nails',94),
('2017-10-28 00:00:00','Boysen','Paints',200),
('2017-10-29 00:00:00','Boysen','Paints',75),
('2017-10-29 00:00:00','Davies','Paints',200),
('2017-10-29 00:00:00','Davies','Paints',100),
('2017-10-29 00:00:00','Eagle ','Cements',300),
('2017-11-09 00:00:00','Davies','Paints',100);
/*!40000 ALTER TABLE `defect` ENABLE KEYS */;

-- 
-- Definition of invoicenum
-- 

DROP TABLE IF EXISTS `invoicenum`;
CREATE TABLE IF NOT EXISTS `invoicenum` (
  `InvoiceNo` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`InvoiceNo`)
) ENGINE=InnoDB AUTO_INCREMENT=120 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table invoicenum
-- 

/*!40000 ALTER TABLE `invoicenum` DISABLE KEYS */;
INSERT INTO `invoicenum`(`InvoiceNo`) VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10),
(11),
(12),
(13),
(14),
(15),
(16),
(17),
(18),
(19),
(20),
(21),
(22),
(23),
(24),
(25),
(26),
(27),
(28),
(29),
(30),
(31),
(32),
(33),
(34),
(35),
(36),
(37),
(38),
(39),
(40),
(41),
(42),
(43),
(44),
(45),
(46),
(47),
(48),
(49),
(50),
(51),
(52),
(53),
(54),
(55),
(56),
(57),
(58),
(59),
(60),
(61),
(62),
(63),
(64),
(65),
(66),
(67),
(68),
(69),
(70),
(71),
(72),
(73),
(74),
(75),
(76),
(77),
(78),
(79),
(80),
(81),
(82),
(83),
(84),
(85),
(86),
(87),
(88),
(89),
(90),
(91),
(92),
(93),
(94),
(95),
(96),
(97),
(98),
(99),
(100),
(101),
(102),
(103),
(104),
(105),
(106),
(107),
(108),
(109),
(110),
(111),
(112),
(113),
(114),
(115),
(116),
(117),
(118),
(119);
/*!40000 ALTER TABLE `invoicenum` ENABLE KEYS */;

-- 
-- Definition of login
-- 

DROP TABLE IF EXISTS `login`;
CREATE TABLE IF NOT EXISTS `login` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Lastname` varchar(50) NOT NULL,
  `Firstname` varchar(50) NOT NULL,
  `MI` varchar(50) NOT NULL,
  `Province` varchar(50) NOT NULL,
  `City` varchar(50) NOT NULL,
  `Barangay` varchar(50) NOT NULL,
  `ContactNo` varchar(50) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Userlevel` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Question` varchar(100) NOT NULL,
  `Answer` varchar(100) NOT NULL,
  `Status` varchar(50) NOT NULL,
  PRIMARY KEY (`ID`,`Username`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table login
-- 

/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login`(`ID`,`Lastname`,`Firstname`,`MI`,`Province`,`City`,`Barangay`,`ContactNo`,`Username`,`Userlevel`,`Password`,`Question`,`Answer`,`Status`) VALUES
(1,'Palad','Bryan','G','Laguna','Cabuyao','G','09363151340','admin','administrator','adminpass','What is your favorite color?','Black','Active'),
(2,'cashier','cashier','cc','Laguna','Cabuyao','Brgy.Uno1','09308892279','cashier','cashier','cashier123','What is your favorite color?','black','Inactive'),
(3,'bbb','bbb','as','Batangas','San Jose','asdasd','09363151340','bry','administrator','bry12345678','What is your favorite color?','black','Active'),
(4,'bry','asd','g','Laguna','Nagcarlan','asd','09363151340','asd','administrator','asdasdasd','What is your favorite fruit?','asd','Active'),
(5,'asda','asda','as','Laguna','Bay','asd','09363151340','asdas','cashier','12345678123','What is your favorite color?','black','Active'),
(6,'jghghj','ghjghj','g','Laguna','Bay','ghjghjghj','09363151340','asdasdasd','cashier','123123123123','What is your favorite color?','blue','Active'),
(7,'asdasd','asdasd','as','Batangas','Balayan','asdasdasd','1','bryan','administrator','asdasdasd','What is your favorite fruit?','asdasd','Active'),
(8,'asdasdasd','asdasdasd','as','Batangas','Balayan','asdasdasd','09363151340','bryan123','administrator','bryan123','What is your favorite food?','asdasdasd','Active'),
(9,'aaa','aaa','aa','Laguna','Alaminos','aaaa','09336151343','aaa','administrator','aaaaaaaa','What is your favorite food?','tae','Active');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;

-- 
-- Definition of modify
-- 

DROP TABLE IF EXISTS `modify`;
CREATE TABLE IF NOT EXISTS `modify` (
  `ProductNo` int(11) NOT NULL,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Units` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table modify
-- 

/*!40000 ALTER TABLE `modify` DISABLE KEYS */;
INSERT INTO `modify`(`ProductNo`,`Productname`,`Category`,`Units`,`Quantity`) VALUES
(648017,'asd','Bulbs','Kilo',50);
/*!40000 ALTER TABLE `modify` ENABLE KEYS */;

-- 
-- Definition of ordereports
-- 

DROP TABLE IF EXISTS `ordereports`;
CREATE TABLE IF NOT EXISTS `ordereports` (
  `Date` date NOT NULL,
  `suppliercompany` varchar(50) NOT NULL,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `QuantityReceived` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table ordereports
-- 

/*!40000 ALTER TABLE `ordereports` DISABLE KEYS */;
INSERT INTO `ordereports`(`Date`,`suppliercompany`,`Productname`,`Category`,`QuantityReceived`) VALUES
('2017-10-14 00:00:00','asda','Rain or Shine','Paints',20),
('2017-10-14 00:00:00','Bulb Company','Firefly','Bulbs',100),
('2017-10-14 00:00:00','Paint Company','Boysen','Paints',50),
('2017-10-14 00:00:00','Bulb Company','Firefly','Bulbs',50),
('2017-10-14 00:00:00','Bulb Company','Firefly','Bulbs',50),
('2017-10-14 00:00:00','Paint Company','Boysen','Paints',50),
('2017-10-14 00:00:00','asda','Rain or Shine','Paints',100),
('2017-10-14 00:00:00','Bulb Company','Firefly','Bulbs',50),
('2017-10-14 00:00:00','asda','Rain or Shine','Paints',50),
('2017-10-14 00:00:00','Bulb Company','Firefly','Bulbs',50),
('2017-10-14 00:00:00','asda','Rain or Shine','Paints',50),
('2017-10-14 00:00:00','asda','Rain or Shine','Paints',100),
('2017-10-14 00:00:00','Bulb Company','Firefly','Bulbs',100),
('2017-10-14 00:00:00','Paint Company','Boysen','Paints',300),
('2017-10-14 00:00:00','Paint Company','Boysen','Paints',300),
('2017-10-14 00:00:00','Paint Company','Boysen','Paints',300),
('2017-10-15 00:00:00','Paint Company','Boysen','Paints',300),
('2017-10-15 00:00:00','Bulb Company','Firefly','Bulbs',100),
('2017-10-15 00:00:00','asda','Rain or Shine','Paints',100),
('2017-10-17 00:00:00','Paint Company','Boysen','Paints',300),
('2017-10-17 00:00:00','Bulb Company','Firefly','Bulbs',100),
('2017-10-17 00:00:00','asda','Rain or Shine','Paints',100),
('2017-10-17 00:00:00','Steel Company','Bakal','Steels',200),
('2017-10-17 00:00:00','Woods Company','Palochina','Woods',500),
('2017-10-17 00:00:00','Cement Company','Rizal Cement','Cements',300),
('2017-10-17 00:00:00','Davies Company','Davies','Paints',300),
('2017-10-17 00:00:00','Davies Company','Davies','Paints',200),
('2017-10-19 00:00:00','Bulb Company','Firefly','Bulbs',100),
('2017-10-19 00:00:00','Steel Company','Bakal','Steels',200),
('2017-10-19 00:00:00','Bulb Company','Firefly','Bulbs',50),
('2017-10-19 00:00:00','Davies Company','Davies','Paints',500),
('2017-10-19 00:00:00','Bulb Company','Firefly','Bulbs',50),
('2017-10-20 00:00:00','Steel Company','Bakal','Steels',100),
('2017-10-20 00:00:00','Steel Company','Bakal','Steels',50),
('2017-10-20 00:00:00','Davies Company','Davies','Paints',300),
('2017-10-20 00:00:00','Boysen Company','Boysen','Paints',200),
('2017-10-21 00:00:00','Davies Company','Davies','Paints',300),
('2017-10-21 00:00:00','adasd','Concrete 2','Nails',95),
('2017-10-29 00:00:00','Bulb Company','Firefly','Bulbs',50),
('2017-10-31 00:00:00','Bulb Company','Firefly','Bulbs',200),
('2017-10-31 00:00:00','Cement Company','Rizal ','Cements',300),
('2017-10-31 00:00:00','5','Palochina','Woods',200),
('2017-10-31 00:00:00','6','Firefly','Bulbs',50),
('2017-10-31 00:00:00','2','Boysen','Paints',100),
('2017-11-02 00:00:00','1','Rizal ','Cements',100),
('2017-11-02 00:00:00','Bulb Company','Firefly','Bulbs',200),
('2017-11-02 00:00:00','Nail Company','Pako','Nails',50),
('2017-11-02 00:00:00','1','Pako','Nails',100),
('2017-11-03 00:00:00','Cement Company','Semento','Cements',50),
('2017-11-03 00:00:00','Nail Company','Lagare','Saw',100),
('2017-11-03 00:00:00','Cement Company','Semento','Cements',200),
('2017-11-03 00:00:00','Cement Company','Semento','Cements',200),
('2017-11-03 00:00:00','Nail Company','Lagare','Saw',100),
('2017-11-03 00:00:00','Cement Company','Pako','Nails',100),
('2017-11-03 00:00:00','Cement Company','Semento','Cements',100),
('2017-11-04 00:00:00','Cement Company','Pako','Nails',100),
('2017-11-04 00:00:00','Cement Company','Semento','Cements',100),
('2017-11-04 00:00:00','Cement Company','Concrete','Nails',100),
('2017-11-04 00:00:00','Cement Company','Pako','Cements',50),
('2017-11-04 00:00:00','Cement Company','Pako','Cements',50),
('2017-11-04 00:00:00','Cement Company','Semento','Cements',90),
('2017-11-04 00:00:00','Cement Company','Semento','Cements',10),
('2017-11-04 00:00:00','Clyde Company','Rhea','Bulbs',95),
('2017-11-04 00:00:00','Wood Company','asd','Cements',100),
('2017-11-04 00:00:00','Cement Company','Bubong','Cements',100),
('2017-11-04 00:00:00','Cement Company','Pako','Bulbs',100),
('2017-11-04 00:00:00','Cement Company','Bubong','Doorknobs',100),
('2017-11-04 00:00:00','Cement Company','Bubong','Doorknobs',100),
('2017-11-04 00:00:00','Cement Company','Pako','Bulbs',100),
('2017-11-04 00:00:00','Cement Company','Pako','Bulbs',50),
('2017-11-04 00:00:00','Cement Company','Bubong','Bulbs',90),
('2017-11-04 00:00:00','Cement Company','Pako','Cements',50),
('2017-11-04 00:00:00','Cement Company','Pako','Bulbs',50),
('2017-11-04 00:00:00','Cement Company','Bubong','Bulbs',10),
('2017-11-06 00:00:00','Cement Company','Pako','Bulbs',100),
('2017-11-06 00:00:00','Cement Company','Bubong','Bulbs',100),
('2017-11-06 00:00:00','Cement Company','Concrete 1','Nails',100),
('2017-11-06 00:00:00','Cement Company','asd','Bulbs',50);
/*!40000 ALTER TABLE `ordereports` ENABLE KEYS */;

-- 
-- Definition of orders
-- 

DROP TABLE IF EXISTS `orders`;
CREATE TABLE IF NOT EXISTS `orders` (
  `Supplier_id` int(11) NOT NULL,
  `suppliercompany` varchar(50) NOT NULL,
  `Productno` int(11) NOT NULL,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Units` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `ponumber` int(11) NOT NULL,
  `contact` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table orders
-- 

/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders`(`Supplier_id`,`suppliercompany`,`Productno`,`Productname`,`Category`,`Units`,`Quantity`,`ponumber`,`contact`) VALUES
(1,'Cement Company',648017,'asd','Bulbs','Kilo',50,123456,'09123123123');
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;

-- 
-- Definition of percentage
-- 

DROP TABLE IF EXISTS `percentage`;
CREATE TABLE IF NOT EXISTS `percentage` (
  `FSI1` int(11) NOT NULL,
  `FSI2` int(11) NOT NULL,
  `SSI1` int(11) NOT NULL,
  `SSI2` int(11) NOT NULL,
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table percentage
-- 

/*!40000 ALTER TABLE `percentage` DISABLE KEYS */;
INSERT INTO `percentage`(`FSI1`,`FSI2`,`SSI1`,`SSI2`,`ID`) VALUES
(60,30,40,20,1);
/*!40000 ALTER TABLE `percentage` ENABLE KEYS */;

-- 
-- Definition of po
-- 

DROP TABLE IF EXISTS `po`;
CREATE TABLE IF NOT EXISTS `po` (
  `PoNo` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`PoNo`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table po
-- 

/*!40000 ALTER TABLE `po` DISABLE KEYS */;
INSERT INTO `po`(`PoNo`) VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10),
(11),
(12),
(13),
(14),
(15),
(16),
(17),
(18),
(19),
(20);
/*!40000 ALTER TABLE `po` ENABLE KEYS */;

-- 
-- Definition of pos
-- 

DROP TABLE IF EXISTS `pos`;
CREATE TABLE IF NOT EXISTS `pos` (
  `ProductNo` int(11) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `SellingPrice` double NOT NULL,
  `Quantity` double DEFAULT NULL,
  `TotalPrice` double NOT NULL,
  PRIMARY KEY (`ProductNo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table pos
-- 

/*!40000 ALTER TABLE `pos` DISABLE KEYS */;

/*!40000 ALTER TABLE `pos` ENABLE KEYS */;

-- 
-- Definition of product
-- 

DROP TABLE IF EXISTS `product`;
CREATE TABLE IF NOT EXISTS `product` (
  `ProductNo` int(11) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `SellingPrice` double NOT NULL,
  `Quantity` double NOT NULL,
  `CriticalLevel1` double NOT NULL,
  `CriticalLevel2` double NOT NULL,
  `Units` varchar(50) NOT NULL,
  `Ceiling` int(11) NOT NULL,
  PRIMARY KEY (`ProductNo`,`ProductName`)
) ENGINE=InnoDB AUTO_INCREMENT=997233 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table product
-- 

/*!40000 ALTER TABLE `product` DISABLE KEYS */;
INSERT INTO `product`(`ProductNo`,`ProductName`,`Category`,`SellingPrice`,`Quantity`,`CriticalLevel1`,`CriticalLevel2`,`Units`,`Ceiling`) VALUES
(878914,'Palochina','Woods',100.8,196,120,48,'Piece',500),
(897378,'Concrete','Nails',33.6,134,70,28,'Kilo',500),
(914292,'Davies','Paints',168,97,250,100,'Gallon',500),
(949229,'Rizal ','Cements',126,297,150,60,'Sack',1000),
(961414,'Boysen','Paints',134.4,70,75,30,'Gallon',500),
(969192,'Concrete 1','Nails',33.6,100,50,20,'Kilo',1000),
(975540,'Firefly','Bulbs',84,195,100,40,'Piece',1000),
(997232,'Eagle ','Cements',113.68,197,250,100,'Sack',500);
/*!40000 ALTER TABLE `product` ENABLE KEYS */;

-- 
-- Definition of reports
-- 

DROP TABLE IF EXISTS `reports`;
CREATE TABLE IF NOT EXISTS `reports` (
  `Date` date NOT NULL,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `TotalPrice` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table reports
-- 

/*!40000 ALTER TABLE `reports` DISABLE KEYS */;
INSERT INTO `reports`(`Date`,`Productname`,`Category`,`Quantity`,`TotalPrice`) VALUES
('2017-10-08 00:00:00','Palochina','Woods',5,483),
('2017-10-08 00:00:00','Palochina','Woods',5,458.85),
('2017-10-08 00:00:00','Firefly','Bulbs',1,96.6),
('2017-10-08 00:00:00','Firefly','Bulbs',1,96.6),
('2017-10-08 00:00:00','Firefly','Bulbs',1,96.6),
('2017-10-09 00:00:00','Firefly','Bulbs',5,483),
('2017-10-10 00:00:00','Palochina','Woods',10,917.7),
('2017-10-10 00:00:00','Davies','Paints',5,869.4),
('2017-10-11 00:00:00','Boysen','Paints',4,762),
('2017-10-11 00:00:00','Palochina','Woods',2,183.54),
('2017-10-11 00:00:00','Firefly','Bulbs',80,6955.2),
('2017-10-11 00:00:00','Rizal Cement','Cements',2,293.66),
('2017-10-11 00:00:00','Rizal Cement','Cements',3,463.68),
('2017-10-11 00:00:00','Boysen','Paints',3,571.5),
('2017-10-11 00:00:00','Rain or Shine','Paints',3,498.96),
('2017-10-11 00:00:00','Davies','Paints',4,695.52),
('2017-10-12 00:00:00','Boysen','Paints',5,904.88),
('2017-10-13 00:00:00','Davies','Paints',3,579.6),
('2017-10-13 00:00:00','Davies','Paints',2,386.4),
('2017-10-13 00:00:00','Davies','Paints',2,386.4),
('2017-10-13 00:00:00','Bakal','Steels',5,630),
('2017-10-14 00:00:00','Rain or Shine','Paints',2,332.64),
('2017-10-19 00:00:00','Palochina','Woods',8,772.8),
('2017-10-19 00:00:00','Firefly','Bulbs',5,483),
('2017-10-19 00:00:00','Davies','Paints',4,695.52),
('2017-10-20 00:00:00','Davies','Paints',2,347.76),
('2017-10-20 00:00:00','Davies','Paints',2,386.4),
('2017-10-20 00:00:00','Palochina','Woods',3,289.8),
('2017-10-20 00:00:00','Bakal','Steels',5,630),
('2017-10-20 00:00:00','Boysen','Paints',2,381),
('2017-10-20 00:00:00','Davies','Paints',2,386.4),
('2017-10-20 00:00:00','Firefly','Bulbs',5,483),
('2017-10-20 00:00:00','Pako','Nails',10,336),
('2017-10-20 00:00:00','Palochina','Woods',2,193.2),
('2017-10-20 00:00:00','Rain or Shine','Paints',3,498.96),
('2017-10-20 00:00:00','Rizal Cement','Cements',3,480),
('2017-10-20 00:00:00','Davies','Paints',300,52164),
('2017-10-21 00:00:00','Firefly','Bulbs',190,18354),
('2017-10-21 00:00:00','Davies','Paints',40,7728),
('2017-10-21 00:00:00','Davies','Paints',1,141.12),
('2017-10-21 00:00:00','Davies','Paints',1,117.6),
('2017-10-21 00:00:00','Davies','Paints',1,117.6),
('2017-10-21 00:00:00','Davies','Paints',2,235.2),
('2017-10-21 00:00:00','Concrete 2','Nails',100,1288),
('2017-10-21 00:00:00','Concrete 2','Nails',57,734.16),
('2017-10-21 00:00:00','Concrete 2','Nails',30,347.76),
('2017-10-22 00:00:00','Concrete 2','Nails',8,103.04),
('2017-10-24 00:00:00','Boysen','Paints',3,571.5),
('2017-10-24 00:00:00','Boysen','Paints',5,952.5),
('2017-10-24 00:00:00','Pako','Nails',10,336),
('2017-10-24 00:00:00','Rizal Cement','Cements',2,320),
('2017-10-24 00:00:00','Palochina','Woods',5,483),
('2017-10-24 00:00:00','Davies','Paints',3,352.8),
('2017-10-24 00:00:00','Firefly','Bulbs',3,289.8),
('2017-10-24 00:00:00','Rain or Shine','Paints',5,831.6),
('2017-10-24 00:00:00','Davies','Paints',3,352.8),
('2017-10-25 00:00:00','Pako','Nails',5,168),
('2017-10-26 00:00:00','Eagle','Cements',10,1747.2),
('2017-10-26 00:00:00','Concrete','Nails',2,67.2),
('2017-10-27 00:00:00','Concrete','Nails',3,100.8),
('2017-10-27 00:00:00','Eagle','Cements',230,40185.6),
('2017-10-28 00:00:00','Concrete','Nails',1,33.6),
('2017-10-28 00:00:00','Eagle','Cements',3,524.16),
('2017-10-28 00:00:00','Boysen','Paints',2,336),
('2017-10-29 00:00:00','Boysen','Paints',100,13440),
('2017-10-29 00:00:00','Eagle ','Cements',20,2273.6),
('2017-10-29 00:00:00','Boysen','Paints',40,5376),
('2017-10-29 00:00:00','Eagle ','Cements',120,13641.6),
('2017-10-29 00:00:00','Davies','Paints',140,23520),
('2010-01-09 00:00:00','Concrete','Nails',5,168),
('2010-01-09 00:00:00','Davies','Paints',3,504),
('2010-01-09 00:00:00','Eagle ','Cements',3,341.04),
('2017-11-02 00:00:00','Concrete','Nails',1,33.6),
('2017-11-03 00:00:00','Firefly','Bulbs',5,420),
('2017-11-03 00:00:00','Boysen','Paints',5,672),
('2017-11-03 00:00:00','Palochina','Woods',40,4032),
('2017-11-04 00:00:00','Rizal ','Cements',3,378),
('2017-11-04 00:00:00','Palochina','Woods',4,403.2);
/*!40000 ALTER TABLE `reports` ENABLE KEYS */;

-- 
-- Definition of sale
-- 

DROP TABLE IF EXISTS `sale`;
CREATE TABLE IF NOT EXISTS `sale` (
  `ProductNo` int(11) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `SellingPrice` double NOT NULL,
  `Quantity` int(11) NOT NULL,
  `TotalPrice` double NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`ProductNo`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table sale
-- 

/*!40000 ALTER TABLE `sale` DISABLE KEYS */;
INSERT INTO `sale`(`ProductNo`,`ProductName`,`Category`,`SellingPrice`,`Quantity`,`TotalPrice`,`Date`) VALUES
(1,'Boysen','Paints',134.4,40,5376,'2017-10-29 00:00:00'),
(2,'Eagle ','Cements',113.68,120,13641.6,'2017-10-29 00:00:00'),
(3,'Davies','Paints',168,140,23520,'2017-10-29 00:00:00'),
(4,'Concrete','Nails',33.6,5,168,'2010-01-09 00:00:00'),
(5,'Davies','Paints',168,3,504,'2010-01-09 00:00:00'),
(6,'Eagle ','Cements',113.68,3,341.04,'2010-01-09 00:00:00'),
(7,'Concrete','Nails',33.6,1,33.6,'2017-11-02 00:00:00'),
(8,'Firefly','Bulbs',84,5,420,'2017-11-03 00:00:00'),
(9,'Boysen','Paints',134.4,5,672,'2017-11-03 00:00:00'),
(10,'Palochina','Woods',100.8,40,4032,'2017-11-03 00:00:00'),
(11,'Rizal ','Cements',126,3,378,'2017-11-04 00:00:00'),
(12,'Palochina','Woods',100.8,4,403.2,'2017-11-04 00:00:00');
/*!40000 ALTER TABLE `sale` ENABLE KEYS */;

-- 
-- Definition of stock
-- 

DROP TABLE IF EXISTS `stock`;
CREATE TABLE IF NOT EXISTS `stock` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stock
-- 

/*!40000 ALTER TABLE `stock` DISABLE KEYS */;

/*!40000 ALTER TABLE `stock` ENABLE KEYS */;

-- 
-- Definition of stockin
-- 

DROP TABLE IF EXISTS `stockin`;
CREATE TABLE IF NOT EXISTS `stockin` (
  `stockin_id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(50) NOT NULL,
  `Quantity` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`stockin_id`)
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stockin
-- 

/*!40000 ALTER TABLE `stockin` DISABLE KEYS */;
INSERT INTO `stockin`(`stockin_id`,`ProductName`,`Quantity`,`Category`,`Date`) VALUES
(1,'Flourescent Light Bulb','50','Bulbs','2017-09-01 00:00:00'),
(2,'Boysen','50','Paints','2017-09-01 00:00:00'),
(3,'Flourescent Light Bulb','5','Bulbs','2017-09-11 00:00:00'),
(4,'Flourescent Light Bulb','10','Bulbs','2017-09-12 00:00:00'),
(5,'Yale','500','Doorknobs','2017-09-26 00:00:00'),
(6,'Firefly Bulb','95','Bulbs','2017-09-26 00:00:00'),
(7,'Flourescent Light Bulb','99','Bulbs','2017-09-26 00:00:00'),
(8,'Pako','60','Nails','2010-01-11 00:00:00'),
(9,'Boysen','501','Paints','2010-01-17 00:00:00'),
(10,'Boysen','205','Paints','2010-01-17 00:00:00'),
(11,'Boysen','206','Paints','2010-01-17 00:00:00'),
(12,'Boysen','205','Paints','2010-01-17 00:00:00'),
(13,'Palochina','100','Woods','2017-10-11 00:00:00'),
(14,'Rain or Shine','100','Paints','2017-10-14 00:00:00'),
(15,'Rain or Shine','100','Paints','2017-10-14 00:00:00'),
(16,'Boysen','30','Paints','2017-10-14 00:00:00'),
(17,'Boysen','30','Paints','2017-10-14 00:00:00'),
(18,'Boysen','30','Paints','2017-10-14 00:00:00'),
(19,'Firefly','50','Bulbs','2017-10-14 00:00:00'),
(20,'Boysen','20','Paints','2017-10-14 00:00:00'),
(21,'Boysen','200','Paints','2017-10-14 00:00:00'),
(22,'Boysen','100','Paints','2017-10-14 00:00:00'),
(23,'Boysen','200','Paints','2017-10-14 00:00:00'),
(24,'Boysen','200','Paints','2017-10-14 00:00:00'),
(25,'Boysen','100','Paints','2017-10-14 00:00:00'),
(26,'Boysen','300','Paints','2017-10-17 00:00:00'),
(27,'Boysen','100','Paints','2017-10-17 00:00:00'),
(28,'Firefly','100','Bulbs','2017-10-17 00:00:00'),
(29,'Firefly','100','Bulbs','2017-10-17 00:00:00'),
(30,'Rain or Shine','100','Paints','2017-10-17 00:00:00'),
(31,'Rain or Shine','100','Paints','2017-10-17 00:00:00'),
(32,'Palochina','400','Woods','2017-10-17 00:00:00'),
(33,'Palochina','70','Woods','2017-10-17 00:00:00'),
(34,'Davies','200','Paints','2017-10-17 00:00:00'),
(35,'Davies','177','Paints','2017-10-17 00:00:00'),
(36,'Firefly','35','Bulbs','2017-10-19 00:00:00'),
(37,'Davies','300','Paints','2017-10-21 00:00:00'),
(38,'Bakal','10','Steels','2017-10-21 00:00:00'),
(39,'Davies','90','Paints','2017-10-29 00:00:00');
/*!40000 ALTER TABLE `stockin` ENABLE KEYS */;

-- 
-- Definition of supplier
-- 

DROP TABLE IF EXISTS `supplier`;
CREATE TABLE IF NOT EXISTS `supplier` (
  `Supplier_id` int(11) NOT NULL AUTO_INCREMENT,
  `Lastname` varchar(50) NOT NULL,
  `Firstname` varchar(50) NOT NULL,
  `ContactNo` varchar(50) NOT NULL,
  `Address` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `suppliercompany` varchar(50) NOT NULL,
  `Status` varchar(50) NOT NULL,
  PRIMARY KEY (`Supplier_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table supplier
-- 

/*!40000 ALTER TABLE `supplier` DISABLE KEYS */;
INSERT INTO `supplier`(`Supplier_id`,`Lastname`,`Firstname`,`ContactNo`,`Address`,`city`,`suppliercompany`,`Status`) VALUES
(1,'Riveral','Aldrin','09123123123','Blk 420 Lot600','Calamba','Cement Company','Active'),
(2,'League','Allen','09363123123','Pulo ','Cabuyao','Paint Company','Active'),
(3,'Magpantay ','Rod','09612343564','Real','Calamba','Nail Company','Inactive'),
(4,'Recuenco','Rhea','09126387345','Bunggo ','Calamba','Bulb Company','Active'),
(5,'Palad','Bryan','09363151340','Brgy banlic','Cabuyao','Wood Company','Active'),
(6,'Gumba','Clyde','09363151340','Blk and White','Los Baños','Clyde Company','Active');
/*!40000 ALTER TABLE `supplier` ENABLE KEYS */;

-- 
-- Definition of supplierproduct
-- 

DROP TABLE IF EXISTS `supplierproduct`;
CREATE TABLE IF NOT EXISTS `supplierproduct` (
  `Supplier_id` int(11) NOT NULL,
  `suppliercompany` varchar(50) NOT NULL,
  `Productno` int(11) NOT NULL,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Units` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL,
  `contact` varchar(50) NOT NULL,
  `po` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table supplierproduct
-- 

/*!40000 ALTER TABLE `supplierproduct` DISABLE KEYS */;
INSERT INTO `supplierproduct`(`Supplier_id`,`suppliercompany`,`Productno`,`Productname`,`Category`,`Units`,`Quantity`,`contact`,`po`) VALUES
(1,'Cement Company',648017,'asd','Bulbs','Kilo',100,'09123123123',123456),
(1,'Cement Company',657352,'Pako','Nails','Kilo',100,'09123123123',123456),
(1,'Cement Company',973933,'Tae','Cements','Piece',100,'09123123123',123456);
/*!40000 ALTER TABLE `supplierproduct` ENABLE KEYS */;

-- 
-- Definition of tableorder
-- 

DROP TABLE IF EXISTS `tableorder`;
CREATE TABLE IF NOT EXISTS `tableorder` (
  `Productno` int(11) NOT NULL,
  `Productname` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `Units` varchar(50) NOT NULL,
  `Quantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table tableorder
-- 

/*!40000 ALTER TABLE `tableorder` DISABLE KEYS */;

/*!40000 ALTER TABLE `tableorder` ENABLE KEYS */;

-- 
-- Definition of trackerlog
-- 

DROP TABLE IF EXISTS `trackerlog`;
CREATE TABLE IF NOT EXISTS `trackerlog` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `Userlevel` varchar(50) NOT NULL,
  `Access` varchar(50) NOT NULL,
  `Time` varchar(50) NOT NULL,
  `Date` date NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table trackerlog
-- 

/*!40000 ALTER TABLE `trackerlog` DISABLE KEYS */;
INSERT INTO `trackerlog`(`ID`,`Username`,`Userlevel`,`Access`,`Time`,`Date`) VALUES
(1,'admin','Administrator','The Administrator ''admin'' has logged in','1:30:08 PM','2017-10-24 00:00:00'),
(2,'admin','Administrator','The Administrator ''admin'' has logged out','1:30:13 PM','2017-10-24 00:00:00'),
(3,'admin','Administrator','The Administrator ''admin'' has logged in','1:30:23 PM','2017-10-24 00:00:00'),
(4,'admin','Administrator','The Administrator ''admin'' has logged in','1:30:38 PM','2017-10-24 00:00:00'),
(5,'admin','Administrator','The Administrator ''admin'' has logged in','10:11:58 AM','2017-10-28 00:00:00'),
(6,'admin','Administrator','The Administrator ''admin'' has logged in','9:17:00 PM','2017-10-29 00:00:00'),
(7,'admin','Administrator','The Administrator ''admin'' has logged out','9:17:06 PM','2017-10-29 00:00:00'),
(8,'admin','Administrator','The Administrator ''admin'' has logged in','9:17:10 PM','2017-10-29 00:00:00'),
(9,'admin','Administrator','The Administrator ''admin'' has logged in','9:17:42 PM','2017-10-29 00:00:00'),
(10,'admin','Administrator','The Administrator ''admin'' has logged in','9:19:44 PM','2017-10-29 00:00:00'),
(11,'admin','Administrator','The Administrator ''admin'' has logged out','9:19:49 PM','2017-10-29 00:00:00');
/*!40000 ALTER TABLE `trackerlog` ENABLE KEYS */;

-- 
-- Definition of unavailable
-- 

DROP TABLE IF EXISTS `unavailable`;
CREATE TABLE IF NOT EXISTS `unavailable` (
  `ProductNo` int(11) NOT NULL,
  `ProductName` varchar(50) NOT NULL,
  `Category` varchar(50) NOT NULL,
  `SellingPrice` double NOT NULL,
  `Quantity` double NOT NULL,
  `CriticalLevel1` double NOT NULL,
  `CriticalLevel2` double NOT NULL,
  `Units` varchar(50) NOT NULL,
  `Ceiling` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table unavailable
-- 

/*!40000 ALTER TABLE `unavailable` DISABLE KEYS */;

/*!40000 ALTER TABLE `unavailable` ENABLE KEYS */;

-- 
-- Dumping views
-- 

DROP TABLE IF EXISTS `rep`;
DROP VIEW IF EXISTS `rep`;
CREATE ALGORITHM=UNDEFINED SQL SECURITY DEFINER VIEW `rep` AS select `a`.`Productno` AS `ProductNo`,`a`.`Productname` AS `ProductName`,`a`.`Category` AS `Category`,`a`.`Units` AS `Units`,`a`.`Quantity` AS `Quantity`,`b`.`suppliercompany` AS `SupplierCompany`,`b`.`po` AS `PO`,`b`.`contact` AS `Contact` from (`tableorder` `a` join `supplierproduct` `b` on((`a`.`Productno` = `b`.`Productno`)));



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2017-11-15 19:11:56
-- Total time: 0:0:0:2:477 (d:h:m:s:ms)

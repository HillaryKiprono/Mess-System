/*
Navicat MySQL Data Transfer

Source Server         : BIT
Source Server Version : 50136
Source Host           : localhost:3306
Source Database       : eims_db

Target Server Type    : MYSQL
Target Server Version : 50136
File Encoding         : 65001

Date: 2021-10-29 15:38:54
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `academic_year`
-- ----------------------------
DROP TABLE IF EXISTS `academic_year`;
CREATE TABLE `academic_year` (
  `Acad_Code` varchar(10) NOT NULL DEFAULT '',
  `Acad_Year` varchar(10) DEFAULT NULL,
  `Status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Acad_Code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of academic_year
-- ----------------------------

-- ----------------------------
-- Table structure for `centre`
-- ----------------------------
DROP TABLE IF EXISTS `centre`;
CREATE TABLE `centre` (
  `Centre_Code` varchar(10) NOT NULL DEFAULT '',
  `Centre_Name` varchar(60) DEFAULT NULL,
  `Location` varchar(60) DEFAULT NULL,
  `University_Code` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Centre_Code`),
  KEY `uniCode2` (`University_Code`),
  CONSTRAINT `uniCode2` FOREIGN KEY (`University_Code`) REFERENCES `university` (`University_Code`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of centre
-- ----------------------------

-- ----------------------------
-- Table structure for `course`
-- ----------------------------
DROP TABLE IF EXISTS `course`;
CREATE TABLE `course` (
  `Course_Code` varchar(10) NOT NULL DEFAULT '',
  `Course_Title` varchar(30) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Units` int(1) DEFAULT NULL,
  `Prog_Code` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Course_Code`),
  KEY `progCode4` (`Prog_Code`),
  CONSTRAINT `progCode4` FOREIGN KEY (`Prog_Code`) REFERENCES `program` (`Prog_Code`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of course
-- ----------------------------

-- ----------------------------
-- Table structure for `department`
-- ----------------------------
DROP TABLE IF EXISTS `department`;
CREATE TABLE `department` (
  `Dept_Code` varchar(10) NOT NULL DEFAULT '',
  `Dept_Name` varchar(100) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Faculty_Code` varchar(6) DEFAULT NULL,
  PRIMARY KEY (`Dept_Code`),
  KEY `facCode1` (`Faculty_Code`),
  CONSTRAINT `facCode1` FOREIGN KEY (`Faculty_Code`) REFERENCES `faculty` (`Faculty_Code`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of department
-- ----------------------------

-- ----------------------------
-- Table structure for `exam`
-- ----------------------------
DROP TABLE IF EXISTS `exam`;
CREATE TABLE `exam` (
  `Exam_Code` varchar(10) NOT NULL DEFAULT '',
  `Course_Code` varchar(10) DEFAULT NULL,
  `Reg_No` varchar(20) DEFAULT NULL,
  `Examiner_Code` varchar(15) DEFAULT NULL,
  `E_Examiner_Code` varchar(15) DEFAULT NULL,
  `Exam_Type` varchar(20) DEFAULT NULL,
  `Exam_Date` date DEFAULT NULL,
  PRIMARY KEY (`Exam_Code`),
  KEY `courseCode4` (`Course_Code`),
  KEY `RegNo1` (`Reg_No`),
  KEY `examiner1` (`Examiner_Code`),
  KEY `examiner2` (`E_Examiner_Code`),
  CONSTRAINT `courseCode4` FOREIGN KEY (`Course_Code`) REFERENCES `course` (`Course_Code`) ON UPDATE CASCADE,
  CONSTRAINT `examiner1` FOREIGN KEY (`Examiner_Code`) REFERENCES `examiner` (`Examiner_Code`) ON UPDATE CASCADE,
  CONSTRAINT `examiner2` FOREIGN KEY (`E_Examiner_Code`) REFERENCES `examiner` (`Examiner_Code`) ON UPDATE CASCADE,
  CONSTRAINT `RegNo1` FOREIGN KEY (`Reg_No`) REFERENCES `student` (`Reg_No`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of exam
-- ----------------------------

-- ----------------------------
-- Table structure for `examiner`
-- ----------------------------
DROP TABLE IF EXISTS `examiner`;
CREATE TABLE `examiner` (
  `Examiner_Code` varchar(15) NOT NULL DEFAULT '',
  `F_Name` varchar(60) DEFAULT NULL,
  `M_Name` varchar(60) DEFAULT NULL,
  `L_Name` varchar(60) DEFAULT NULL,
  `Phone_No` varchar(13) DEFAULT NULL,
  `Email_Address` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`Examiner_Code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of examiner
-- ----------------------------

-- ----------------------------
-- Table structure for `faculty`
-- ----------------------------
DROP TABLE IF EXISTS `faculty`;
CREATE TABLE `faculty` (
  `Faculty_Code` varchar(6) NOT NULL DEFAULT '',
  `Faculty_Name` varchar(65) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `University_Code` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Faculty_Code`),
  KEY `uniCode1` (`University_Code`),
  CONSTRAINT `uniCode1` FOREIGN KEY (`University_Code`) REFERENCES `university` (`University_Code`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of faculty
-- ----------------------------

-- ----------------------------
-- Table structure for `program`
-- ----------------------------
DROP TABLE IF EXISTS `program`;
CREATE TABLE `program` (
  `Prog_Code` varchar(10) NOT NULL DEFAULT '',
  `Prog_Name` varchar(65) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Duration` int(5) DEFAULT NULL,
  `Dept_Code` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Prog_Code`),
  KEY `deptCode1` (`Dept_Code`),
  CONSTRAINT `deptCode1` FOREIGN KEY (`Dept_Code`) REFERENCES `department` (`Dept_Code`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of program
-- ----------------------------

-- ----------------------------
-- Table structure for `student`
-- ----------------------------
DROP TABLE IF EXISTS `student`;
CREATE TABLE `student` (
  `Reg_No` varchar(15) NOT NULL DEFAULT '',
  `F_Name` varchar(60) DEFAULT NULL,
  `M_Name` varchar(60) DEFAULT NULL,
  `L_Name` varchar(60) DEFAULT NULL,
  `Status` tinyint(1) DEFAULT NULL,
  `Photo` varchar(255) DEFAULT NULL,
  `Phone_No` varchar(15) DEFAULT NULL,
  `Email_Address` varchar(60) DEFAULT NULL,
  `Postal_Address` varchar(255) DEFAULT NULL,
  `Prog_Code` varchar(10) DEFAULT NULL,
  `Acad_Code` varchar(10) DEFAULT NULL,
  `Year_Code` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`Reg_No`),
  KEY `progCode3` (`Prog_Code`),
  KEY `acadCode1` (`Acad_Code`),
  KEY `YearCode1` (`Year_Code`),
  CONSTRAINT `acadCode1` FOREIGN KEY (`Acad_Code`) REFERENCES `academic_year` (`Acad_Code`) ON UPDATE CASCADE,
  CONSTRAINT `progCode3` FOREIGN KEY (`Prog_Code`) REFERENCES `program` (`Prog_Code`) ON UPDATE CASCADE,
  CONSTRAINT `YearCode1` FOREIGN KEY (`Year_Code`) REFERENCES `year_of_study` (`Year_Code`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of student
-- ----------------------------

-- ----------------------------
-- Table structure for `student_exam`
-- ----------------------------
DROP TABLE IF EXISTS `student_exam`;
CREATE TABLE `student_exam` (
  `Stud_Exam_Code` varchar(50) NOT NULL DEFAULT '',
  `Reg_No` varchar(20) DEFAULT NULL,
  `Exam_Code` varchar(10) DEFAULT NULL,
  `I_CAT` double(4,2) DEFAULT NULL,
  `I_Semester` double(4,2) DEFAULT NULL,
  `E_CAT` double(4,2) DEFAULT NULL,
  `E_Semester` double(4,2) DEFAULT NULL,
  PRIMARY KEY (`Stud_Exam_Code`),
  KEY `regNo4` (`Reg_No`),
  KEY `examCoode` (`Exam_Code`),
  CONSTRAINT `examCoode` FOREIGN KEY (`Exam_Code`) REFERENCES `exam` (`Exam_Code`) ON UPDATE CASCADE,
  CONSTRAINT `regNo4` FOREIGN KEY (`Reg_No`) REFERENCES `student` (`Reg_No`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of student_exam
-- ----------------------------

-- ----------------------------
-- Table structure for `university`
-- ----------------------------
DROP TABLE IF EXISTS `university`;
CREATE TABLE `university` (
  `University_Code` varchar(10) NOT NULL DEFAULT '',
  `University_Name` varchar(65) DEFAULT NULL,
  `Location` varchar(20) DEFAULT NULL,
  `Postal_Code` int(6) DEFAULT NULL,
  `Zip_Code` varchar(6) DEFAULT NULL,
  `Town` varchar(100) DEFAULT NULL,
  `Logo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`University_Code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of university
-- ----------------------------
INSERT INTO `university` VALUES ('KIBU', 'Kibabii University', 'Bungoma', '1699', '50200', 'Bungoma', null);
INSERT INTO `university` VALUES ('MMUST', 'Masinde Muliro University of Science and Technology', 'Kakamega', '190', '50100', 'Kakamega', null);

-- ----------------------------
-- Table structure for `user`
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `User_Code` varchar(255) NOT NULL,
  `Username` varchar(50) DEFAULT NULL,
  `F_Name` varchar(50) DEFAULT NULL,
  `L_Name` varchar(50) DEFAULT NULL,
  `Postal_Address` varchar(255) DEFAULT NULL,
  `Phone_No` varchar(255) DEFAULT NULL,
  `Previledges` varchar(50) DEFAULT NULL,
  `Passsword` varchar(50) DEFAULT NULL,
  `Photo` varchar(255) DEFAULT 'Null',
  `Date_of_Reg` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `Status` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`User_Code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('KIBU/0001', 'James', 'James', 'Wafula', '1699-50200 Bungoma', '+254723123123', 'Admin', 'james', 'Null', '2021-01-25 16:35:28', '1');

-- ----------------------------
-- Table structure for `year_of_study`
-- ----------------------------
DROP TABLE IF EXISTS `year_of_study`;
CREATE TABLE `year_of_study` (
  `Year_Code` varchar(10) NOT NULL DEFAULT '',
  `Yos` int(1) DEFAULT NULL,
  `Semester` int(1) DEFAULT NULL,
  `Status` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`Year_Code`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of year_of_study
-- ----------------------------

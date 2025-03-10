USE [master]
GO

/*******************************************************************************
   Drop database if it exists
********************************************************************************/
IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'ClubManagement')
BEGIN
	ALTER DATABASE ClubManagement SET OFFLINE WITH ROLLBACK IMMEDIATE;
	ALTER DATABASE ClubManagement SET ONLINE;
	DROP DATABASE ClubManagement;
END

GO

CREATE DATABASE ClubManagement
GO

USE ClubManagement
GO


CREATE TABLE Clubs (
  clubId          int IDENTITY NOT NULL, 
  clubName        nvarchar(255) NULL, 
  description     nvarchar(255) NULL, 
  establishedDate date NULL, 
  PRIMARY KEY (clubId));

CREATE TABLE EventParticipants (
  eventParticipantId int IDENTITY NOT NULL, 
  status             nvarchar(255) NULL, 
  userId             int NOT NULL, 
  eventId            int NOT NULL, 
  PRIMARY KEY (eventParticipantId));

CREATE TABLE Events (
  eventId     int IDENTITY NOT NULL, 
  eventName   nvarchar(255) NULL, 
  status      nvarchar(255) NULL, 
  description nvarchar(255) NULL, 
  eventDate   date NULL, 
  location    nvarchar(255) NULL, 
  clubId      int NOT NULL, 
  [Column]    int NULL, 
  PRIMARY KEY (eventId));

CREATE TABLE Report (
  createdDate         date NULL, 
  reportId            int IDENTITY NOT NULL, 
  semester            date NULL, 
  memberChanges       date NULL, 
  eventSummary        nvarchar(255) NULL, 
  participationStatus nvarchar(255) NULL, 
  clubId              int NOT NULL, 
  PRIMARY KEY (reportId));

CREATE TABLE userClubs (
  userClubId int IDENTITY NOT NULL, 
  userId     int NOT NULL, 
  clubId     int NOT NULL, 
  status     nvarchar(255) NULL, 
  appliedAt  date NULL, 
  approvedAt date NULL, 
  PRIMARY KEY (userClubId));

CREATE TABLE Roles (
  roleId   INT IDENTITY PRIMARY KEY,
  roleName NVARCHAR(255) NOT NULL UNIQUE
);

CREATE TABLE Users (
  userId        int IDENTITY NOT NULL, 
  fullName      nvarchar(255) NULL, 
  email			VARCHAR(50)  NULL , 
  password      nvarchar(255) NULL, 
  roleId		INT NULL ,  
  studentNumber nvarchar(255) NULL, 
  username      NVARCHAR(50) NOT NULL , 
  FOREIGN KEY (roleId) REFERENCES Roles(roleId) ,
  PRIMARY KEY (userId));

ALTER TABLE userClubs ADD CONSTRAINT FKuserClubs595478 FOREIGN KEY (userId) REFERENCES Users (userId);
ALTER TABLE userClubs ADD CONSTRAINT FKuserClubs901847 FOREIGN KEY (clubId) REFERENCES Clubs (clubId);
ALTER TABLE Events ADD CONSTRAINT FKEvents4410 FOREIGN KEY (clubId) REFERENCES Clubs (clubId);
ALTER TABLE EventParticipants ADD CONSTRAINT FKEventParti840496 FOREIGN KEY (userId) REFERENCES Users (userId);
ALTER TABLE EventParticipants ADD CONSTRAINT FKEventParti303397 FOREIGN KEY (eventId) REFERENCES Events (eventId);
ALTER TABLE Report ADD CONSTRAINT FKReport196346 FOREIGN KEY (clubId) REFERENCES Clubs (clubId);

INSERT INTO Roles (roleName) VALUES 
('Admin'),
('Chairman'),
('ViceChairman'),
('TeamLeader'),
('Member');

-- Chèn dữ liệu vào bảng Users
SET IDENTITY_INSERT Users ON;

INSERT INTO Users (userId, fullName, email, password, roleId, studentNumber, username)
VALUES 
(1, 'Nguyễn Văn A', 'admin@example.com', 'admin123', 1, 'SV001', 'adminUser'),         -- Admin
(2, 'Trần Thị B', 'chairman@example.com', 'chairman123', 2, 'SV002', 'chairmanUser'),   -- Chairman
(3, 'Lê Văn C', 'vice@example.com', 'vice123', 3, 'SV003', 'viceUser'),                 -- ViceChairman
(4, 'Phạm Thị D', 'member1@example.com', 'member123', 5, 'SV004', 'memberUser1'),       -- Member
(5, 'Hoàng Văn E', 'member2@example.com', 'member123', 5, 'SV005', 'memberUser2'),      -- Member
(6, 'Ngô Thị F', 'member3@example.com', 'member123', 5, 'SV006', 'memberUser3'),        -- Member
(7, 'Bùi Văn G', 'member4@example.com', 'member123', 5, 'SV007', 'memberUser4'),        -- Member
(8, 'Đinh Thị H', 'member5@example.com', 'member123', 5, 'SV008', 'memberUser5'),       -- Member
(9, 'Phan Văn I', 'member6@example.com', 'member123', 5, 'SV009', 'memberUser6'),       -- Member
(10, 'Võ Thị K', 'member7@example.com', 'member123', 5, 'SV010', 'memberUser7');        -- Member

SET IDENTITY_INSERT Users OFF;


-- Chèn dữ liệu vào bảng Clubs
SET IDENTITY_INSERT Clubs ON;
INSERT INTO Clubs (clubId, clubName, description, establishedDate)
VALUES 
(1, 'Câu lạc bộ CNTT', 'CLB về công nghệ thông tin', '2020-01-15'),
(2, 'CLB Toán học', 'CLB dành cho những ai yêu thích toán', '2019-02-20'),
(3, 'CLB Tiếng Anh', 'Câu lạc bộ học tiếng Anh', '2018-05-10'),
(4, 'CLB Khoa học', 'Nơi trao đổi về khoa học', '2021-07-25'),
(5, 'CLB Bóng đá', 'CLB thể thao chuyên về bóng đá', '2017-09-30'),
(6, 'CLB Cầu lông', 'CLB dành cho những người yêu thích cầu lông', '2018-11-11'),
(7, 'CLB Văn học', 'CLB nghiên cứu văn học', '2020-03-22'),
(8, 'CLB Nghệ thuật', 'CLB về hội họa và âm nhạc', '2016-06-12'),
(9, 'CLB Kinh tế', 'CLB dành cho những ai yêu thích kinh tế', '2019-08-05'),
(10, 'CLB Du lịch', 'CLB tổ chức các hoạt động du lịch', '2015-12-01');
SET IDENTITY_INSERT Clubs OFF;

-- Chèn dữ liệu vào bảng Events
SET IDENTITY_INSERT Events ON;
INSERT INTO Events (eventId, eventName, status, description, eventDate, location, clubId)
VALUES 
(1, 'Hội thảo AI', 'Sắp diễn ra', 'Buổi hội thảo về AI', '2025-04-01', 'Phòng 101', 1),
(2, 'Toán học ứng dụng', 'Hoàn thành', 'Buổi thảo luận về toán ứng dụng', '2024-11-20', 'Phòng 202', 2),
(3, 'Cuộc thi hùng biện tiếng Anh', 'Sắp diễn ra', 'Cuộc thi hùng biện dành cho sinh viên', '2025-05-10', 'Hội trường A', 3),
(4, 'Thí nghiệm khoa học', 'Hoàn thành', 'Thực hiện các thí nghiệm vật lý', '2024-12-15', 'Phòng Lab', 4),
(5, 'Giải đấu bóng đá', 'Sắp diễn ra', 'Giải đấu bóng đá nội bộ', '2025-06-05', 'Sân vận động', 5),
(6, 'Giải cầu lông sinh viên', 'Hoàn thành', 'Giải đấu cầu lông toàn trường', '2024-10-10', 'Nhà thi đấu', 6),
(7, 'Hội thảo văn học', 'Sắp diễn ra', 'Hội thảo về văn học hiện đại', '2025-07-07', 'Phòng 303', 7),
(8, 'Triển lãm nghệ thuật', 'Hoàn thành', 'Triển lãm tranh và nhạc cụ', '2024-09-15', 'Phòng triển lãm', 8),
(9, 'Tọa đàm kinh tế', 'Sắp diễn ra', 'Tọa đàm về kinh tế thị trường', '2025-08-20', 'Phòng 404', 9),
(10, 'Tour du lịch hè', 'Hoàn thành', 'Chuyến đi du lịch mùa hè', '2024-07-30', 'Nha Trang', 10);
SET IDENTITY_INSERT Events OFF;

-- Chèn dữ liệu vào bảng EventParticipants
SET IDENTITY_INSERT EventParticipants ON;
INSERT INTO EventParticipants (eventParticipantId, status, userId, eventId)
VALUES 
(1, 'Đã tham gia', 4, 1),
(2, 'Chưa tham gia', 5, 2),
(3, 'Đã tham gia', 6, 3),
(4, 'Đã tham gia', 7, 4),
(5, 'Chưa tham gia', 8, 5),
(6, 'Đã tham gia', 9, 6),
(7, 'Đã tham gia', 10, 7),
(8, 'Chưa tham gia', 2, 8),
(9, 'Đã tham gia', 3, 9),
(10, 'Chưa tham gia', 1, 10);
SET IDENTITY_INSERT EventParticipants OFF;

SET IDENTITY_INSERT Report ON;

INSERT INTO Report (reportId, createdDate, semester, memberChanges, eventSummary, participationStatus, clubId)
VALUES 
(1, '2024-06-01', '2024-06-01', '2024-06-01', N'Tổng kết hội thảo AI', N'Tốt', 1),
(2, '2024-06-10', '2024-06-10', '2024-06-10', N'Báo cáo Toán học', N'Trung bình', 2),
(3, '2024-07-15', '2024-07-15', '2024-07-15', N'Cuộc thi tiếng Anh', N'Tốt', 3),
(4, '2024-08-05', '2024-08-05', '2024-08-05', N'Thí nghiệm khoa học', N'Khá', 4),
(5, '2024-09-10', '2024-09-10', '2024-09-10', N'Giải bóng đá', N'Tốt', 5),
(6, '2024-10-12', '2024-10-12', '2024-10-12', N'Giải cầu lông', N'Khá', 6),
(7, '2024-11-22', '2024-11-22', '2024-11-22', N'Hội thảo văn học', N'Trung bình', 7),
(8, '2024-12-01', '2024-12-01', '2024-12-01', N'Triển lãm nghệ thuật', N'Tốt', 8),
(9, '2025-01-15', '2025-01-15', '2025-01-15', N'Tọa đàm kinh tế', N'Khá', 9),
(10, '2025-02-20', '2025-02-20', '2025-02-20', N'Tour du lịch hè', N'Trung bình', 10);

SET IDENTITY_INSERT Report OFF;



-- Chèn dữ liệu vào bảng userClubs
SET IDENTITY_INSERT userClubs ON;
INSERT INTO userClubs (userClubId, userId, clubId, status, appliedAt, approvedAt)
VALUES 
(1, 1, 1, 'Đã duyệt', '2024-01-01', '2024-01-05'),
(2, 2, 2, 'Đã duyệt', '2024-02-10', '2024-02-15'),
(3, 3, 3, 'Chờ duyệt', '2024-03-20', NULL),
(4, 4, 4, 'Đã duyệt', '2024-04-05', '2024-04-10'),
(5, 5, 5, 'Từ chối', '2024-05-12', NULL),
(6, 6, 6, 'Đã duyệt', '2024-06-18', '2024-06-22'),
(7, 7, 7, 'Chờ duyệt', '2024-07-25', NULL),
(8, 8, 8, 'Đã duyệt', '2024-08-30', '2024-09-01'),
(9, 9, 9, 'Từ chối', '2024-10-02', NULL),
(10, 10, 10, 'Đã duyệt', '2024-11-11', '2024-11-15');
SET IDENTITY_INSERT userClubs OFF;







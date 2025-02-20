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

CREATE TABLE Users (
  userId        int IDENTITY NOT NULL, 
  fullName      nvarchar(255) NULL, 
  email         nvarchar(255) NULL, 
  password      nvarchar(255) NULL, 
  role          nvarchar(255) NULL, 
  studentNumber nvarchar(255) NULL, 
  PRIMARY KEY (userId));


ALTER TABLE userClubs ADD CONSTRAINT FKuserClubs595478 FOREIGN KEY (userId) REFERENCES Users (userId);
ALTER TABLE userClubs ADD CONSTRAINT FKuserClubs901847 FOREIGN KEY (clubId) REFERENCES Clubs (clubId);
ALTER TABLE Events ADD CONSTRAINT FKEvents4410 FOREIGN KEY (clubId) REFERENCES Clubs (clubId);
ALTER TABLE EventParticipants ADD CONSTRAINT FKEventParti840496 FOREIGN KEY (userId) REFERENCES Users (userId);
ALTER TABLE EventParticipants ADD CONSTRAINT FKEventParti303397 FOREIGN KEY (eventId) REFERENCES Events (eventId);
ALTER TABLE Report ADD CONSTRAINT FKReport196346 FOREIGN KEY (clubId) REFERENCES Clubs (clubId);


-- Chèn dữ liệu vào bảng Users
INSERT INTO Users (fullName, email, password, role, studentNumber) VALUES
(N'Nguyễn Văn A', 'a@example.com', 'pass123', 'admin', 'SV001'),
(N'Trần Thị B', 'b@example.com', 'pass123', 'chairMan', 'SV002'),
(N'Phạm Văn C', 'c@example.com', 'pass123', 'viceChairMan', 'SV003'),
(N'Lê Thị D', 'd@example.com', 'pass123', 'member', 'SV004'),
(N'Hoàng Văn E', 'e@example.com', 'pass123', 'member', 'SV005'),
(N'Đặng Thị F', 'f@example.com', 'pass123', 'member', 'SV006'),
(N'Bùi Văn G', 'g@example.com', 'pass123', 'member', 'SV007'),
(N'Ngô Thị H', 'h@example.com', 'pass123', 'member', 'SV008'),
(N'Huỳnh Văn I', 'i@example.com', 'pass123', 'member', 'SV009'),
(N'Võ Thị J', 'j@example.com', 'pass123', 'member', 'SV010');

-- Chèn dữ liệu vào bảng Clubs
INSERT INTO Clubs (clubName, description, establishedDate) VALUES
(N'Câu lạc bộ Bóng đá', N'CLB dành cho những ai yêu bóng đá', '2020-01-01'),
(N'Câu lạc bộ Âm nhạc', N'Nơi giao lưu của những người yêu nhạc', '2019-05-10'),
(N'Câu lạc bộ Văn học', N'Thảo luận và sáng tác văn học', '2021-03-15'),
(N'Câu lạc bộ Công nghệ', N'Nghiên cứu và phát triển công nghệ', '2018-09-20'),
(N'Câu lạc bộ Môi trường', N'Hành động vì môi trường xanh', '2022-07-07'),
(N'Câu lạc bộ Nhiếp ảnh', N'Dành cho người đam mê nhiếp ảnh', '2017-11-25'),
(N'Câu lạc bộ Kịch', N'Biểu diễn và sáng tác kịch nghệ', '2016-06-30'),
(N'Câu lạc bộ Võ thuật', N'Luyện tập võ thuật truyền thống', '2015-04-12'),
(N'Câu lạc bộ Lập trình', N'Học hỏi và phát triển kỹ năng lập trình', '2023-02-05'),
(N'Câu lạc bộ Cờ vua', N'Dành cho người yêu thích cờ vua', '2014-12-01');

-- Chèn dữ liệu vào bảng userClubs
INSERT INTO userClubs (userId, clubId, status, appliedAt, approvedAt) VALUES
(1, 1, 'approved', '2024-01-01', '2024-01-05'),
(2, 2, 'disapproved', '2024-01-02', '2024-01-06'),
(3, 3, 'approved', '2024-01-03', '2024-01-07'),
(4, 4, 'disapproved', '2024-01-04', '2024-01-08'),
(5, 5, 'approved', '2024-01-05', '2024-01-09'),
(6, 6, 'pending', '2024-01-06', '2024-01-10'),
(7, 7, 'disapproved', '2024-01-07', '2024-01-11'),
(8, 8, 'approved', '2024-01-08', '2024-01-12'),
(9, 9, 'approved', '2024-01-09', '2024-01-13'),
(10, 10, 'pending', '2024-01-10', '2024-01-14');

-- Chèn dữ liệu vào bảng Events
INSERT INTO Events (eventName, status, description, eventDate, location, clubId) VALUES
(N'Giải đấu bóng đá', 'Scheduled', N'Giải đấu giữa các câu lạc bộ', '2024-03-10', N'Sân vận động', 1),
(N'Buổi hòa nhạc', 'Scheduled', N'Biểu diễn âm nhạc', '2024-04-15', N'Hội trường lớn', 2),
(N'Hội sách văn học', 'Scheduled', N'Triển lãm sách', '2024-05-20', N'Thư viện trung tâm', 3),
(N'Cuộc thi lập trình', 'Scheduled', N'Thử thách lập trình viên', '2024-06-25', N'Phòng máy tính', 4),
(N'Triển lãm ảnh', 'Scheduled', N'Triển lãm ảnh nghệ thuật', '2024-07-30', N'Nhà triển lãm', 6),
(N'Vở kịch sân khấu', 'Scheduled', N'Biểu diễn kịch nghệ', '2024-08-05', N'Nhà hát lớn', 7),
(N'Giải đấu cờ vua', 'Scheduled', N'Cuộc thi đấu cờ vua', '2024-09-10', N'Hội trường A', 10),
(N'Hoạt động thiện nguyện', 'Scheduled', N'Giúp đỡ cộng đồng', '2024-10-15', N'Làng trẻ SOS', 5),
(N'Thi đấu võ thuật', 'Scheduled', N'Giải đấu võ thuật', '2024-11-20', N'Sân tập võ', 8),
(N'Hội thảo công nghệ', 'Scheduled', N'Trao đổi về công nghệ mới', '2024-12-25', N'Trường Đại học', 4);


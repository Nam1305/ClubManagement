-- Sử dụng master để tạo database
USE [master]
GO

-- Xóa database nếu đã tồn tại (tùy chọn)
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'ClubManagement')
    DROP DATABASE [ClubManagement]
GO

-- Tạo database ClubManagement
CREATE DATABASE [ClubManagement]
GO

-- Chuyển sang database ClubManagement
USE [ClubManagement]
GO

-- Tạo bảng Clubs (Câu lạc bộ)
CREATE TABLE [dbo].[Clubs] (
    [clubId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã câu lạc bộ
    [clubName] NVARCHAR(255) NOT NULL,              -- Tên câu lạc bộ
    [description] NVARCHAR(255) NULL,               -- Mô tả
    [establishedDate] DATE NULL,                    -- Ngày thành lập
    [status] NVARCHAR(50) NULL                      -- Trạng thái
)
GO

-- Tạo bảng Roles (Vai trò)
CREATE TABLE [dbo].[Roles] (
    [roleId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã vai trò
    [roleName] NVARCHAR(255) NOT NULL UNIQUE        -- Tên vai trò
)
GO

-- Tạo bảng Users (Người dùng)
CREATE TABLE [dbo].[Users] (
    [userId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã người dùng
    [fullName] NVARCHAR(255) NULL,                  -- Họ tên
    [email] VARCHAR(50) NULL,                       -- Email
    [password] NVARCHAR(255) NULL,                  -- Mật khẩu
    [roleId] INT NULL,                              -- Mã vai trò
    [studentNumber] NVARCHAR(255) NULL,             -- Mã sinh viên
    [username] NVARCHAR(50) NOT NULL,               -- Tên đăng nhập
    [status] NVARCHAR(50) NULL,                     -- Trạng thái
    FOREIGN KEY ([roleId]) REFERENCES [dbo].[Roles] ([roleId]) -- Khóa ngoại tới Roles
)
GO

-- Tạo bảng UserClubs (Quan hệ người dùng - câu lạc bộ)
CREATE TABLE [dbo].[UserClubs] (
    [userClubId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã quan hệ
    [userId] INT NOT NULL,                              -- Mã người dùng
    [clubId] INT NOT NULL,                              -- Mã câu lạc bộ
    [status] NVARCHAR(50) NULL,                         -- Trạng thái (approved, left, v.v.)
    [appliedAt] DATE NULL,                              -- Ngày đăng ký
    [approvedAt] DATE NULL,                             -- Ngày được duyệt
    FOREIGN KEY ([userId]) REFERENCES [dbo].[Users] ([userId]), -- Khóa ngoại tới Users
    FOREIGN KEY ([clubId]) REFERENCES [dbo].[Clubs] ([clubId])  -- Khóa ngoại tới Clubs
)
GO

-- Tạo bảng Events (Sự kiện)
CREATE TABLE [dbo].[Events] (
    [eventId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã sự kiện
    [eventName] NVARCHAR(255) NOT NULL,              -- Tên sự kiện
    [status] NVARCHAR(50) NULL,                      -- Trạng thái (Upcoming, Completed, v.v.)
    [description] NVARCHAR(255) NULL,                -- Mô tả
    [eventDate] DATE NULL,                           -- Ngày diễn ra
    [location] NVARCHAR(255) NULL,                   -- Địa điểm
    [clubId] INT NOT NULL,                           -- Mã câu lạc bộ
    FOREIGN KEY ([clubId]) REFERENCES [dbo].[Clubs] ([clubId]) -- Khóa ngoại tới Clubs
)
GO

-- Tạo bảng Groups (Nhóm)
CREATE TABLE [dbo].[Groups] (
    [groupId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã nhóm
    [groupName] NVARCHAR(255) NOT NULL,              -- Tên nhóm
    [clubId] INT NOT NULL,                           -- Mã câu lạc bộ
    [leaderId] INT NULL,                             -- Mã trưởng nhóm
    [createdAt] DATE NOT NULL,                       -- Ngày tạo
    [status] NVARCHAR(50) NOT NULL DEFAULT 'Active', -- Trạng thái (Active, Inactive, v.v.)
    [eventId] INT NULL,                              -- Mã sự kiện
    FOREIGN KEY ([clubId]) REFERENCES [dbo].[Clubs] ([clubId]),   -- Khóa ngoại tới Clubs
    FOREIGN KEY ([leaderId]) REFERENCES [dbo].[Users] ([userId]), -- Khóa ngoại tới Users
    FOREIGN KEY ([eventId]) REFERENCES [dbo].[Events] ([eventId]) -- Khóa ngoại tới Events
)
GO

-- Tạo bảng GroupMembers (Thành viên nhóm)
CREATE TABLE [dbo].[GroupMembers] (
    [groupMemberId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã thành viên nhóm
    [groupId] INT NOT NULL,                                -- Mã nhóm
    [userId] INT NOT NULL,                                 -- Mã người dùng
    [joinedAt] DATE NOT NULL,                              -- Ngày tham gia
    FOREIGN KEY ([groupId]) REFERENCES [dbo].[Groups] ([groupId]), -- Khóa ngoại tới Groups
    FOREIGN KEY ([userId]) REFERENCES [dbo].[Users] ([userId])     -- Khóa ngoại tới Users
)
GO

-- Tạo bảng ClubTask (Nhiệm vụ câu lạc bộ)
CREATE TABLE [dbo].[ClubTask] (
    [taskId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã nhiệm vụ
    [taskName] NVARCHAR(255) NOT NULL,              -- Tên nhiệm vụ
    [description] NVARCHAR(255) NULL,               -- Mô tả
    [assignedTo] INT NOT NULL,                      -- Người được giao
    [assignedBy] INT NOT NULL,                      -- Người giao
    [clubId] INT NOT NULL,                          -- Mã câu lạc bộ
    [groupId] INT NULL,                             -- Mã nhóm
    [status] NVARCHAR(50) NULL,                     -- Trạng thái (pending, completed, v.v.)
    [dueDate] DATE NULL,                            -- Hạn chót
    FOREIGN KEY ([assignedTo]) REFERENCES [dbo].[Users] ([userId]), -- Khóa ngoại tới Users
    FOREIGN KEY ([assignedBy]) REFERENCES [dbo].[Users] ([userId]), -- Khóa ngoại tới Users
    FOREIGN KEY ([clubId]) REFERENCES [dbo].[Clubs] ([clubId]),     -- Khóa ngoại tới Clubs
    FOREIGN KEY ([groupId]) REFERENCES [dbo].[Groups] ([groupId])   -- Khóa ngoại tới Groups
)
GO

-- Tạo bảng EventParticipants (Người tham gia sự kiện)
CREATE TABLE [dbo].[EventParticipants] (
    [eventParticipantId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã người tham gia
    [status] NVARCHAR(50) NULL,                                 -- Trạng thái (Đã đăng ký, Đã tham dự, v.v.)
    [userId] INT NOT NULL,                                      -- Mã người dùng
    [eventId] INT NOT NULL,                                     -- Mã sự kiện
    FOREIGN KEY ([userId]) REFERENCES [dbo].[Users] ([userId]),   -- Khóa ngoại tới Users
    FOREIGN KEY ([eventId]) REFERENCES [dbo].[Events] ([eventId]) -- Khóa ngoại tới Events
)
GO

-- Tạo bảng Report (Báo cáo)
CREATE TABLE [dbo].[Report] (
    [reportId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã báo cáo
    [createdDate] DATE NULL,                          -- Ngày tạo
    [semester] NVARCHAR(50) NULL,                     -- Học kỳ (Spring2025, Fall2025, v.v.)
    [memberChanges] NVARCHAR(255) NULL,               -- Thay đổi thành viên
    [eventSummary] NVARCHAR(255) NULL,                -- Tóm tắt sự kiện
    [participationStatus] NVARCHAR(50) NULL,          -- Trạng thái tham gia
    [clubId] INT NOT NULL,                            -- Mã câu lạc bộ
    FOREIGN KEY ([clubId]) REFERENCES [dbo].[Clubs] ([clubId]) -- Khóa ngoại tới Clubs
)
GO

-- Tạo bảng Messages (Tin nhắn)
CREATE TABLE [dbo].[Messages] (
    [messageId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, -- Mã tin nhắn
    [senderId] INT NOT NULL,                           -- Mã người gửi
    [receiverId] INT NULL,                             -- Mã người nhận (NULL nếu là tin nhắn chung trong câu lạc bộ)
    [clubId] INT NOT NULL,                             -- Mã câu lạc bộ
    [content] NVARCHAR(1000) NOT NULL,                 -- Nội dung tin nhắn
    [sentAt] DATETIME NOT NULL DEFAULT GETDATE(),      -- Thời gian gửi
    [isRead] BIT NOT NULL DEFAULT 0,                   -- Trạng thái đã đọc (0: chưa đọc, 1: đã đọc)
    FOREIGN KEY ([senderId]) REFERENCES [dbo].[Users] ([userId]),   -- Khóa ngoại tới Users (người gửi)
    FOREIGN KEY ([receiverId]) REFERENCES [dbo].[Users] ([userId]), -- Khóa ngoại tới Users (người nhận)
    FOREIGN KEY ([clubId]) REFERENCES [dbo].[Clubs] ([clubId])      -- Khóa ngoại tới Clubs
)
GO

-- Đặt database về chế độ đọc/ghi
USE [master]
GO
ALTER DATABASE [ClubManagement] SET READ_WRITE 
GO
USE [ClubManagement]
GO

-- Chèn dữ liệu vào bảng Roles
INSERT INTO [dbo].[Roles] ([roleName])
VALUES 
    ('Admin'),
    ('Chairman'),
    ('ViceChairman'),
    ('TeamLeader'),
    ('Member');
GO

-- Chèn dữ liệu vào bảng Users
SET IDENTITY_INSERT [dbo].[Users] ON;
INSERT INTO [dbo].[Users] ([userId], [fullName], [email], [password], [roleId], [studentNumber], [username], [status])
VALUES 
    (1, N'Nguyễn Văn A', 'admin@example.com', 'admin123', 1, 'SV001', 'adminUser', 'active'), 
    (2, N'Trần Thị B', 'chairman@example.com', 'chairman123', 2, 'SV002', 'chairmanUser', 'active'), 
    (3, N'Lê Văn C', 'vice@example.com', 'vice123', 3, 'SV003', 'viceUser', 'inactive'), 
    (4, N'Phạm Thị D', 'member1@example.com', 'member123', 5, 'SV004', 'memberUser1', 'active'), 
    (5, N'Hoàng Văn E', 'member2@example.com', 'member123', 5, 'SV005', 'memberUser2', 'inactive'), 
    (6, N'Ngô Thị F', 'member3@example.com', 'member123', 5, 'SV006', 'memberUser3', 'active'), 
    (7, N'Bùi Văn G', 'member4@example.com', 'member123', 5, 'SV007', 'memberUser4', 'inactive'), 
    (8, N'Đinh Thị H', 'member5@example.com', 'member123', 5, 'SV008', 'memberUser5', 'active'), 
    (9, N'Phan Văn I', 'member6@example.com', 'member123', 5, 'SV009', 'memberUser6', 'active'), 
    (10, N'Võ Thị K', 'member7@example.com', 'member123', 5, 'SV010', 'memberUser7', 'inactive'),
    (11, N'Nguyễn Văn H', 'emkobtchoiok@gmail.com', 'pass123', 3, 'SV011', 'coder1', 'active'),
    (12, N'Trần Thị I', 'anhdai317392@gmail.com', 'pass123', 4, 'SV012', 'coder2', 'active'),
    (13, N'Lê Văn K', 'emkobtchoiok2@gmail.com', 'pass123', 5, 'SV013', 'coder3', 'active'),
    (14, N'Phạm Thị L', 'coder4@example.com', 'pass123', 5, 'SV014', 'coder4', 'active'),
    (15, N'Hoàng Văn M', 'coder5@example.com', 'pass123', 5, 'SV015', 'coder5', 'active'),
    (16, N'Ngô Thị N', 'coder6@example.com', 'pass123', 5, 'SV016', 'coder6', 'active'),
    (17, N'Bùi Văn O', 'coder7@example.com', 'pass123', 5, 'SV017', 'coder7', 'active'),
    (18, N'Đinh Thị P', 'coder8@example.com', 'pass123', 5, 'SV018', 'coder8', 'active'),
    (19, N'Phan Văn Q', 'coder9@example.com', 'pass123', 5, 'SV019', 'coder9', 'active'),
    (20, N'Võ Thị R', 'coder10@example.com', 'pass123', 5, 'SV020', 'coder10', 'active'),
    (21, N'Nguyễn Văn S', 'coder11@example.com', 'pass123', 5, 'SV021', 'coder11', 'active'),
    (22, N'Trần Thị T', 'coder12@example.com', 'pass123', 5, 'SV022', 'coder12', 'active'),
    (23, N'Lê Văn U', 'coder13@example.com', 'pass123', 5, 'SV023', 'coder13', 'active'),
    (24, N'Phạm Thị V', 'coder14@example.com', 'pass123', 5, 'SV024', 'coder14', 'active'),
    (25, N'Hoàng Văn X', 'coder15@example.com', 'pass123', 5, 'SV025', 'coder15', 'active'),
    (26, N'Ngô Thị Y', 'coder16@example.com', 'pass123', 5, 'SV026', 'coder16', 'active'),
    (27, N'Bùi Văn Z', 'coder17@example.com', 'pass123', 5, 'SV027', 'coder17', 'active'),
    (28, N'Đinh Thị AA', 'coder18@example.com', 'pass123', 5, 'SV028', 'coder18', 'active'),
    (29, N'Phan Văn BB', 'coder19@example.com', 'pass123', 5, 'SV029', 'coder19', 'active'),
    (30, N'Võ Thị CC', 'coder20@example.com', 'pass123', 5, 'SV030', 'coder20', 'active') ,
	(31, N'Nguyễn Văn A', 'thangmoneo2542004@gmail.com', 'admin123', 1, 'SV001', 'adminUser', 'active') ;

SET IDENTITY_INSERT [dbo].[Users] OFF;

-- Chèn dữ liệu vào bảng Clubs
SET IDENTITY_INSERT [dbo].[Clubs] ON;
INSERT INTO [dbo].[Clubs] ([clubId], [clubName], [description], [status], [establishedDate])
VALUES 
    (1, N'Câu lạc bộ CNTT', N'CLB về công nghệ thông tin', 'inactive', '2020-01-15'),
    (2, N'CLB Toán học', N'CLB dành cho những ai yêu thích toán', 'active', '2019-02-20'),
    (3, N'CLB Tiếng Anh', N'Câu lạc bộ học tiếng Anh', 'active', '2018-05-10'),
    (4, N'CLB Khoa học', N'Nơi trao đổi về khoa học', 'active', '2021-07-25'),
    (5, N'CLB Bóng đá', N'CLB thể thao chuyên về bóng đá', 'active', '2017-09-30'),
    (6, N'CLB Cầu lông', N'CLB dành cho những người yêu thích cầu lông', 'active', '2018-11-11'),
    (7, N'CLB Văn học', N'CLB nghiên cứu văn học', 'active', '2020-03-22'),
    (8, N'CLB Nghệ thuật', N'CLB về hội họa và âm nhạc', 'inactive', '2016-06-12'),
    (9, N'CLB Kinh tế', N'CLB dành cho những ai yêu thích kinh tế', 'active', '2019-08-05'),
    (10, N'CLB Du lịch', N'CLB tổ chức các hoạt động du lịch', 'inactive', '2015-12-01'),
    (11, N'CLB Lập trình', N'Câu lạc bộ dành cho những người yêu thích lập trình', 'active', '2023-03-23');
SET IDENTITY_INSERT [dbo].[Clubs] OFF;

-- Chèn dữ liệu vào bảng UserClubs
SET IDENTITY_INSERT [dbo].[UserClubs] ON;
INSERT INTO [dbo].[UserClubs] ([userClubId], [userId], [clubId], [status], [appliedAt], [approvedAt])
VALUES 
    (1, 1, 1, N'approved', '2024-01-01', '2024-01-05'),
    (2, 2, 2, N'approved', '2024-02-10', '2024-02-15'),
    (3, 3, 3, N'approved', '2024-03-20', NULL),
    (4, 4, 4, N'approved', '2024-04-05', '2024-04-10'),
    (5, 5, 5, N'disapproved', '2024-05-12', NULL),
    (6, 6, 6, N'approved', '2024-06-18', '2024-06-22'),
    (7, 7, 7, N'pending', '2024-07-25', NULL),
    (8, 8, 8, N'pending', '2024-08-30', '2024-09-01'),
    (9, 9, 9, N'disapproved', '2024-10-02', NULL),
    (10, 10, 10, N'pending', '2024-11-11', '2024-11-15'),
    (11, 11, 11, N'approved', '2025-03-01', '2025-03-05'),
    (12, 12, 11, N'approved', '2025-03-01', '2025-03-05'),
    (13, 13, 11, N'approved', '2025-03-01', '2025-03-05'),
    (14, 14, 11, N'approved', '2025-03-01', '2025-03-05'),
    (15, 15, 11, N'approved', '2025-03-01', '2025-03-05'),
    (16, 16, 11, N'approved', '2025-03-02', '2025-03-06'),
    (17, 17, 11, N'approved', '2025-03-02', '2025-03-06'),
    (18, 18, 11, N'approved', '2025-03-02', '2025-03-06'),
    (19, 19, 11, N'approved', '2025-03-02', '2025-03-06'),
    (20, 20, 11, N'approved', '2025-03-02', '2025-03-06'),
    (21, 21, 11, N'approved', '2025-03-03', '2025-03-07'),
    (22, 22, 11, N'approved', '2025-03-03', '2025-03-07'),
    (23, 23, 11, N'approved', '2025-03-03', '2025-03-07'),
    (24, 24, 11, N'approved', '2025-03-03', '2025-03-07'),
    (25, 25, 11, N'approved', '2025-03-03', '2025-03-07'),
    (26, 26, 11, N'approved', '2025-03-04', '2025-03-08'),
    (27, 27, 11, N'approved', '2025-03-04', '2025-03-08'),
    (28, 28, 11, N'approved', '2025-03-04', '2025-03-08'),
    (29, 29, 11, N'approved', '2025-03-04', '2025-03-08'),
    (30, 30, 11, N'approved', '2025-03-04', '2025-03-08');
SET IDENTITY_INSERT [dbo].[UserClubs] OFF;

-- Chèn dữ liệu vào bảng Events
SET IDENTITY_INSERT [dbo].[Events] ON;
INSERT INTO [dbo].[Events] ([eventId], [eventName], [status], [description], [eventDate], [location], [clubId])
VALUES 
    (1, N'Hội thảo AI', N'Sắp diễn ra', N'Buổi hội thảo về AI', '2025-04-01', N'Phòng 101', 1),
    (2, N'Toán học ứng dụng', N'Hoàn thành', N'Buổi thảo luận về toán ứng dụng', '2024-11-20', N'Phòng 202', 2),
    (3, N'Cuộc thi hùng biện tiếng Anh', N'Sắp diễn ra', N'Cuộc thi hùng biện dành cho sinh viên', '2025-05-10', N'Hội trường A', 3),
    (4, N'Thí nghiệm khoa học', N'Hoàn thành', N'Thực hiện các thí nghiệm vật lý', '2024-12-15', N'Phòng Lab', 4),
    (5, N'Giải đấu bóng đá', N'Sắp diễn ra', N'Giải đấu bóng đá nội bộ', '2025-06-05', N'Sân vận động', 5),
    (6, N'Giải cầu lông sinh viên', N'Hoàn thành', N'Giải đấu cầu lông toàn trường', '2024-10-10', N'Nhà thi đấu', 6),
    (7, N'Hội thảo văn học', N'Sắp diễn ra', N'Hội thảo về văn học hiện đại', '2025-07-07', N'Phòng 303', 7),
    (8, N'Triển lãm nghệ thuật', N'Hoàn thành', N'Triển lãm tranh và nhạc cụ', '2024-09-15', N'Phòng triển lãm', 8),
    (9, N'Tọa đàm kinh tế', N'Sắp diễn ra', N'Tọa đàm về kinh tế thị trường', '2025-08-20', N'Phòng 404', 9),
    (10, N'Tour du lịch hè', N'Hoàn thành', N'Chuyến đi du lịch mùa hè', '2024-07-30', N'Nha Trang', 10),
    (11, N'Cuộc thi lập trình 2025', N'Sắp diễn ra', N'Cuộc thi lập trình dành cho thành viên CLB', '2025-04-15', N'Phòng máy tính 301', 11);
SET IDENTITY_INSERT [dbo].[Events] OFF;

-- Chèn dữ liệu vào bảng EventParticipants
SET IDENTITY_INSERT [dbo].[EventParticipants] ON;
INSERT INTO [dbo].[EventParticipants] ([eventParticipantId], [status], [userId], [eventId])
VALUES 
    (1, N'Đã tham gia', 4, 1),
    (2, N'Chưa tham gia', 5, 2),
    (3, N'Đã tham gia', 6, 3),
    (4, N'Đã tham gia', 7, 4),
    (5, N'Chưa tham gia', 8, 5),
    (6, N'Đã tham gia', 9, 6),
    (7, N'Đã tham gia', 10, 7),
    (8, N'Chưa tham gia', 2, 8),
    (9, N'Đã tham gia', 3, 9),
    (10, N'Chưa tham gia', 1, 10),
    (11, N'Đã tham gia', 11, 11),
    (12, N'Đã tham gia', 12, 11),
    (13, N'Đã tham gia', 13, 11),
    (14, N'Đã tham gia', 14, 11),
    (15, N'Đã tham gia', 15, 11),
    (16, N'Đã tham gia', 16, 11),
    (17, N'Đã tham gia', 17, 11),
    (18, N'Đã tham gia', 18, 11),
    (19, N'Đã tham gia', 19, 11),
    (20, N'Đã tham gia', 20, 11),
    (21, N'Đã tham gia', 21, 11),
    (22, N'Đã tham gia', 22, 11),
    (23, N'Đã tham gia', 23, 11),
    (24, N'Đã tham gia', 24, 11),
    (25, N'Đã tham gia', 25, 11);
SET IDENTITY_INSERT [dbo].[EventParticipants] OFF;

-- Chèn dữ liệu vào bảng Groups
SET IDENTITY_INSERT [dbo].[Groups] ON;
INSERT INTO [dbo].[Groups] ([groupId], [groupName], [clubId], [leaderId], [createdAt], [status], [eventId])
VALUES 
    (1, N'Nhóm Lập trình AI', 11, 11, '2025-03-10', N'Active', 11),
    (2, N'Nhóm Toán ứng dụng', 2, 2, '2024-06-01', N'Active', 2),
    (3, N'Nhóm Hùng biện', 3, 3, '2025-01-15', N'Active', 3),
    (4, N'Nhóm Thí nghiệm', 4, 4, '2024-07-01', N'Active', 4),
    (5, N'Nhóm Bóng đá A', 5, 5, '2025-02-01', N'Active', 5),
    (6, N'Nhóm Cầu lông 1', 6, 6, '2024-08-01', N'Active', 6),
    (7, N'Nhóm Văn học hiện đại', 7, 7, '2025-03-01', N'Active', 7),
    (8, N'Nhóm Nghệ thuật', 8, 8, '2024-05-01', N'Active', 8),
    (9, N'Nhóm Kinh tế thị trường', 9, 9, '2025-02-15', N'Active', 9),
    (10, N'Nhóm Du lịch hè', 10, 10, '2024-06-15', N'Active', 10);
SET IDENTITY_INSERT [dbo].[Groups] OFF;

-- Chèn dữ liệu vào bảng GroupMembers
SET IDENTITY_INSERT [dbo].[GroupMembers] ON;
INSERT INTO [dbo].[GroupMembers] ([groupMemberId], [groupId], [userId], [joinedAt])
VALUES 
    (1, 1, 11, '2025-03-10'), -- Nhóm Lập trình AI
    (2, 1, 12, '2025-03-10'),
    (3, 1, 13, '2025-03-10'),
    (4, 2, 2, '2024-06-01'),  -- Nhóm Toán ứng dụng
    (5, 2, 5, '2024-06-01'),
    (6, 3, 3, '2025-01-15'),  -- Nhóm Hùng biện
    (7, 3, 6, '2025-01-15'),
    (8, 4, 4, '2024-07-01'),  -- Nhóm Thí nghiệm
    (9, 4, 7, '2024-07-01'),
    (10, 5, 5, '2025-02-01'), -- Nhóm Bóng đá A
    (11, 5, 8, '2025-02-01'),
    (12, 6, 6, '2024-08-01'), -- Nhóm Cầu lông 1
    (13, 6, 9, '2024-08-01'),
    (14, 7, 7, '2025-03-01'), -- Nhóm Văn học hiện đại
    (15, 7, 10, '2025-03-01'),
    (16, 8, 8, '2024-05-01'), -- Nhóm Nghệ thuật
    (17, 9, 9, '2025-02-15'), -- Nhóm Kinh tế thị trường
    (18, 10, 10, '2024-06-15'); -- Nhóm Du lịch hè
SET IDENTITY_INSERT [dbo].[GroupMembers] OFF;

-- Chèn dữ liệu vào bảng ClubTask
SET IDENTITY_INSERT [dbo].[ClubTask] ON;
INSERT INTO [dbo].[ClubTask] ([taskId], [taskName], [description], [assignedTo], [assignedBy], [clubId], [groupId], [status], [dueDate])
VALUES 
    (1, N'Chuẩn bị tài liệu AI', N'Soạn tài liệu cho hội thảo AI', 11, 1, 11, 1, N'Pending', '2025-03-30'),
    (2, N'Tính toán bài toán', N'Giải các bài toán ứng dụng', 2, 2, 2, 2, N'Completed', '2024-11-15'),
    (3, N'Luyện tập hùng biện', N'Chuẩn bị bài hùng biện tiếng Anh', 3, 3, 3, 3, N'Pending', '2025-05-01'),
    (4, N'Chuẩn bị thí nghiệm', N'Sẵn sàng cho thí nghiệm vật lý', 4, 4, 4, 4, N'Completed', '2024-12-10'),
    (5, N'Lên lịch thi đấu', N'Sắp xếp lịch giải bóng đá', 5, 5, 5, 5, N'Pending', '2025-05-25'),
    (6, N'Thuê sân cầu lông', N'Đặt sân cho giải đấu', 6, 6, 6, 6, N'Completed', '2024-10-05'),
    (7, N'Nghiên cứu văn học', N'Phân tích tác phẩm hiện đại', 7, 7, 7, 7, N'Pending', '2025-06-30'),
    (8, N'Tổ chức triển lãm', N'Sắp xếp tranh và nhạc cụ', 8, 8, 8, 8, N'Completed', '2024-09-10'),
    (9, N'Chuẩn bị tọa đàm', N'Soạn nội dung kinh tế', 9, 9, 9, 9, N'Pending', '2025-08-15'),
    (10, N'Lên kế hoạch tour', N'Chuẩn bị chuyến đi Nha Trang', 10, 10, 10, 10, N'Completed', '2024-07-25'),
    (11, N'Tổ chức thi lập trình', N'Chuẩn bị đề thi lập trình', 12, 11, 11, 1, N'Pending', '2025-04-10');
SET IDENTITY_INSERT [dbo].[ClubTask] OFF;

-- Chèn dữ liệu vào bảng Report
SET IDENTITY_INSERT [dbo].[Report] ON;
INSERT INTO [dbo].[Report] ([reportId], [createdDate], [semester], [memberChanges], [eventSummary], [participationStatus], [clubId])
VALUES 
    (1, '2024-06-01', 'Spring2024', '2 members joined, 1 member left', N'Tổng kết hội thảo AI', N'Tốt', 1),
    (2, '2024-06-10', 'Spring2024', '3 members joined, 0 members left', N'Báo cáo Toán học', N'Trung bình', 2),
    (3, '2024-07-15', 'Summer2024', '1 member joined, 2 members left', N'Cuộc thi tiếng Anh', N'Tốt', 3),
    (4, '2024-08-05', 'Summer2024', '4 members joined, 1 member left', N'Thí nghiệm khoa học', N'Khá', 4),
    (5, '2024-09-10', 'Fall2024', '5 members joined, 0 members left', N'Giải bóng đá', N'Tốt', 5),
    (6, '2024-10-12', 'Fall2024', '2 members joined, 3 members left', N'Giải cầu lông', N'Khá', 6),
    (7, '2024-11-22', 'Fall2024', '3 members joined, 1 member left', N'Hội thảo văn học', N'Trung bình', 7),
    (8, '2024-12-01', 'Fall2024', '1 member joined, 0 members left', N'Triển lãm nghệ thuật', N'Tốt', 8),
    (9, '2025-01-15', 'Spring2025', '2 members joined, 2 members left', N'Tọa đàm kinh tế', N'Khá', 9),
    (10, '2025-02-20', 'Spring2025', '3 members joined, 1 member left', N'Tour du lịch hè', N'Trung bình', 10),
    (11, '2025-03-24', 'Spring2025', '20 members joined, 0 members left', N'Cuộc thi lập trình 2025', N'Tốt', 11);
SET IDENTITY_INSERT [dbo].[Report] OFF;
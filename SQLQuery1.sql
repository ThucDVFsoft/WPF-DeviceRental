--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(3, N'Phạm Hồng Ánh',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(4, N'Dương Thị Minh Châu',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(5, N'Hoàng Xuân Chiến',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(6, N'Lê Ngọc Danh',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(7, N'Nguyễn Đức Du',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(8, N'Lê Tuấn Duy',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(9, N'Phan Thị Hải Duyên',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(10,N'Lê Văn Dương',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(11,N'Nguyễn Văn Độ',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(12,N'Dương Minh Đức',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(13,N'Lê Xuân Đức',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(14,N'Nguyễn Anh Đức',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(15,N'Nguyễn Minh Đức',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(16,N'Lê Thị Giang',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(17,N'Nguyễn Văn Hải',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(18,N'Lê Ngọc Hùng Hiệp',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(19,N'Nguyễn Tiến Hiếu',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(20,N'Nguyễn Thị Thu Hoài',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(21,N'Nguyễn Thu Hoài',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(22,N'Đặng Tuấn Hoàng',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(23,N'Phạm Văn Hoàng',N'Ha Noi',GetDate(),GetDate(),'false')
--insert into dbo.Employee(EmployeeId,Name,Department,DateCreated,LastModified,Deleted) values(24,N'Trần Đức Học',N'Ha Noi',GetDate(),GetDate(),'false')
--select * from Employee
--set Identity_insert DeviceType ON
--insert into dbo.DeviceType(DeviceTypeId,Name,DateCreated,LastModified,Deleted) values(1,N'Computer',GetDate(),GetDate(),'false')
--insert into dbo.DeviceType(DeviceTypeId,Name,DateCreated,LastModified,Deleted) values(2,N'Laptop',GetDate(),GetDate(),'false')
--insert into dbo.DeviceType(DeviceTypeId,Name,DateCreated,LastModified,Deleted) values(3,N'Printer',GetDate(),GetDate(),'false')
--insert into dbo.DeviceType(DeviceTypeId,Name,DateCreated,LastModified,Deleted) values(4,N'projectors',GetDate(),GetDate(),'false')
--insert into dbo.DeviceType(DeviceTypeId,Name,DateCreated,LastModified,Deleted) values(5,N'TV',GetDate(),GetDate(),'false')
set identity_insert Device ON
insert into dbo.Device(DeviceId,Name,DeviceType,DeviceCode, DateCreated,LastModified,Deleted) values(1,N'Computer1',1,'PC1', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(2,N'Computer2',1,'PC_02', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(2,N'Computer2',1,'PC_02', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(3,N'Computer3',1,'PC_03', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(4,N'Computer4',1,'PC_04', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(5,N'Computer5',1,'PC_05', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(6,N'Computer6',1,'PC_06', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(7,N'Printer01',3,'PR_01', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(8,N'Printer02',3,'PR_02', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(9,N'Printer03',3,'PR_03', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(10,N'Printer04',3,'PR_04', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(10,N'Printer05',3,'PR_04', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(11,N'TV01',5,'TV_01', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(12,N'TV02',5,'TV_02', GetDate(),GetDate(),'false')
insert into dbo.Device(DeviceId,Name,Type,Code, DateCreated,LastModified,Deleted) values(13,N'TV03',5,'TV_03', GetDate(),GetDate(),'false')

update DeviceRental set RentalDate = GETDATE()
update DeviceRental set ExpiryDate = '2017-12-31'
update DeviceRental set RentalStatus = 0 where Sid = 3
update DeviceRental set RentalStatus = 0 where Sid = 4
update DeviceRental set RentalStatus = 0 where Sid = 5

update DeviceRental set RentalStatus = 2 where Sid = 6
update DeviceRental set RentalStatus = 2 where Sid = 8
update DeviceRental set RentalStatus = 2 where Sid = 9
select * from DeviceRental

UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\computer.png', Single_Blob) MyImage) where DeviceId = 1
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\computer.png', Single_Blob) MyImage) where DeviceId = 2
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\computer.png', Single_Blob) MyImage) where DeviceId = 3
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\computer.png', Single_Blob) MyImage) where DeviceId = 4
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\computer.png', Single_Blob) MyImage) where DeviceId = 5
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\computer.png', Single_Blob) MyImage) where DeviceId = 6
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\Printer.jpg', Single_Blob) MyImage) where DeviceId = 7
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\Printer.jpg', Single_Blob) MyImage) where DeviceId = 8
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\Printer.jpg', Single_Blob) MyImage) where DeviceId = 9
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\Printer.jpg', Single_Blob) MyImage) where DeviceId = 10

UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\TV.jpg', Single_Blob) MyImage) where DeviceId = 11
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\TV.jpg', Single_Blob) MyImage) where DeviceId = 12
UPDATE Device SET [Image] = (SELECT MyImage.* from Openrowset(Bulk 'D:\Project\XLL\C#\WPF\Baitap\WPF-DeviceRental\DeviceRental\Images\Devices\TV.jpg', Single_Blob) MyImage) where DeviceId = 13



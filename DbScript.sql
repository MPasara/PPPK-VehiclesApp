create database PPPK
go

use PPPK
go

create table Driver
(
	IDDriver int primary key identity,
	Firstname nvarchar(50) not null,
	Surname nvarchar(50) not null,
	PhoneNumber nvarchar(100) not null,
	DrivingLicenceNumber nvarchar(100) not null
)
go

create table Vehicle
(
	IDVehicle int primary key identity,
	VehicleType nvarchar(100) not null, --tip
	Make nvarchar(100) not null, --marka
	YearOfMake int not null,
	Kilometers int not null,
	IsAvailable bit not null,
	VehicleServiceDetails nvarchar(max) not null
)
go

create table TravelWarrant
(
	IDTravelWarrant int primary key identity,
	Commander nvarchar(100), --naredbodavac
	WarrantNumber int not null,
	StartPoint nvarchar(100) not null,
	Destination nvarchar(100) not null,
	QuantityOfDays int not null,
	DateOfOpening datetime not null,
	DateOfClosing datetime not null,
	DriverID int foreign key references Driver(IDDriver) not null,
	VehicleID int foreign key references Vehicle(IDVehicle) not null
)
go

create table TravelRoute
(
	IDRoute int primary key identity,
	TravelHours int not null,
	CoordinateA float not null,
	CoordinateB float not null,
	KilometersTavelled int not null,
	AverageSpeed float not null,
	FuelSpent float not null,
	TravelWarrantID int foreign key references TravelWarrant(IDTravelWarrant)
)
go

create table VehicleService
(
	IDservice int primary key identity,
	ServiceDetails nvarchar(max) not null,
	ServiceDate datetime not null,
	VehicleID int foreign key references Vehicle(IDVehicle)
)
go



--Driver procedures
create proc createDriver
	@IDDriver int output,
	@Firstname nvarchar(50),
	@Surname nvarchar(50),
	@PhoneNumber nvarchar(100),
	@DrivingLicenceNumber nvarchar(100)
as
begin
	insert into Driver values(@Firstname, @Surname, @PhoneNumber, @DrivingLicenceNumber)
	set @IDDriver = SCOPE_IDENTITY()
end
go

create proc selectDriver
	@IDDriver int
as
begin
	select * from Driver as d
	where d.IDDriver = @IDDriver
end
go

create proc selectDrivers
as
begin
	select * from Driver
end
go

create proc updateDriver
	@IDDriver int,
	@Firstname nvarchar(50),
	@Surname nvarchar(50),
	@PhoneNumber nvarchar(100),
	@DrivingLicenceNumber nvarchar(100)
as
begin
	update Driver set Firstname = @Firstname, Surname = @Surname, PhoneNumber = @PhoneNumber, DrivingLicenceNumber = @DrivingLicenceNumber
	where IDDriver = @IDDriver
end
go

create proc deleteDriver
	@IDDriver int
as
begin
	delete from Driver where IDDriver = @IDDriver
end
go

--Vehicle procedures
/*create proc createVehicleServiceDetails
	@IDVehicle int,
	@VehicleServiceDetails nvarchar(max)
as
begin
	insert into Vehicle values(@VehicleServiceDetails)
	set @IDVehicle = SCOPE_IDENTITY()
end*/
go

create proc createVehicle
	@IDVehicle int output,
	@VehicleType nvarchar(100),
	@Make nvarchar(100),
	@YearOfMake int,
	@Kilometers int,
	@IsAvailable bit,
	@VehicleServiceDetails nvarchar(max)
as
begin
	insert into Vehicle values (@VehicleType,@Make,@YearOfMake,@Kilometers,@IsAvailable,@VehicleServiceDetails)
	set @IDVehicle = SCOPE_IDENTITY()
end
go

create proc selectVehicle
	@IDVehicle int
as
begin
	select * from Vehicle
	where IDVehicle = @IDVehicle
end
go

create proc selectVehicles
as
begin
select * from Vehicle
end
go

create proc updateVehicle
	@IDVehicle int,
	@VehicleType nvarchar(100),
	@Make nvarchar(100),
	@YearOfMake int,
	@Kilometers int,
	@IsAvailable bit,
	@VehicleServiceDetails nvarchar(max)
as
begin
	update Vehicle set VehicleType = @VehicleType, Make = @Make, YearOfMake = @YearOfMake, Kilometers = @Kilometers, IsAvailable = @IsAvailable,VehicleServiceDetails=@VehicleServiceDetails
	where IDVehicle = @IDVehicle
end
go

create proc deleteVehicle
	@IDVehicle int
as
begin
	delete from Vehicle
	where IDVehicle = @IDVehicle
end
go

--TravelWarrant procedures
create proc createTravelWarrant
	@IDTravelWarrant int output,
	@Commander nvarchar(100),
	@WarrantNumber int,
	@StartPoint nvarchar(100),
	@Destination nvarchar(100),
	@QuantityOfDays int,
	@DateOfOpening datetime,
	@DateOfClosing datetime,
	@DriverID int,
	@VehicleID int
as
begin
	insert into TravelWarrant values (@Commander, @WarrantNumber, @StartPoint, @Destination, @QuantityOfDays, @DateOfOpening, @DateOfClosing, @DriverID, @VehicleID)
	set @IDTravelWarrant = SCOPE_IDENTITY()
end
go

create proc selectTravelWarrant
	@IDTravelWarrant int
as
begin
	select * from TravelWarrant
	where IDTravelWarrant = @IDTravelWarrant
end 
go

create proc selectTravelWarrants
as
begin
	select * from TravelWarrant
end 
go

create proc updateTravelWarrant
	@IDTravelWarrant int,
	@Commander nvarchar(100),
	@WarrantNumber int,
	@StartPoint nvarchar(100),
	@Destination nvarchar(100),
	@QuantityOfDays int,
	@DateOfOpening datetime,
	@DateOfClosing datetime,
	@DriverID int,
	@VehicleID int
as
begin
	update TravelWarrant set Commander = @Commander, WarrantNumber = @WarrantNumber, StartPoint = @StartPoint, Destination = @Destination, QuantityOfDays = @QuantityOfDays,
	DateOfOpening = @DateOfOpening, DateOfClosing = @DateOfClosing, DriverID = @DriverID, VehicleID = @VehicleID
	where IDTravelWarrant = @IDTravelWarrant
end
go

create proc deleteTravelWarrant
	@IDTravelWarrant int
as
begin
	delete from TravelWarrant
	where IDTravelWarrant = @IDTravelWarrant
end
go

--TravelRoute procedures
create proc createTravelRoute
	@IDRoute int output,
	@TravelHours int,
	@CoordinateA float,
	@CoordinateB float,
	@KilometersTavelled int,
	@AverageSpeed float,
	@FuelSpent float,
	@TravelWarrantID int
as
begin
	insert into TravelRoute values (@TravelHours, @CoordinateA, @CoordinateB, @KilometersTavelled, @AverageSpeed, @FuelSpent, @TravelWarrantID)
	set @IDRoute = SCOPE_IDENTITY()
end 
go

create proc selectTravelRoute
	@IDRoute int
as
begin 
	select * from TravelRoute
	where IDRoute = @IDRoute
end
go

create proc selectTravelRoutes
as
begin 
	select * from TravelRoute
end
go

create proc updateTravelRoute
	@IDRoute int,
	@TravelHours int,
	@CoordinateA float,
	@CoordinateB float,
	@KilometersTavelled int,
	@AverageSpeed float,
	@FuelSpent float,
	@TravelWarrantID int
as
begin
	update TravelRoute set TravelHours = @TravelHours, CoordinateA = @CoordinateA, CoordinateB = @CoordinateB, KilometersTavelled = @KilometersTavelled, AverageSpeed = @AverageSpeed,
						   FuelSpent = @FuelSpent, TravelWarrantID = @TravelWarrantID
	where IDRoute = @IDRoute
end
go

create proc deleteRoute
	@IDRoute int
as
begin
	delete from TravelRoute
	where IDRoute = @IDRoute
end
go

--VehicleService procedures
create proc createVehicleService
	@IDservice int output,
	@ServiceDetails nvarchar(max),
	@ServiceDate datetime,
	@VehicleID int
as
begin
	insert into VehicleService values (@ServiceDetails, @ServiceDate, @VehicleID)
	set @IDservice = SCOPE_IDENTITY()
end
go

create proc selectVehicleService
	@IDservice int
as
begin
	select * from VehicleService
	where IDservice = @IDservice
end
go

create proc selectVehicleServices
as
begin
	select * from VehicleService
end
go

create proc updateVehicleService
	@IDservice int,
	@ServiceDetails nvarchar(max),
	@ServiceDate datetime,
	@VehicleID int
as
begin
	update VehicleService set ServiceDetails = @ServiceDetails, ServiceDate = @ServiceDate, VehicleID = @VehicleID
	where IDservice = IDservice
end
go

create proc deleteVehicleService
	@IDservice int
as
begin
	delete from VehicleService
	where IDservice = @IDservice
end
go

--XML procedures
create proc exportDataToXml
	@IDRoute int
as
begin
	select * from TravelRoute
	where IDRoute = @IDRoute 
end
go


--DELETE ALL
create proc cleanDatabase
as
begin
	delete from Driver
	delete from Vehicle
	delete from TravelWarrant
	delete from TravelRoute
	delete from VehicleService
end
go

create proc getAllDataFromDatabase
as
begin
	select tw.IDTravelWarrant, tw.Commander, tw.WarrantNumber,tw.StartPoint,tw.Destination,tw.QuantityOfDays,tw.DateOfOpening,tw.DateOfClosing,
	 d.IDDriver,d.Firstname,d.Surname,d.PhoneNumber,d.DrivingLicenceNumber,
	 veh.IDVehicle,veh.VehicleType,veh.Make,veh.YearOfMake,veh.Kilometers,veh.IsAvailable 
	 from TravelWarrant as tw
	 inner join Driver as d
	 on d.IDDriver = tw.DriverID
	 inner join Vehicle as veh
	 on veh.IDVehicle = tw.VehicleID
	 order by tw.IDTravelWarrant
	 
end
go

--drop proc getAllDataFromDatabase

create proc writeDriversToXml
as
begin
	select * from Driver
end
go

create proc writeVehiclesToXml
as
begin
	select * from Vehicle
end
go

--add dummy stuffs
create proc addExampleRecords
as
begin
	insert into Driver values ('Mitar', 'Miric', '11111111', '11111111'),
							  ('Tommy', 'Shelby', '22222222','22222222')

	insert into Vehicle values ('Car','Suzuki','2015','95000',0,''),
							   ('Truck','Man','2018','180050',0,''),
							   ('Tractor','John Deere','1889','752349',0,'')

	insert into TravelWarrant values ('Ante Gotovina', '1', 'Zagreb', 'Split', 3, '10-05-2021', '13-05-2021',1,1),
									 ('Mladen Markac', '2', 'Zagreb', 'Dubrovnik', 5, '11-05-2021', '16-05-2021',1,1)

	insert into TravelRoute values (120, 111, 333, 222, 61.7, 66.2, 1),
								   (150, 456, 221, 117, 85.4, 32.7, 2)

	insert into VehicleService values('Engine repair', 12-03-2021,1),
									 ('oil filter replacement', 15-03-2021,1)
end
go


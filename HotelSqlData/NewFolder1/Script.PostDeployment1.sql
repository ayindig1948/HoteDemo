/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (select 1 from dbo.roomType)
begin
insert into dbo.RoomType (name,descreptin,Price)
values('King bad','A king bad with window',100),
('queen','Tow queen bads with wendow',115),
('Suit','a badroom and living room',305)
end
declare @rid1 int;
declare @rid2 int;
declare @rid3 int;
select @rid1=Id from dbo.RoomType where name='King bad';

select @rid2=Id from dbo.RoomType where name='queen';

select @rid3=Id from dbo.RoomType where name='Suit';

if not exists (select 1 from dbo.Room)
begin
insert into dbo.Room (RoomNumber,TypeId)
values('101',@rid1),
('102',@rid1),
('103',@rid1),
('201',@rid2),
('202',@rid2),
('301',@rid3)

end

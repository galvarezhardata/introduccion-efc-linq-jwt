use master
go

create database [EfcLinqJwtIntro]
go

use [EfcLinqJwtIntro]
go

create table turno (
	[id] int identity,
	[descripcion] nvarchar(50),
	primary key ([id])
)

create table rol (
	[id] int identity,
	[descripcion] nvarchar(50),
	primary key ([id]),
)

create table persona (
	[id] int identity,
	[nombres] nvarchar(50),
	[email] nvarchar(50),
	[telefono] nvarchar(50),
	[rol] int,
	primary key ([id]),
	foreign key ([rol]) references [rol] ([id])
)

create table curso (
	[id] int identity,
	[descripcion] nvarchar(50),
	[cupos] int,
	[dias] nvarchar(50),
	[turno] int,
	primary key ([id]),
	foreign key ([turno]) references [turno] ([id])
)

create table curso_persona (
	[id] int identity,
	[id_curso] int,
	[id_persona] int,
	primary key ([id]),
	foreign key ([id_curso]) references [curso] ([id]),
	foreign key ([id_persona]) references [persona] ([id])
)

-- AQU� COMIENZA LA CARGA DE DATOS...

insert into [turno] ([descripcion]) values ('Ma�ana')
go

insert into [turno] ([descripcion]) values ('Tarde')
go

insert into [turno] ([descripcion]) values ('Noche')
go

---------------------------------------------------------------------------

insert into [rol] ([descripcion]) values ('Estudiante')
go

insert into [rol] ([descripcion]) values ('Profesor')
go

---------------------------------------------------------------------------

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('german alvarez','g.alvarez@','1168645457',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('martin da veiga','m.daveiga@','1160847475',2)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('gustavo pesci','g.pesci@','1131755164',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('pablo teruel','p.teruel@','1166195539',2)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('gustavo fayard','g.fayard@','1145096091',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('augusto fayar','a.fayard@','1163214722',2)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('marilina landaburu','m.landaburu@','1168014125',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('critsian verduguez','c.verduguez@','1144254556',2)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('ariel villar','a.villar@','1160817678',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('federico perez','f.perez@','1122223333',2)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('ariel martino','a.martino@','1155299630',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('martin fayard','m.fayard@','1145094499',2)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('javier ortolan','j.ortolan@','112223334',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('roberto tejeda','r.tejeda@','1164678956',2)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('paula pesci','p.pesci@','354899455955',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('carlos christot','c.christot@','1150424506',2)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('lucas escobar','l.escobar@','1122223335',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('federico peruzza','f.peruza@','1122223336',2)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('emilce pereyra','e.pereyra@','1122223337',1)
go

insert into [persona] ([nombres],[email],[telefono],[rol]) values ('juan konov','j.konov@','1122223338',2)
go

---------------------------------------------------------------------------

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('programacion i',22,'lunes,martes',1)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('programacion ii',14,'lunes,jueves',2)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('quimica i',20,'martes,sabado',3)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('matematica i',23,'miercoles,viernes',1)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('taller',11,'jueves,viernes',2)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('psicologia',18,'viernes,sabado',3)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('peluqueria',8,'lunes,miercoles',1)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('derecho penal',16,'martes,miercoles',2)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('filosfia',21,'miercoles,sabado',3)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('teolog�a',5,'jueves,sabado',1)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('jardineria',14,'lunes,sabado',2)
go

insert into [curso] ([descripcion],[cupos],[dias],[turno]) values ('electricista',19,'martes,viernes',3)
go

---------------------------------------------------------------------------

insert into curso_persona ([id_curso],[id_persona]) values (1,1)
go

insert into curso_persona ([id_curso],[id_persona]) values (2,2)
go

insert into curso_persona ([id_curso],[id_persona]) values (3,3)
go

insert into curso_persona ([id_curso],[id_persona]) values (4,4)
go

insert into curso_persona ([id_curso],[id_persona]) values (4,5)
go

insert into curso_persona ([id_curso],[id_persona]) values (2,6)
go

insert into curso_persona ([id_curso],[id_persona]) values (5,7)
go

insert into curso_persona ([id_curso],[id_persona]) values (6,8)
go

insert into curso_persona ([id_curso],[id_persona]) values (7,9)
go

insert into curso_persona ([id_curso],[id_persona]) values (8,10)
go

insert into curso_persona ([id_curso],[id_persona]) values (9,11)
go

insert into curso_persona ([id_curso],[id_persona]) values (10,12)
go

insert into curso_persona ([id_curso],[id_persona]) values (11,13)
go

insert into curso_persona ([id_curso],[id_persona]) values (12,14)
go

insert into curso_persona ([id_curso],[id_persona]) values (1,15)
go

insert into curso_persona ([id_curso],[id_persona]) values (4,16)
go

insert into curso_persona ([id_curso],[id_persona]) values (5,17)
go

insert into curso_persona ([id_curso],[id_persona]) values (2,18)
go

insert into curso_persona ([id_curso],[id_persona]) values (6,19)
go

insert into curso_persona ([id_curso],[id_persona]) values (7,20)
go

insert into curso_persona ([id_curso],[id_persona]) values (8,1)
go

insert into curso_persona ([id_curso],[id_persona]) values (9,5)
go

insert into curso_persona ([id_curso],[id_persona]) values (10,8)
go

insert into curso_persona ([id_curso],[id_persona]) values (11,7)
go

insert into curso_persona ([id_curso],[id_persona]) values (12,9)
go

insert into curso_persona ([id_curso],[id_persona]) values (1,3)
go

insert into curso_persona ([id_curso],[id_persona]) values (2,2)
go
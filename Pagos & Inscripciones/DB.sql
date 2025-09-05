create database registros;
use registros;

create table alumno(
	id int primary key identity,
		NombreEstudiante varchar(40) not null,
	ApellidoEstudiante varchar(40) not null,
	Grado varchar(20) not null,
);

create table encargado(
	id int primary key identity,	
	NombreEncargado varchar(40) not null,
	ApellidoEncargado varchar(40) not null,
	Direccion varchar(80),
);

create table pagos(
	id int primary key identity,
	Enero decimal(10,2),
	Febrero decimal(10,2),
	Marzo decimal(10,2),
	Abril  decimal(10,2),
	Mayo  decimal(10,2),
	Junio  decimal(10,2),
	Julio  decimal(10,2),
	Agosto  decimal(10,2),
	Septiembre  decimal(10,2),
	Octubre  decimal(10,2),
	Fechaentrega date,
	MesMax varchar(40),
	idalumno int,
	idpadre int,
	foreign key(idalumno) references alumno(id),
	foreign key(idpadre) references encargado(id),
);
drop table inscripciones;
create table inscripciones(
	id int identity,
	FechaPago date not null,
	monto decimal(10,2) not null,
	-- idEstudiante int,
	NombreEstudiante varchar(40) not null,
	ApellidoEstudiante varchar(40) not null,
	Grado varchar(20) not null,
	-- idEncargado int,
	NombreEncargado varchar(40) not null,
	ApellidoEncargado varchar(40) not null,
	Direccion varchar(80),
	FechaEntrega date,
	MesActual int,
	Enero decimal(10,2),
	Febrero decimal(10,2),
	Marzo decimal(10,2),
	Abril  decimal(10,2),
	Mayo  decimal(10,2),
	Junio  decimal(10,2),
	Julio  decimal(10,2),
	Agosto  decimal(10,2),
	Septiembre  decimal(10,2),
	Octubre  decimal(10,2),
	entregado bit,
); 

select id as 'No. de Registro',FechaPago as 'Fecha de Pago',monto as 'Monto Pagado',NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,NombreEncargado as 'Nombre del Encargado',ApellidoEncargado as 'Apellido del Encargado',Direccion from inscripciones;
select * from inscripciones where Grado = 'Primero Basico';
drop table inscripciones;

select id as 'ID de estudiante',NombreEstudiante as 'Nombre de Estudiante',ApellidoEstudiante as 'Apellido de Estudiante',Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre from inscripciones;


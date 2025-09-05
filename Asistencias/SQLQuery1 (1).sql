Create database asistencias_control;
use asistencias_control;

create table info_alumnos(
	id_alumno int identity primary key,
	nombres_alumno varchar(50) not null,
	apellidos_alumno varchar(50) not null,
	grado varchar(50) not null
);
select * from info_alumnos;
insert into info_alumnos(nombres_alumno,apellidos_alumno,grado)
values
('Luis','Orozco','Primero Basico'),
('Victor','Aquino','Segundo Basico'),
('Alex','Marin','Tercero Basico'),
('Pepe','Goita','Cuarto Bachillerato'),
('Cristian','Castañeda','Quinto Bachillerato'),
('Chile','Cuto Crup','Segundo Basico');


drop table asistencias;
create table asistencias(
	id_asistencia int identity primary key,
	id_alumno int,
	fecha date,
	estado bit,
	foreign key(id_alumno) references info_alumnos(id_alumno)	
);
select * from asistencias;

delete from asistencias where fecha='2025-09-05';

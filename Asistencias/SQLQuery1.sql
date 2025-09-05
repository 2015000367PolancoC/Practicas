Create database asistencias_control;
use asistencias_control;

create table info_alumnos(
	id_alumno int identity primary key,
	nombres_alumno varchar(50) not null,
	apellidos_alumno varchar(50) not null,
	grado text not null,
	clave int not null,
);
select * from info_alumnos;
create table asistencias(
	id int identity primary key,
	fk_id_alumno int,
	fecha date not null,
	foreign key(fk_id_alumno) references info_alumnos(id_alumno)	
);
select * from asistencias;

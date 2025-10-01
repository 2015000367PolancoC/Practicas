Create database asistencias_control;
GO
use asistencias_control;
GO

create table info_alumnos(
	id_alumno int identity primary key,
	nombres_alumno varchar(50) not null,
	apellidos_alumno varchar(50) not null,
	grado varchar(50) not null
);
GO
create table asistencias(
	id_asistencia int identity primary key,
	id_alumno int,
	fecha date,
	estado bit,
	foreign key(id_alumno) references info_alumnos(id_alumno) on delete cascade
);
GO
 
select id_alumno as 'Codigo',nombres_alumno as 'Nombre',apellidos_alumno as 'Apellido',grado as 'Grado' from info_alumnos
insert into info_alumnos(nombres_alumno,apellidos_alumno,grado)
values

/*PRIMERO Básico*/

('Astrid Dayana', 'Álvarez de la Cruz', 'Primero Básico'),
('Ana Camila Suceth', 'Amaya Pérez', 'Primero Básico'),
('Ángel Manuel', 'Armis', 'Primero Básico'),
('Marco Antonio', 'Batres Echeverria', 'Primero Básico'),
('Jhorgeysil Ayleen', 'Bonilla', 'Primero Básico'),
('Angie Delyanne', 'Flores Soyoy', 'Primero Básico'),
('Abi Michelle', 'Gómez Rodríguez', 'Primero Básico'),
('Prisly Adairiz', 'González Ordoñez', 'Primero Básico'),
('Hamilthon Esaú', 'González Sí', 'Primero Básico'),
('Sharon Alejandra', 'Jiménez Soyoy', 'Primero Básico'),
('Lisandro Saúl', 'Juárez Escalante', 'Primero Básico'),
('Rosa María', 'Macario Vicente', 'Primero Básico'),
('Tomás Santiago', 'Mateo Sapón', 'Primero Básico'),
('Austin Daniel', 'Montes Arreola', 'Primero Básico'),
('Jeffrey Mateo', 'Natareno Toc', 'Primero Básico'),
('Mario Martin', 'Patzán Hernández', 'Primero Básico'),
('Diego Andreé', 'Rodas Zurdo', 'Primero Básico'),
('Katherine Mariana', 'Romero Méndez', 'Primero Básico'),
('Edwin David', 'Roquel Caniche', 'Primero Básico'),
('Norman Isaac', 'Soc Grande', 'Primero Básico'),
('Jennyfer Ximena', 'Váldez Urbina', 'Primero Básico'),
('Martina Fátima Saraí', 'Rivas Velásquez', 'Primero Básico'),
('Alberth de Jesús', 'Contreras Corea', 'Primero Básico'),
('Antoni Vinicio', 'Ismalé Pérez', 'Primero Básico'),
('Candy Fabiola Odeth', 'Simón Peren', 'Primero Básico'),
('Jhoshua Gamaliel', 'Molina Case', 'Primero Básico'),
('Kiara Julissa Leilany', 'Benito Pérez ', 'Primero Básico'),

/*SEGUNDO Básico*/

('Mia Scarlet Susana', 'Carrera Lobos', 'Segundo Básico'),
('Candy Mishelle', 'Chocoj Rodríguez', 'Segundo Básico'),
('Daniela Jimena', 'Fernández Raymundo', 'Segundo Básico'),
('Adam Carlos Enrique', 'Hernández Mendoza', 'Segundo Básico'),
('Karely Nicole', 'Hernández Vargas', 'Segundo Básico'),
('Alexandra Anahí Yanet', 'Higueros Burrión', 'Segundo Básico'),
('Scarlett Dajane', 'Marroquín Orantes', 'Segundo Básico'),
('Melany Anahí', 'Martin Ajiatáz', 'Segundo Básico'),
('Kristen Nicol', 'Meletz Carrera', 'Segundo Básico'),
('Jeremy Alexis', 'Méndez Ijchajchal', 'Segundo Básico'),
('Ilbia Rosalia', 'Morales Agustín', 'Segundo Básico'),
('Pedro Josué', 'Ordoñez Zurdo', 'Segundo Básico'),
('Julio Alejandro Jeremiah', 'Ordoñez Zurdo', 'Segundo Básico'),
('Sherlin Esmeralda', 'Patzan Díaz', 'Segundo Básico'),
('Damaris Anay', 'Rafael Baíl', 'Segundo Básico'),
('Jeferson Omar Israel', 'Rangel Foronda', 'Segundo Básico'),
('Mildre Aracely', 'Salalá Soyos', 'Segundo Básico'),
('Jocelyn Mchelle', 'Salala Soyos', 'Segundo Básico'),
('Iñaki Lorenzo Antonio', 'Solis Salguero', 'Segundo Básico'),
('Kristofer Augusto', 'Toledo Chiquitó', 'Segundo Básico'),
('Londy María', 'Tzul Quiñónez', 'Segundo Básico'),
('Erick Andrés', 'Yoque Domingo', 'Segundo Básico'),
('Sharóm Solansh Gabriela', 'Contreras Corea', 'Segundo Básico'),
('Ghylaine Cristina', 'Ozuna Barillas', 'Segundo Básico'),
('Estefany Paola', 'Morataya Patzán', 'Segundo Básico'),
('William Jesús', 'Fernández Reyes', 'Segundo Básico'),
('Ligia Virginia', 'Gutiérrez Salazar', 'Segundo Básico'),

/*TERCERO Básico*/

('Gloria Karina', 'Camey Osorio', 'Tercero Básico'),
('Jessica Paola', 'Chaman', 'Tercero Básico'),
('Naomi Susana', 'Cuc Gonzáles', 'Tercero Básico'),
('Eddy Randolfo', 'Figueroa Martínez', 'Tercero Básico'),
('Emily Julissa', 'Jocón Barillas', 'Tercero Básico'),
('Wendy Johana', 'Mauricio López', 'Tercero Básico'),
('Caterine Helizabeth', 'Méndez Jacobo', 'Tercero Básico'),
('Angelin Daniela', 'Ochoa Quisquina', 'Tercero Básico'),
('Axel Emanuel', 'Ortíz Yax', 'Tercero Básico'),
('Cristian Rodolfo', 'Quisquina Locon', 'Tercero Básico'),
('Axel Eduardo', 'Saban', 'Tercero Básico'),
('María Elizabeth de la Soledad', 'Santizo de León', 'Tercero Básico'),
('Wilson Alexander', 'Sicay Pérez', 'Tercero Básico'),
('Mayda Nicol', 'Subuyuj Morales', 'Tercero Básico'),
('Angelly Marleni Noemy', 'Tiul Coc', 'Tercero Básico'),
('Jayra Baneza', 'Tiul Coc', 'Tercero Básico'),
('Jefersón Estiven', 'Váldez Urbina', 'Tercero Básico'),
('Ángel Ricardo', 'Méndez Chávez', 'Tercero Básico'),
('Katheryn Amarylis', 'Villagrán Mijangos', 'Tercero Básico'),
('Randy Alexander', 'Peren Otzoy', 'Tercero Básico'),
('Maryury Daniela', 'Molina Case', 'Tercero Básico'),

/*CUARTO BACHILLERATO*/
('Lesly Nohemí', 'Ajichiqui Diaz', 'Cuarto Bachillerato'),
('Reina Marisol', 'Castillo Alay', 'Cuarto Bachillerato'),
('Emerson Aimar', 'Higueros Burrión', 'Cuarto Bachillerato'),
('Daniela Abigail', 'Ique González', 'Cuarto Bachillerato'),
('Daphne Ahtziri Desiré', 'Natareno Toc', 'Cuarto Bachillerato'),
('Danna Fernanda', 'Urizar Poroj', 'Cuarto Bachillerato'),
('Edward Steven', 'Mansia Pérez', 'Cuarto Bachillerato'),
('Michael Alexander', 'Xiloj Rueda', 'Cuarto Bachillerato'),
('Yamíli Jimena', 'López Flores', 'Cuarto Bachillerato'),
('Cristofer Misael', 'López Ventura', 'Cuarto Bachillerato'),
('Cristian Manuel', 'Sánchez Pérez', 'Cuarto Bachillerato'),
('Carmen Sarahi', 'Ponce Suchite', 'Cuarto Bachillerato'),
('Franklin Ricardo', 'Velasquez Raxón', 'Cuarto Bachillerato'),
('Dulce María José', 'González Yoc', 'Cuarto Bachillerato'),

/*QUINTO BACHILLERATO*/
('Jaqueline Pamela', 'Barrios Cuyun', 'Quinto Bachillerato'),
('Francisco Jesús', 'Gutiérrez Gálvez', 'Quinto Bachillerato'),
('Cristofer Emilio Alejandro', 'Patzan Díaz', 'Quinto Bachillerato'),
('Rodrigo Alexander', 'Rodas Villeda', 'Quinto Bachillerato'),
('Sharon Dayan', 'Velásquez Cano', 'Quinto Bachillerato');


select a.nombres_alumno as 'Nombre',a.apellidos_alumno as 'Apellido', a.grado as 'Grado', s.fecha as 'Fecha',s.estado as 'Presente' from info_alumnos a inner join asistencias s on a.id_alumno = s.id_alumno where grado='Primero Básico';

SELECT nombres_alumno AS 'Nombre',apellidos_alumno AS 'Apellido',grado AS 'Grado' from info_alumnos where grado = 'Segundo Básico'
ORDER BY 
    CASE 
        WHEN grado = 'Primero Básico' THEN 1
        WHEN grado = 'Segundo Básico' THEN 2
        WHEN grado = 'Tercero Básico' THEN 3
        WHEN grado = 'Cuarto Bachillerato' THEN 4
        WHEN grado = 'Quinto Bachillerato' THEN 5
        ELSE 1000
    END asc, apellidos_alumno asc;


	IF (SELECT grado FROM info_alumnos) = 'Primero Básico'
		update info_alumnos SET grado = 'Segundo Básico' where grado = 'Primero Básico'

SELECT COUNT(*) FROM info_alumnos WHERE grado = 'Primero Básico';
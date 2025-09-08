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
	foreign key(id_alumno) references info_alumnos(id_alumno)	
);
GO
 
select id_alumno as 'Codigo',nombres_alumno as 'Nombre',apellidos_alumno as 'Apellido',grado as 'Grado' from info_alumnos


insert into info_alumnos(nombres_alumno,apellidos_alumno,grado)
values

/*PRIMERO BASICO*/

('Astrid Dayana', 'Álvarez de la Cruz', 'Primero Basico'),
('Ana Camila Suceth', 'Amaya Pérez', 'Primero Basico'),
('Ángel Manuel', 'Armis', 'Primero Basico'),
('Marco Antonio', 'Batres Echeverria', 'Primero Basico'),
('Jhorgeysil Ayleen', 'Bonilla', 'Primero Basico'),
('Angie Delyanne', 'Flores Soyoy', 'Primero Basico'),
('Abi Michelle', 'Gómez Rodríguez', 'Primero Basico'),
('Prisly Adairiz', 'González Ordoñez', 'Primero Basico'),
('Hamilthon Esaú', 'González Sí', 'Primero Basico'),
('Sharon Alejandra', 'Jiménez Soyoy', 'Primero Basico'),
('Lisandro Saúl', 'Juárez Escalante', 'Primero Basico'),
('Rosa María', 'Macario Vicente', 'Primero Basico'),
('Tomás Santiago', 'Mateo Sapón', 'Primero Basico'),
('Austin Daniel', 'Montes Arreola', 'Primero Basico'),
('Jeffrey Mateo', 'Natareno Toc', 'Primero Basico'),
('Mario Martin', 'Patzán Hernández', 'Primero Basico'),
('Diego Andreé', 'Rodas Zurdo', 'Primero Basico'),
('Katherine Mariana', 'Romero Méndez', 'Primero Basico'),
('Edwin David', 'Roquel Caniche', 'Primero Basico'),
('Norman Isaac', 'Soc Grande', 'Primero Basico'),
('Jennyfer Ximena', 'Váldez Urbina', 'Primero Basico'),
('Martina Fátima Saraí', 'Rivas Velásquez', 'Primero Basico'),
('Alberth de Jesús', 'Contreras Corea', 'Primero Basico'),
('Antoni Vinicio', 'Ismalé Pérez', 'Primero Basico'),
('Candy Fabiola Odeth', 'Simón Peren', 'Primero Basico'),
('Jhoshua Gamaliel', 'Molina Case', 'Primero Basico'),
('Kiara Julissa Leilany', 'Benito Pérez ', 'Primero Basico'),

/*SEGUNDO BASICO*/

('Mia Scarlet Susana', 'Carrera Lobos', 'Segundo Basico'),
('Candy Mishelle', 'Chocoj Rodríguez', 'Segundo Basico'),
('Daniela Jimena', 'Fernández Raymundo', 'Segundo Basico'),
('Adam Carlos Enrique', 'Hernández Mendoza', 'Segundo Basico'),
('Karely Nicole', 'Hernández Vargas', 'Segundo Basico'),
('Alexandra Anahí Yanet', 'Higueros Burrión', 'Segundo Basico'),
('Scarlett Dajane', 'Marroquín Orantes', 'Segundo Basico'),
('Melany Anahí', 'Martin Ajiatáz', 'Segundo Basico'),
('Kristen Nicol', 'Meletz Carrera', 'Segundo Basico'),
('Jeremy Alexis', 'Méndez Ijchajchal', 'Segundo Basico'),
('Ilbia Rosalia', 'Morales Agustín', 'Segundo Basico'),
('Pedro Josué', 'Ordoñez Zurdo', 'Segundo Basico'),
('Julio Alejandro Jeremiah', 'Ordoñez Zurdo', 'Segundo Basico'),
('Sherlin Esmeralda', 'Patzan Díaz', 'Segundo Basico'),
('Damaris Anay', 'Rafael Baíl', 'Segundo Basico'),
('Jeferson Omar Israel', 'Rangel Foronda', 'Segundo Basico'),
('Mildre Aracely', 'Salalá Soyos', 'Segundo Basico'),
('Jocelyn Mchelle', 'Salala Soyos', 'Segundo Basico'),
('Iñaki Lorenzo Antonio', 'Solis Salguero', 'Segundo Basico'),
('Kristofer Augusto', 'Toledo Chiquitó', 'Segundo Basico'),
('Londy María', 'Tzul Quiñónez', 'Segundo Basico'),
('Erick Andrés', 'Yoque Domingo', 'Segundo Basico'),
('Sharóm Solansh Gabriela', 'Contreras Corea', 'Segundo Basico'),
('Ghylaine Cristina', 'Ozuna Barillas', 'Segundo Basico'),
('Estefany Paola', 'Morataya Patzán', 'Segundo Basico'),
('William Jesús', 'Fernández Reyes', 'Segundo Basico'),
('Ligia Virginia', 'Gutiérrez Salazar', 'Segundo Basico'),

/*TERCERO BASICO*/

('Gloria Karina', 'Camey Osorio', 'Tercero Basico'),
('Jessica Paola', 'Chaman', 'Tercero Basico'),
('Naomi Susana', 'Cuc Gonzáles', 'Tercero Basico'),
('Eddy Randolfo', 'Figueroa Martínez', 'Tercero Basico'),
('Emily Julissa', 'Jocón Barillas', 'Tercero Basico'),
('Wendy Johana', 'Mauricio López', 'Tercero Basico'),
('Caterine Helizabeth', 'Méndez Jacobo', 'Tercero Basico'),
('Angelin Daniela', 'Ochoa Quisquina', 'Tercero Basico'),
('Axel Emanuel', 'Ortíz Yax', 'Tercero Basico'),
('Cristian Rodolfo', 'Quisquina Locon', 'Tercero Basico'),
('Axel Eduardo', 'Saban', 'Tercero Basico'),
('María Elizabeth de la Soledad', 'Santizo de León', 'Tercero Basico'),
('Wilson Alexander', 'Sicay Pérez', 'Tercero Basico'),
('Mayda Nicol', 'Subuyuj Morales', 'Tercero Basico'),
('Angelly Marleni Noemy', 'Tiul Coc', 'Tercero Basico'),
('Jayra Baneza', 'Tiul Coc', 'Tercero Basico'),
('Jefersón Estiven', 'Váldez Urbina', 'Tercero Basico'),
('Ángel Ricardo', 'Méndez Chávez', 'Tercero Basico'),
('Katheryn Amarylis', 'Villagrán Mijangos', 'Tercero Basico'),
('Randy Alexander', 'Peren Otzoy', 'Tercero Basico'),
('Maryury Daniela', 'Molina Case', 'Tercero Basico'),

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


select a.nombres_alumno as 'Nombre',a.apellidos_alumno as 'Apellido', a.grado as 'Grado', s.fecha as 'Fecha',s.estado as 'Presente' from info_alumnos a inner join asistencias s on a.id_alumno = s.id_alumno where grado='Primero basico';

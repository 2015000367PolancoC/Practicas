create database registros;
use registros;

create table alumno(
	id int primary key identity,
		NombreEstudiante varchar(40) not null,
	ApellidoEstudiante varchar(40) not null,
	Grado varchar(20) not null,
);



select * from alumno;

insert into alumno(NombreEstudiante,ApellidoEstudiante,Grado)
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

drop table encargado;
select * from encargado;
create table encargado(
	id int primary key identity,	
	NombreCompletoE1 varchar(200) null,
	NombreCompletoE2 varchar(200) null,
	telefonoE1 int null,
	telefonoE2 int null,
	Direccion varchar(80) null,
);

insert into encargado(NombreCompletoE1, NombreCompletoE2, telefonoE1, telefonoE2, Direccion)
values
/*PRIMERO BASICO*/
('Yesenia de la Cruz García','','39092709','','/**/'),
('Ingrid Aracely Zelada Chinchilla','','59612899','','/**/'),
('Claudia Armis Boch','María Boch','45381094','39905979','/**/'),
('Jubitza Echeverría Contreras','','50457969','','/**/'),
('Silvia Azucena Bonilla Vanegas','','39134349','','/**/'),
('Julissa Xiomara Soyoy Tuquer','','37096020','','/**/'),
('Marta Julia Rodríguez','','56154185','','/**/'),
('Amalia Muñoz','','51242275','','/**/'),
('María Elvira Sí Tot','','43586033','','/**/'),
('María Fernanda Miranda Paredes','','41446981','','/**/'),
('Gumercinda Concepción Escalante Hernández','','56993330','','/**/'),
('Ana Macario Vicente','','58682459','','/**/'),
('María Maricela Sapón Sulugüi','','32965044','','/**/'),
('Paula Melissa Estrada Arreola','','59321086','','/**/'),
('Domingo Elizabeth Natareno','','35891672','','/**/'),
('Mario Martín Patzán Ortiz','','36921603','','/**/'),
('Andrea Paola Zurdo Batz','','33049629','','/**/'),
('','','','','/**/'),
('Reina Araceli Caniche Nicolás','','51139210','','/**/'),
('Beatriz Soc','','48442237','','/**/'),
('Julia Virginia Urbina  Váldez','','36921477','','/**/'),
('Reyna Josefina Velásquez Ríos','','58335953','','/**/'),
('Karla Corea','','47424386','','/**/'),
('Sandra Pérez','','56934232','','/**/'),
('Elvira Peren Otzoy','','36223361','','/**/'),
('Jonny Gamaliel Molina Contreras','','39092709','','/**/'),
('Jezly Robersy Mirella Benito López','','40063989','','/**/')

/*SEGUNDO BASICO*/
insert into encargado(NombreCompletoE1, NombreCompletoE2, telefonoE1, telefonoE2, Direccion)
values
('Verónica Patricia Lobos','','42215210','','/**/'),
('Enma Edelmira Rodríguez Estrada','','56939034','','/**/'),
('Juana Janeth Raymundo Pop','','30100349','','/**/'),
('Linda Ssusset Mendoza Medrano','','38133938','','/**/'),
('Nolvia Liseth Vargas Orellana','','36127776','','/**/'),
('Celia Yaneth Burrión León','','59915415','','/**/'),
('Gloria Mirna Orantes','','50636279','','/**/'),
('Debora Raquel Ajiatás Hernández','','58559961','','/**/'),
('Evelin Marleni Carrera Cruz','','44431110','','/**/'),
('Dolores Ijchajchal Gónzalez','','45232828','','/**/'),
('Ilbia Rosalía Agustín Yol','','37950050','','/**/'),
('Andrea Paola Zurdo Batz','','33049620','48440150','/**/'),
('Andrea Paola Zurdo Batz','','33049620','48440150','/**/'),
('Nancy Maribel Díaz Rueda','Ana María Barrientos','50817240','33355710','/**/'),
('Ofelia Baíl Gómez','','45769306','','/**/'),
('Glenda Patricia Foronda','','59761035','','/**/'),
('María Sandra Soyos Xocoxic','','45744662','','/**/'),
('María Sandra Soyos Xocoxic','','45744662','','/**/'),
('Hilda Salguero','','41859786','','/**/'),
('Aura Estela Chiquitó','','31180246','','/**/'),
('María Nieves García','','51826697','','/**/'),
('Carolina Jasmin Yoque Domingo','','37370430','','/**/'),
('Karla Corea','','47424386','','/**/'),
('Jessica Mariela Ozuna Barillas','','49190774','','/**/'),
('María de los Ángeles Patzán','','42957039','','/**/'),
('Mayra Marilú Reyes Chilin','','59650988','','/**/'),
('Ana Mabely Salazar Flores','','49395804','','/**/');

/*TERCERO BASICO*/



drop table pagos;
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


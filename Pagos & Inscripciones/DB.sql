create database registros;
use registros;

create table alumno(
	id int primary key identity,
	NombreEstudiante varchar(40) not null,
	ApellidoEstudiante varchar(40) not null,
	Grado varchar(20) not null,
	Direccion varchar(200) null,
);

select * from alumno;
/*PRIMERO BASICO*/

insert into alumno(NombreEstudiante, ApellidoEstudiante, Grado, Direccion)
values

/*1*/('Astrid Dayana', 'Álvarez de la Cruz', 'Primero Basico','6a. Calle A 14-28 Zona 7, Col. Quinta Samayoa'),
/*2*/('Ana Camila Suceth', 'Amaya Pérez', 'Primero Basico','19 Av. 7-74 Zona 7 Col. Kaminal Juyu I'),
/*3*/('Ángel Manuel', 'Armis', 'Primero Basico','4a. Ca12-07 Zona 7,  Col. Quinta Samayoa'),
/*4*/('Marco Antonio', 'Batres Echeverria', 'Primero Basico','20 Av. 13-30 Zona 7 Col. Kaminla Juyu II'),
/*5*/('Jhorgeysil Ayleen', 'Bonilla', 'Primero Basico','4ta. Calle 13-01 Zona 7 Col. Quinta Samayoa'),
/*6*/('Angie Delyanne', 'Flores Soyoy', 'Primero Basico','14 Av. 6-60 Zona 7 Col. Quinta Samayoa'),
/*7*/('Abi Michelle', 'Gómez Rodríguez', 'Primero Basico','7a. Calle 10-40 Zona 7, Col. Quinta Samayoa'),
/*8*/('Prisly Adairiz', 'González Ordoñez', 'Primero Basico','3ra. Calle B 13-29 Zona 7 Col. Quinta Samayoa'),
/*9*/('Hamilthon Esaú', 'González Sí', 'Primero Basico','6ta. Calle A 10-66 Zona 7, Col. Quinta Samayoa'),
/*10*/('Sharon Alejandra', 'Jiménez Soyoy', 'Primero Basico','13 Av. 7-27 Zona 7, Col. Quinta Samayoa'),
/*11*/('Lisandro Saúl', 'Juárez Escalante', 'Primero Basico','6a. Calle A 13-38 Zona 7, Col. Quinta Samayoa'),
/*12*/('Rosa María', 'Macario Vicente', 'Primero Basico','7a. Calle A 12-24 Zona 7, Col. Quinta Samayoa'),
/*13*/('Tomás Santiago', 'Mateo Sapón', 'Primero Basico','9a. Calle 11-84 Zona 7, Col. Castillo Lara'),
/*14*/('Austin Daniel', 'Montes Arreola', 'Primero Basico','5ta. Calle 13-15 Zona 7, Col. Quinta Samayoa'),
/*15*/('Jeffrey Mateo', 'Natareno Toc', 'Primero Basico','11 Av. 10-64 Zona 7, Col. Castillo Lara'),
/*16*/('Mario Martin', 'Patzán Hernández', 'Primero Basico','5ta. Calle 11-70 Zona 7 Col. Quinta Samayoa'),
/*17*/('Diego Andreé', 'Rodas Zurdo', 'Primero Basico','7a. Calle 14-37 Zona 7, Col. Quinta Samayoa, Zona 7'),
/*18*/('Katherine Mariana', 'Romero Méndez', 'Primero Basico','28 Av. A 23-06 Col. Cuatro de febrero, zona 7'),
/*19*/('Edwin David', 'Roquel Caniche', 'Primero Basico','6ta. Calle 11-24 Zona 7 Col. Quinta Samayoa'),
/*20*/('Norman Isaac', 'Soc Grande', 'Primero Basico','M.  2 Lote 12 Asen. 24 de Dic. Final Col Verbena Z. 7'),
/*21*/('Jennyfer Ximena', 'Váldez Urbina', 'Primero Basico','28 Av. A 23-06 Col. Cuatro de febrero, zona 7'),
/*22*/('Martina Fátima Saraí', 'Rivas Velásquez', 'Primero Basico','3a. Av. 6-18 Zona 7, Col. Landivar'),
/*23*/('Alberth de Jesús', 'Contreras Corea', 'Primero Basico','23 Av. 13-86 Zona 7, Kaminal Juyu II'),
/*24*/('Antoni Vinicio', 'Ismalé Pérez', 'Primero Basico','11 14-80 Zona 7, Col. Castillo Lara '),
/*25*/('Candy Fabiola Odeth', 'Simón Peren', 'Primero Basico','11 CALLE 14-67 Zona 7, Col. Castillo Lara'),
/*26*/('Jhoshua Gamaliel', 'Molina Case', 'Primero Basico','10a. Calle 13-62 Zona 7, Col. Castillo Lara'),
/*27*/('Kiara Julissa Leilany', 'Benito Pérez ', 'Primero Basico','8a. Calle 11-78 Col. Quinta Samayoa');

/*SEGUNDO BASICO*/
insert into alumno(NombreEstudiante, ApellidoEstudiante, Grado, Direccion)
values
('Mia Scarlet Susana', 'Carrera Lobos', 'Segundo Basico','19 Av. 13-67 Col. Kaminal Juyu II'),
('Candy Mishelle', 'Chocoj Rodríguez', 'Segundo Basico','6ta. Calle A 7-50 Zona 7, Col. Quinta Samayoa '),
('Daniela Jimena', 'Fernández Raymundo', 'Segundo Basico','8a. Calle 4-76 Zona 7 Col. Landivar'),
('Adam Carlos Enrique', 'Hernández Mendoza', 'Segundo Basico','18 calle 8.01 Zona 7 Col. Verbena'),
('Karely Nicole', 'Hernández Vargas', 'Segundo Basico','12 calle 6-15 Zona 7, Col. Verbena'),
('Alexandra Anahí Yanet', 'Higueros Burrión', 'Segundo Basico','31. Av. B 23-32 M. 81 Ast. El esfuerzo Zona 7'),
('Scarlett Dajane', 'Marroquín Orantes', 'Segundo Basico','11 calle B 11-58 Zona 7 Col. Verbena'),
('Melany Anahí', 'Martin Ajiatáz', 'Segundo Basico','11 Av. 12-59 Zona 7 Col. Castillo Lara'),
('Kristen Nicol', 'Meletz Carrera', 'Segundo Basico','17 calle 8.69 Zona 7 Col. Verbena'),
('Jeremy Alexis', 'Méndez Ijchajchal', 'Segundo Basico','11 Av. 10-53 Zona 7, Col. Castillo Lara'),
('Ilbia Rosalia', 'Morales Agustín', 'Segundo Basico','14 calle 9.42 Zona 7, Col. Castillo Lara'),
('Pedro Josué', 'Ordoñez Zurdo', 'Segundo Basico','7a. Calle 14-37 Zona 7, Col. Quinta Samayoa, Zona 7'),
('Julio Alejandro Jeremiah', 'Ordoñez Zurdo', 'Segundo Basico','7a. Calle 14-37 Zona 7, Col. Quinta Samayoa, Zona 7'),
('Sherlin Esmeralda', 'Patzan Díaz', 'Segundo Basico','13 Av. B 31-06 Col. Bethania Zona 7'),
('Damaris Anay', 'Rafael Baíl', 'Segundo Basico','7a. Calle A 11-12 Zona 7 Col. Quinta Samayoa'),
('Jeferson Omar Israel', 'Rangel Foronda', 'Segundo Basico','13 calle 7a. Av. Final Joya 2, Lote 73 A La Verbena, Z. 7'),
('Mildre Aracely', 'Salalá Soyos', 'Segundo Basico','7a. Calle 14-18, Zona 7 Col. Quinta Samayoa'),
('Joselyn Mishelle', 'Salala Soyos', 'Segundo Basico','7a. Calle 14-18, Zona 7 Col. Quinta Samayoa'),
('Iñaki Lorenzo Antonio', 'Solis Salguero', 'Segundo Basico','13 calle B 18-20 Zona 7 Col. Kaminal Juyup II'),
('Kristofer Augusto', 'Toledo Chiquitó', 'Segundo Basico','5ta. Calle 9-13 Zona 7 Col. Quinta Samayoa'),
('Londy María', 'Tzul Quiñónez', 'Segundo Basico','13 calle C 25-04 Zona 7, Col. Kaminal Juyup'),
('Erick Andrés', 'Yoque Domingo', 'Segundo Basico','8a. Calle C 11-71 Zona 7 Col. Verbena'),
('Sharóm Solansh Gabriela', 'Contreras Corea', 'Segundo Basico','23 Av. 13-86 Zona 7, Kaminal Juyu II'),
('Ghylaine Cristina', 'Ozuna Barillas', 'Segundo Basico','10 Av. Final Lote 58 Joya 5 Col. Verbena'),
('Estefany Paola', 'Morataya Patzán', 'Segundo Basico','8a. Calle 14 Av. 13-89 Zona 7, Quinta Samayoa'),
('William Jesús', 'Fernández Reyes', 'Segundo Basico','19 Av. 13-62 Zona 7 Col.  Kaminal II'),
('Ligia Virginia', 'Gutiérrez Salazar', 'Segundo Basico','7a. Calle A 10-23 Zona 7, Col. Quinta Samayoa');

/*TERCERO BASICO*/
insert into alumno(NombreEstudiante, ApellidoEstudiante, Grado, Direccion)
values
('Gloria Karina', 'Camey Osorio', 'Tercero Basico',''),
('Jessica Paola', 'Chaman', 'Tercero Basico','9a. Av. 4-17 Zona 7, Col. Quinta Samayoa'),
('Naomi Susana', 'Cuc Gonzáles', 'Tercero Basico',''),
('Eddy Randolfo', 'Figueroa Martínez', 'Tercero Basico',''),
('Emily Julissa', 'Jocón Barillas', 'Tercero Basico','14 Av. 7-70 Zona 7, Col. Quinta Samayoa'),
('Wendy Johana', 'Mauricio López', 'Tercero Basico','Sec. 3 L. 30 Aset. 24 de Dic. Zona 7, Verbena'),
('Caterine Helizabeth', 'Méndez Jacobo', 'Tercero Basico',''),
('Angelin Daniela', 'Ochoa Quisquina', 'Tercero Basico',''),
('Axel Emanuel', 'Ortíz Yax', 'Tercero Basico','L. 11 Sec. 3 Ast. 24 de Dic. , Zona 7, Col. Verbena'),
('Cristian Rodolfo', 'Patzán Morales', 'Tercero Basico','7a. Calle 13-13 Zona 7 Col. Quinta Samayoa'),
('Axel Eduardo', 'Quisquina Locon', 'Tercero Basico','7a. Calle 11-48 Zona 7, Col. Quinta Samayoa'),
('María Elizabeth de la Soledad', 'Saban', 'Tercero Basico','23 Av. 13-86 Zona 7'),
('Wilson Alexander', 'Santizo de León', 'Tercero Basico','Col. Bethania'),
('Mayda Nicol', 'Sicay Pérez', 'Tercero Basico','10 Av. 13-01 Zona 7, Col. Castillo Lara'),
('Angelly Marleni Noemy', 'Subuyuj Morales', 'Tercero Basico','6a. Calle 11-23 Zona 7, Col. Quinta Samayoa'),
('Jayra Baneza', 'Tiul Coc', 'Tercero Basico','6ta. Calle A 13-81 Z 7, Col. Quinta Samayoa'),
('Jefersón Estiven', 'Váldez Urbina', 'Tercero Basico','12 Av. 4-26 Zona 7 Col. Quinta Samayoa'),
('Ángel Ricardo', 'Méndez Chávez', 'Tercero Basico',''),
('Katheryn Amarylis', 'Villagrán Mijangos', 'Tercero Basico',''),
('Randy Alexander', 'Peren Otzoy', 'Tercero Basico',''),
('Maryury Daniela', 'Molina Case', 'Tercero Basico',''),

/*CUARTO BACHILLERATO*/
('Lesly Nohemí', 'Ajichiqui Diaz', 'Cuarto Bachillerato',''),
('Reina Marisol', 'Castillo Alay', 'Cuarto Bachillerato',''),
('Emerson Aimar', 'Higueros Burrión', 'Cuarto Bachillerato',''),
('Daniela Abigail', 'Ique González', 'Cuarto Bachillerato',''),
('Daphne Ahtziri Desiré', 'Natareno Toc', 'Cuarto Bachillerato',''),
('Danna Fernanda', 'Urizar Poroj', 'Cuarto Bachillerato',''),
('Edward Steven', 'Mansia Pérez', 'Cuarto Bachillerato',''),
('Michael Alexander', 'Xiloj Rueda', 'Cuarto Bachillerato',''),
('Yamíli Jimena', 'López Flores', 'Cuarto Bachillerato',''),
('Cristofer Misael', 'López Ventura', 'Cuarto Bachillerato',''),
('Cristian Manuel', 'Sánchez Pérez', 'Cuarto Bachillerato',''),
('Carmen Sarahi', 'Ponce Suchite', 'Cuarto Bachillerato',''),
('Franklin Ricardo', 'Velasquez Raxón', 'Cuarto Bachillerato',''),
('Dulce María José', 'González Yoc', 'Cuarto Bachillerato',''),

/*QUINTO BACHILLERATO*/
('Jaqueline Pamela', 'Barrios Cuyun', 'Quinto Bachillerato',''),
('Francisco Jesús', 'Gutiérrez Gálvez', 'Quinto Bachillerato',''),
('Cristofer Emilio Alejandro', 'Patzan Díaz', 'Quinto Bachillerato',''),
('Rodrigo Alexander', 'Rodas Villeda', 'Quinto Bachillerato',''),
('Sharon Dayan', 'Velásquez Cano', 'Quinto Bachillerato','');


drop table alumno;



select * from alumno;


drop table encargado;
select * from encargado;
create table encargado(
	id int primary key identity,	
	NombreCompletoE1 varchar(200) null,
	NombreCompletoE2 varchar(200) null,
	telefonoE1 int null,
	telefonoE2 int null
);
/*PRIMERO BASICO*/
insert into encargado(NombreCompletoE1, NombreCompletoE2, telefonoE1, telefonoE2)
values

/*1*/('Yesenia de la Cruz García','','39092709','',''),
/*2*/('Ingrid Aracely Zelada Chinchilla','','59612899','','/**/'),
/*3*/('Claudia Armis Boch','María Boch','45381094','39905979','/**/'),
/*4*/('Jubitza Echeverría Contreras','','50457969','','/**/'),
/*5*/('Silvia Azucena Bonilla Vanegas','','39134349','','/**/'),
/*6*/('Julissa Xiomara Soyoy Tuquer','','37096020','','/**/'),
/*7*/('Marta Julia Rodríguez','','56154185','','/**/'),
/*8*/('Amalia Muñoz','','51242275','','/**/'),
/*9*/('María Elvira Sí Tot','','43586033','','/**/'),
/*10*/('María Fernanda Miranda Paredes','','41446981','','/**/'),
/*11*/('Gumercinda Concepción Escalante Hernández','','56993330','','/**/'),
/*12*/('Ana Macario Vicente','','58682459','','/**/'),
/*13*/('María Maricela Sapón Sulugüi','','32965044','','/**/'),
/*14*/('Paula Melissa Estrada Arreola','','59321086','','/**/'),
/*15*/('Domingo Elizabeth Natareno','','35891672','','/**/'),
/*16*/('Mario Martín Patzán Ortiz','','36921603','','/**/'),
/*17*/('Andrea Paola Zurdo Batz','','33049629','','/**/'),
/*18*/('','','','','/**/'),
/*19*/('Reina Araceli Caniche Nicolás','','51139210','','/**/'),
/*20*/('Beatriz Soc','','48442237','','/**/'),
/*21*/('Julia Virginia Urbina  Váldez','','36921477','','/**/'),
/*22*/('Reyna Josefina Velásquez Ríos','','58335953','','/**/'),
/*23*/('Karla Corea','','47424386','','/**/'),
/*24*/('Sandra Pérez','','56934232','','/**/'),
/*25*/('Elvira Peren Otzoy','','36223361','','/**/'),
/*26*/('Jonny Gamaliel Molina Contreras','','39092709','','/**/'),
/*27*/('Jezly Robersy Mirella Benito López','','40063989','','/**/')

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
insert into encargado(NombreCompletoE1, NombreCompletoE2, telefonoE1, telefonoE2, Direccion)
values
('','','','','/**/'),
('Celia Chamán','','47616125','','/**/'),
('Marly Susana Cuc González','','','','/**/'),
('Mayra Ester Aguilar','Huberto Randolfo Figueroa Natareno','31912974','59003561','/**/'),
('Andrea Betzabé Barillas Villanueva','','49647451','','/**/'),
('Eva López','','46345995','','/**/'),
('Amparo Elizabeth Jacobo Yool','Robin Mendéz','56691790','51853591','/**/'),
('Antonieta Quisquina Locón','','45913845','','/**/'),
('Evelyn Marleni Yax','','50121187','','/**/'),
('Rudy Rodolfo Patzán Gómez','','47616125','','/**/'),
('Antonieta Quisquina Locón','','45913845','','/**/'),
('Victoria Sabán','','45028704','','/**/'),
('','','','','/**/'),
('Fermina Pérez Pérez','','39821733','','/**/'),
('Ana Marleni Morales Castillo','','43393260','','/**/'),
('Hermelindo Tiul Coc','','30444545','','/**/'),
('Julia Urbina','','36921477','','/**/'),
('Juan Ramón Chavez Alvarado','','47619083','','/**/'),
('Juan Carlois Villagrán','','41343873','','/**/'),
('','','','','/**/'),
('Yuvicsa Ninnet Case','','41058068','51100327','/**/');

/*CUARTO BACHILLERATO*/
insert into encargado(NombreCompletoE1, NombreCompletoE2, telefonoE1, telefonoE2, Direccion)
values
('Dominga Díaz','','47467512','','/**/'),
('Veralicia Alay Samayoa','','42645532','','/**/'),
('Celia Yaneth Burrión León','','59915415','','/**/'),
('Daniela Percel Ique','','59761478','50139540','/**/'),
('Dominga Elizabeth Natareno','','35891672','','/**/'),
('','','','','/**/'),
('María del Rosartio Ortiz Rosales','','48117364','','/**/'),
('Reginalda Rueda Florian','','55244412','','/**/'),
('Claudia Elizabet Flores Hernández','','56975230','','/**/'),
('Ofelia López Ventura','','42923734','','/**/'),
('Cristian Manuel Sánchez','','41780069','','/**/'),
('Carmen María Suchite','','51183066','','/**/'),
('Sabrina Siomara Raxón González','','34276693','','/**/'),
('Elsa Eugenia Yoc Xiquin','','55960893','','/**/');

/*QUINTO BACHILLERATO*/
insert into encargado(NombreCompletoE1, NombreCompletoE2, telefonoE1, telefonoE2, Direccion)
values
('Jaqueline Pamela','','57855344','','/**/'),
('Dora Luz Gálvez','','54803230','','/**/'),
('Nancy Maribel Díaz Rueda','Ana María Barrientos','50817240','33355710','/**/'),
('Ingrid Dinora Cifuentes Cruz','','35759655','','/**/'),
('Lesly Saydett Cano','','44589744','','/**/');



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


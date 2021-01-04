DROP TABLE IF EXISTS groups, faculty, subject, classroom, lecturer, shedule, shedule_time;

CREATE TABLE faculty (
	id_faculty bigint NOT NULL IDENTITY, 
	faculty_name varchar(50) NOT NULL UNIQUE,
	primary key (id_faculty)
);

CREATE TABLE groups (
	id_group bigint NOT NULL IDENTITY,
	group_name varchar(50) NOT NULL UNIQUE,
	course integer NOT NULL,
	faculty bigint FOREIGN KEY REFERENCES faculty (id_faculty),
	primary key (id_group)
);

CREATE TABLE subject (
	id_subject bigint NOT NULL IDENTITY,
	subject_name varchar(255) NOT NULL UNIQUE,
	primary key (id_subject)
);

CREATE TABLE classroom (
	id_classroom bigint NOT NULL IDENTITY,
	classroom_name varchar(20) NOT NULL UNIQUE,
	primary key (id_classroom)
);

CREATE TABLE lecturer (
	id_lecturer bigint NOT NULL IDENTITY,
	surname varchar(255) NOT NULL,
	name varchar(255) NOT NULL,
	middle_name varchar(255),
	primary key (id_lecturer)
);

CREATE TABLE shedule_time(
	id_shTime bigint NOT NULL IDENTITY,
	fk_group bigint FOREIGN KEY REFERENCES groups (id_group),
	day varchar(255) NOT NULL,
	task_number integer NOT NULL,
	fk_subject bigint FOREIGN KEY REFERENCES subject (id_subject),
	fk_classroom bigint FOREIGN KEY REFERENCES classroom (id_classroom),
	fk_lecturer bigint FOREIGN KEY REFERENCES lecturer (id_lecturer),
	primary key (id_shTime)
);

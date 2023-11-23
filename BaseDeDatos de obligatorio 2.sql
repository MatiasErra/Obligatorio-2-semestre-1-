
create database Municipalidad
use Municipalidad
create table Autores(
id integer primary key,
nombre varchar(50) ,
apellido varchar(50),
nacionalidad varchar(50),
fechaden varchar(50),
fechadef varchar(50),);

create table Lectores(
id integer primary key,
nombre varchar(50) ,
apellido varchar(50));

create table Pais(
id integer primary key,
nombre varchar(50));

create table Generos(
id integer primary key,
nombre varchar(50));




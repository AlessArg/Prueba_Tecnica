select TOP 1
C.Nombre from Categoria C
inner join Producto P on C.CodigoCategoria = P.CodigoCategoria
inner join Venta V on P.CodigoProducto = V.CodigoProducto
order by V.Fecha desc;

create table Categoria (
	CodigoCategoria int not null identity(1,1) primary key,
    Nombre varchar(50)
);

create table Producto (
	CodigoProducto int not null identity(1,1) primary key,
    Nombre varchar(50),
    CodigoCategoria int,
    foreign key (CodigoCategoria) references Categoria(CodigoCategoria)
);

create table Venta (
	CodigoVenta int not null identity(1,1) primary key,
	Fecha date,
    CodigoProducto int,
    foreign key (CodigoProducto) references Producto(CodigoProducto)
);

insert into Categoria (Nombre) values('Camisas');
insert into Producto (Nombre, CodigoCategoria) values ('Camisa Talla M',3);
insert into Venta (Fecha, CodigoProducto) values (CAST(GETDATE()AS DATE), 1);

select * from Categoria;
select * from Producto;
select * from Venta;

select C.Nombre from Categoria C
inner join Producto P on C.CodigoCategoria = P.CodigoCategoria
inner join Venta V on P.CodigoProducto = V.CodigoProducto
order by V.Fecha desc limit 1;
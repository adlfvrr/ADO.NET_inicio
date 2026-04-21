
--dropeamos las tablas si existen para poder crear nuevas
drop table if exists phones;
drop table if exists iphone;
drop table if exists samsung;

--creamos tablas
create table phones(
id_phone SERIAL,
id_type INT not null, --DISCRIMINADOR
stock INT default 0,
primary key(id_phone)
);

create table iphone(
id_phone SERIAL,
id_type INT not null ,
model VARCHAR(50),
price NUMERIC(18,2),
cond_bateria VARCHAR(50),
primary key(id_phone),
constraint fk_id_iphone 
foreign key (id_phone) references phones(id_phone) on delete cascade
);

create table samsung(
id_phone SERIAL,
id_type INT not null ,
model VARCHAR(50),
price NUMERIC(18,2),
serie VARCHAR(50),
primary key(id_phone),
constraint fk_id_samsung
foreign key(id_phone) references phones(id_phone) on delete cascade
);

--corroboramos la creacion de las tablas
select *
from phones;
select *
from iphone;
select *
from samsung;
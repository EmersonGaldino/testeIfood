
--Criar a tabela de produto
create table Product(
    Id integer  primary key,
    Description varchar(250) not null,
    Value decimal not null,
    DateCreate timestamp,
    DateAlter timestamp,
    Active bool
);
--Criar sequence
create sequence product_id_seq;

alter table product alter column id set default nextval('testinggaldino.product_id_seq');

alter sequence product_id_seq owned by product.id;

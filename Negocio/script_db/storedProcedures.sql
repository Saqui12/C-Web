USE [CATALOGO_WEB_DB]
GO
/****** Object:  StoredProcedure [dbo].[insertarNuevo]    Script Date: 4/4/2025 15:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[insertarNuevo]
@email varchar(50),
@pass varchar(50)
as
insert into USERS (email, pass, admin) output inserted.id values (@email, @pass, 0)
GO
/****** Object:  StoredProcedure [dbo].[storedAltaArticulo]    Script Date: 4/4/2025 15:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[storedAltaArticulo]
@codigo varchar(50),
@nombre varchar(50),
@descripcion varchar(150),
@idMarca int,
@idCategoria int,
@imagenUrl varchar(100),
@precio money
as
insert into ARTICULOS values (@codigo,@nombre,@descripcion,@idMarca ,@idCategoria,@imagenUrl,@precio)
GO
/****** Object:  StoredProcedure [dbo].[storedListar]    Script Date: 4/4/2025 15:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[storedListar] as
select ARTICULOS.Id, Codigo, Nombre ,ARTICULOS.Descripcion,M.Descripcion Marca,C.Descripcion Categoria, IdMarca, IdCategoria, ImagenUrl , Precio 
from ARTICULOS, MARCAS M , CATEGORIAS C 
WHERE M.Id =ARTICULOS.IdMarca AND ARTICULOS.IdCategoria=C.Id
GO
/****** Object:  StoredProcedure [dbo].[storedModificarArticulo]    Script Date: 4/4/2025 15:56:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[storedModificarArticulo]
@codigo varchar(50),
@nombre varchar(50),
@desc varchar(150),
@img varchar (1000),
@idMarca int,
@idCategoria int,
@id int,
@precio money
as
update ARTICULOS set codigo = @codigo, Nombre = @nombre, Descripcion = @desc, 
ImagenUrl = @img, IdMarca= @idMarca, IdCategoria = @idCategoria , @precio=precio
Where Id = @id
GO

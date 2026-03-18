-- Crear tabla y procedimientos almacenados para Productos en SQL Server
IF OBJECT_ID('dbo.Productos', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Productos (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Precio DECIMAL(18,2) NOT NULL
    );
END
GO

IF OBJECT_ID('dbo.sp_GetProductos', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_GetProductos;
GO
CREATE PROCEDURE dbo.sp_GetProductos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Nombre, Precio FROM dbo.Productos ORDER BY Id DESC;
END
GO

IF OBJECT_ID('dbo.sp_GetProductoById', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_GetProductoById;
GO
CREATE PROCEDURE dbo.sp_GetProductoById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Nombre, Precio FROM dbo.Productos WHERE Id = @Id;
END
GO

IF OBJECT_ID('dbo.sp_InsertProducto', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_InsertProducto;
GO
CREATE PROCEDURE dbo.sp_InsertProducto
    @Nombre NVARCHAR(100),
    @Precio DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Productos (Nombre, Precio) VALUES (@Nombre, @Precio);
END
GO

IF OBJECT_ID('dbo.sp_UpdateProducto', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_UpdateProducto;
GO
CREATE PROCEDURE dbo.sp_UpdateProducto
    @Id INT,
    @Nombre NVARCHAR(100),
    @Precio DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Productos SET Nombre=@Nombre, Precio=@Precio WHERE Id=@Id;
END
GO

IF OBJECT_ID('dbo.sp_DeleteProducto', 'P') IS NOT NULL DROP PROCEDURE dbo.sp_DeleteProducto;
GO
CREATE PROCEDURE dbo.sp_DeleteProducto
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM dbo.Productos WHERE Id=@Id;
END
GO

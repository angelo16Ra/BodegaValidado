USE [BodegaYaninAlmacen]
GO

/****** Object:  View [dbo].[VPedido]    Script Date: 27/8/2024 18:15:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[VPedido]
AS
    SELECT 
        T1.CodigoPedido, T1.CodigoUsuario, T1.CodigoProducto,T1.CodigoDetallePedido, T1.MontoTotalPedido, 
		T1.MontoPagado, T1.Vuelto, T1.RegistroPedido, T1.EntregaPedido,
        T2.UserName AS nombreUsuario,  
        T3.Nombre AS nombreProducto, 
        T4.Cantidad, 
        T4.PrecioTotal, 
        T4.PrecioUnitario
    FROM
        Pedidos T1
        INNER JOIN Usuarios T2
            ON T1.CodigoUsuario = T2.CodigoUsuario
        INNER JOIN Productos T3
            ON T1.CodigoProducto = T3.CodigoProducto
        INNER JOIN DetallePedidos T4
            ON T1.CodigoDetallePedido = T4.CodigoDetallePedido;

GO

select * from Pedidos
-- Aquí no va CodigoProducto, CodigoDetallePedido
select * from DetallePedidos
-- Aquí agregar CodigoProducto, CodigoPedido (llave foranea de la tabla Pedidos)

-- Lo que pasa es que así como está, no me permite diferenciar los pedidos con los detalles, y se va mostrar mal
-- Salvo que funciones para un solo producto, ahí no va salir error
-- Pero si quieres agregar varios productos al pedido, no va aguantar

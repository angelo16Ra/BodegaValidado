using AutoMapper;
using DBBodegaYani.BodegaYani;
using RequestResponseModels.Generic;
using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Response.Almacen;

namespace Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            // CreateMap para Almacenes
            CreateMap<Almacene, RequestAlmacene>().ReverseMap();
            CreateMap<Almacene, ResponseAlmacene>().ReverseMap();
            CreateMap<ResponseAlmacene, RequestAlmacene>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseAlmacene>, ResponseFilterGeneric<Almacene>>().ReverseMap();

            // CreateMap para Caja
            CreateMap<Caja, RequestCaja>().ReverseMap();
            CreateMap<Caja, ResponseCaja>().ReverseMap();
            CreateMap<ResponseCaja, RequestCaja>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseCaja>, ResponseFilterGeneric<Caja>>().ReverseMap();

            // CreateMap para Categoria
            CreateMap<Categoria, RequestCategoria>().ReverseMap();
            CreateMap<Categoria, ResponseCategoria>().ReverseMap();
            CreateMap<ResponseCategoria, RequestCategoria>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseCategoria>, ResponseFilterGeneric<Categoria>>().ReverseMap();

            // CreateMap para DetallePedido
            CreateMap<DetallePedido, RequestDetallePedido>().ReverseMap();
            CreateMap<DetallePedido, ResponseDetallePedido>().ReverseMap();
            CreateMap<ResponseDetallePedido, RequestDetallePedido>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseDetallePedido>, ResponseFilterGeneric<DetallePedido>>().ReverseMap();

            // CreateMap para MovimientoCaja
            CreateMap<MovimientoCaja, RequestMovimientoCaja>().ReverseMap();
            CreateMap<MovimientoCaja, ResponseMovimientoCaja>().ReverseMap();
            CreateMap<ResponseMovimientoCaja, RequestMovimientoCaja>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseMovimientoCaja>, ResponseFilterGeneric<MovimientoCaja>>().ReverseMap();

            // CreateMap para Pedido
            CreateMap<Pedido, RequestPedido>().ReverseMap();
            CreateMap<Pedido, ResponsePedido>().ReverseMap();
            CreateMap<ResponsePedido, RequestPedido>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponsePedido>, ResponseFilterGeneric<Pedido>>().ReverseMap();

            // CreateMap para Persona
            CreateMap<Persona, RequestPersona>().ReverseMap();
            CreateMap<Persona, ResponsePersona>().ReverseMap();
            CreateMap<ResponsePersona, RequestPersona>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponsePersona>, ResponseFilterGeneric<Persona>>().ReverseMap();

            // CreateMap para Producto
            CreateMap<Producto, RequestProducto>().ReverseMap();
            CreateMap<Producto, ResponseProducto>().ReverseMap();
            CreateMap<ResponseProducto, RequestProducto>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseProducto>, ResponseFilterGeneric<Producto>>().ReverseMap();

            // CreateMap para Proveedor
            CreateMap<Proveedore, RequestProveedor>().ReverseMap();
            CreateMap<Proveedore, ResponseProveedor>().ReverseMap();
            CreateMap<ResponseProveedor, RequestProveedor>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseProveedor>, ResponseFilterGeneric<Proveedore>>().ReverseMap();

            // CreateMap para Rol
            CreateMap<Rol, RequestRol>().ReverseMap();
            CreateMap<Rol, ResponseRol>().ReverseMap();
            CreateMap<ResponseRol, RequestRol>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseRol>, ResponseFilterGeneric<Rol>>().ReverseMap();

            // CreateMap para SubCategoria
            CreateMap<SubCategoria, RequestSubCategoria>().ReverseMap();
            CreateMap<SubCategoria, ResponseSubCategoria>().ReverseMap();
            CreateMap<ResponseSubCategoria, RequestSubCategoria>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseSubCategoria>, ResponseFilterGeneric<SubCategoria>>().ReverseMap();

            // CreateMap para TipoDocumento
            CreateMap<TipoDocumento, RequestTipoDocumento>().ReverseMap();
            CreateMap<TipoDocumento, ResponseTipoDocumento>().ReverseMap();
            CreateMap<ResponseTipoDocumento, RequestTipoDocumento>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseTipoDocumento>, ResponseFilterGeneric<TipoDocumento>>().ReverseMap();

            // CreateMap para UnidadMedida
            CreateMap<UnidadMedida, RequestUnidadMedida>().ReverseMap();
            CreateMap<UnidadMedida, ResponseUnidadMedida>().ReverseMap();
            CreateMap<ResponseUnidadMedida, RequestUnidadMedida>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseUnidadMedida>, ResponseFilterGeneric<UnidadMedida>>().ReverseMap();

            // CreateMap para Usuario
            CreateMap<Usuario, RequestUsuario>().ReverseMap();
            CreateMap<Usuario, ResponseUsuario>().ReverseMap();
            CreateMap<ResponseUsuario, RequestUsuario>().ReverseMap();
            CreateMap<ResponseFilterGeneric<ResponseUsuario>, ResponseFilterGeneric<Usuario>>().ReverseMap();

        }
    }
}

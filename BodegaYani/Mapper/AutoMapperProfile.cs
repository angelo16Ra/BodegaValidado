using AutoMapper;
using DBBodegaYani.BodegaYani;
using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Response.Almacen;

namespace Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Almacene, RequestAlmacene>().ReverseMap();
            CreateMap<Almacene, ResponseAlmacene>().ReverseMap();
            CreateMap<ResponseAlmacene, RequestAlmacene>().ReverseMap();
            //CreateMap<GenericFilterResponse<UsuarioResponse>, GenericFilterResponse<Usuario>>().ReverseMap();

            CreateMap<Caja, RequestCaja>().ReverseMap();
            CreateMap<Caja, ResponseCaja>().ReverseMap();


            CreateMap<Caja, RequestCaja>().ReverseMap();
            CreateMap<Caja, ResponseCaja>().ReverseMap();


            CreateMap<DetallePedido, RequestDetallePedido>().ReverseMap();
            CreateMap<DetallePedido, ResponseDetallePedido>().ReverseMap();


            CreateMap<MovimientoCaja, RequestMovimientoCaja>().ReverseMap();
            CreateMap<MovimientoCaja, ResponseMovimientoCaja>().ReverseMap();


            CreateMap<Pedido, RequestPedido>().ReverseMap();
            CreateMap<Pedido, ResponsePedido>().ReverseMap();


            CreateMap<Persona, RequestPersona>().ReverseMap();
            CreateMap<Persona, ResponsePersona>().ReverseMap();


            CreateMap<Producto, RequestProducto>().ReverseMap();
            CreateMap<Producto, ResponseProducto>().ReverseMap();



            CreateMap<Proveedore, RequestProveedor>().ReverseMap();
            CreateMap<Proveedore, ResponseProveedor>().ReverseMap();


            CreateMap<Rol, RequestRol>().ReverseMap();
            CreateMap<Rol, ResponseRol>().ReverseMap();


            CreateMap<TipoDocumento, RequestTipoDocumento>().ReverseMap();
            CreateMap<TipoDocumento, ResponseTipoDocumento>().ReverseMap();


            CreateMap<UnidadMedida, RequestUnidadMedida>().ReverseMap();
            CreateMap<UnidadMedida, ResponseUnidadMedida>().ReverseMap();


            CreateMap<Usuario, RequestUsuario>().ReverseMap();
            CreateMap<Usuario, ResponseUsuario>().ReverseMap();
            CreateMap<ResponseUsuario, RequestUsuario>().ReverseMap();
        }
    }
}

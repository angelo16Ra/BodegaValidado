using AutoMapper;
using DBBodegaYani.BodegaYani;
using IBusiness.Almacen;
using IRepository.Almacen;
using Repository.Almacen;
using RequestResponseModels.Generic;
using RequestResponseModels.Request.Almacen;
using RequestResponseModels.Response.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Almacen
{
    public class BusinessMovimientoCaja : IBusinessMovimientoCaja
    {
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE
        private readonly IRepositoryMovimientoCaja _movimientoCajaRepository;
        private readonly IMapper _mapper;

        public BusinessMovimientoCaja(IMapper mapper)
        {
            _mapper = mapper;
            _movimientoCajaRepository = new RepositoryMovimientoCaja();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR / DISPOSE

        #region CRUD METHODS

        public List<ResponseMovimientoCaja> GetAll()
        {
            List<MovimientoCaja> movimientosCaja = _movimientoCajaRepository.GetAll();
            List<ResponseMovimientoCaja> result = _mapper.Map<List<ResponseMovimientoCaja>>(movimientosCaja);
            return result;
        }

        public ResponseMovimientoCaja GetById(object id)
        {
            MovimientoCaja movimientoCaja = _movimientoCajaRepository.GetById(id);
            ResponseMovimientoCaja result = _mapper.Map<ResponseMovimientoCaja>(movimientoCaja);
            return result;
        }

        public ResponseMovimientoCaja Create(RequestMovimientoCaja entity)
        {
            MovimientoCaja movimientoCaja = _mapper.Map<MovimientoCaja>(entity);
            movimientoCaja = _movimientoCajaRepository.Create(movimientoCaja);
            ResponseMovimientoCaja result = _mapper.Map<ResponseMovimientoCaja>(movimientoCaja);
            return result;
        }

        public List<ResponseMovimientoCaja> CreateMultiple(List<RequestMovimientoCaja> lista)
        {
            List<MovimientoCaja> movimientosCaja = _mapper.Map<List<MovimientoCaja>>(lista);
            movimientosCaja = _movimientoCajaRepository.CreateMultiple(movimientosCaja);
            List<ResponseMovimientoCaja> result = _mapper.Map<List<ResponseMovimientoCaja>>(movimientosCaja);
            return result;
        }

        public ResponseMovimientoCaja Update(RequestMovimientoCaja entity)
        {
            MovimientoCaja movimientoCaja = _mapper.Map<MovimientoCaja>(entity);
            movimientoCaja = _movimientoCajaRepository.Update(movimientoCaja);
            ResponseMovimientoCaja result = _mapper.Map<ResponseMovimientoCaja>(movimientoCaja);
            return result;
        }

        public List<ResponseMovimientoCaja> UpdateMultiple(List<RequestMovimientoCaja> lista)
        {
            List<MovimientoCaja> movimientosCaja = _mapper.Map<List<MovimientoCaja>>(lista);
            movimientosCaja = _movimientoCajaRepository.UpdateMultiple(movimientosCaja);
            List<ResponseMovimientoCaja> response = _mapper.Map<List<ResponseMovimientoCaja>>(movimientosCaja);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _movimientoCajaRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestMovimientoCaja> lista)
        {
            List<MovimientoCaja> movimientosCaja = _mapper.Map<List<MovimientoCaja>>(lista);
            int cantidad = _movimientoCajaRepository.DeleteMultiple(movimientosCaja);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseMovimientoCaja> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseMovimientoCaja> result = _mapper.Map<ResponseFilterGeneric<ResponseMovimientoCaja>>(_movimientoCajaRepository.GetByFilter(request));
            return result;
        }

        public ResponseFilterGeneric<VmovimientoCaja> GetByFilterView(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<VmovimientoCaja> result = _mapper.Map<ResponseFilterGeneric<VmovimientoCaja>>(_movimientoCajaRepository.GetByFilterView(request));
            return result;
        }

        #endregion CRUD METHODS

    }

}

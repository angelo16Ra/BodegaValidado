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
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
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
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseMovimientoCaja Create(RequestMovimientoCaja entity)
        {
            MovimientoCaja movimientoCajaEntity = _mapper.Map<MovimientoCaja>(entity);
            MovimientoCaja createdMovimientoCaja = _movimientoCajaRepository.Create(movimientoCajaEntity);
            return _mapper.Map<ResponseMovimientoCaja>(createdMovimientoCaja);
        }

        public List<ResponseMovimientoCaja> CreateMultiple(List<RequestMovimientoCaja> list)
        {
            List<MovimientoCaja> movimientoCajaEntities = _mapper.Map<List<MovimientoCaja>>(list);
            List<MovimientoCaja> createdMovimientoCajas = _movimientoCajaRepository.CreateMultiple(movimientoCajaEntities);
            return _mapper.Map<List<ResponseMovimientoCaja>>(createdMovimientoCajas);
        }

        public int Delete(object id)
        {
            return _movimientoCajaRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestMovimientoCaja> list)
        {
            List<MovimientoCaja> movimientoCajaEntities = _mapper.Map<List<MovimientoCaja>>(list);
            return _movimientoCajaRepository.DeleteMultiple(movimientoCajaEntities);
        }

        public List<ResponseMovimientoCaja> GetAll()
        {
            List<MovimientoCaja> movimientoCajas = _movimientoCajaRepository.GetAll();
            return _mapper.Map<List<ResponseMovimientoCaja>>(movimientoCajas);
        }

        public ResponseFilterGeneric<ResponseMovimientoCaja> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseMovimientoCaja GetById(object id)
        {
            MovimientoCaja movimientoCajaEntity = _movimientoCajaRepository.GetById(id);
            return _mapper.Map<ResponseMovimientoCaja>(movimientoCajaEntity);
        }

        public ResponseMovimientoCaja Update(RequestMovimientoCaja entity)
        {
            MovimientoCaja movimientoCajaEntity = _mapper.Map<MovimientoCaja>(entity);
            MovimientoCaja updatedMovimientoCaja = _movimientoCajaRepository.Update(movimientoCajaEntity);
            return _mapper.Map<ResponseMovimientoCaja>(updatedMovimientoCaja);
        }

        public List<ResponseMovimientoCaja> UpdateMultiple(List<RequestMovimientoCaja> list)
        {
            List<MovimientoCaja> movimientoCajaEntities = _mapper.Map<List<MovimientoCaja>>(list);
            List<MovimientoCaja> updatedMovimientoCajas = _movimientoCajaRepository.UpdateMultiple(movimientoCajaEntities);
            return _mapper.Map<List<ResponseMovimientoCaja>>(updatedMovimientoCajas);
        }
        #endregion CRUD METHODS
    }

}

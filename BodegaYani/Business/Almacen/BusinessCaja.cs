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
    public class BusinessCaja : IBusinessCaja
    {
        #region DECLARAR VARIABLE CONSTRUCTORES / DISPOSE
        private readonly IRepositoryCaja _cajaRepository;
        private readonly IMapper _mapper;

        public BusinessCaja(IMapper mapper)
        {
            _mapper = mapper;
            _cajaRepository = new RepositoryCaja();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion DECLARAR VARIABLE CONSTRUCTORES / DISPOSE

        #region CRUD METHODS
        public ResponseCaja Create(RequestCaja entity)
        {
            Caja cajaEntity = _mapper.Map<Caja>(entity);
            Caja createdCaja = _cajaRepository.Create(cajaEntity);
            return _mapper.Map<ResponseCaja>(createdCaja);
        }

        public List<ResponseCaja> CreateMultiple(List<RequestCaja> list)
        {
            List<Caja> cajaEntities = _mapper.Map<List<Caja>>(list);
            List<Caja> createdCajas = _cajaRepository.CreateMultiple(cajaEntities);
            return _mapper.Map<List<ResponseCaja>>(createdCajas);
        }

        public int Delete(object id)
        {
            return _cajaRepository.Delete(id);
        }

        public int DeleteMultiple(List<RequestCaja> list)
        {
            List<Caja> cajaEntities = _mapper.Map<List<Caja>>(list);
            return _cajaRepository.DeleteMultiple(cajaEntities);
        }
        
        public List<ResponseCaja> GetAll()
        {
            List<Caja> cajas = _cajaRepository.GetAll();
            return _mapper.Map<List<ResponseCaja>>(cajas);
        }

        public ResponseFilterGeneric<ResponseCaja> GetByFilter(RequestFilterGeneric request)
        {
            throw new NotImplementedException();
        }

        public ResponseCaja GetById(object id)
        {
            Caja cajaEntity = _cajaRepository.GetById(id);
            return _mapper.Map<ResponseCaja>(cajaEntity);
        }

        public ResponseCaja Update(RequestCaja entity)
        {
            Caja cajaEntity = _mapper.Map<Caja>(entity);
            Caja updatedCaja = _cajaRepository.Update(cajaEntity);
            return _mapper.Map<ResponseCaja>(updatedCaja);
        }

        public List<ResponseCaja> UpdateMultiple(List<RequestCaja> list)
        {
            List<Caja> cajaEntities = _mapper.Map<List<Caja>>(list);
            List<Caja> updatedCajas = _cajaRepository.UpdateMultiple(cajaEntities);
            return _mapper.Map<List<ResponseCaja>>(updatedCajas);
        }
        #endregion CRUD METHODS
    }

}

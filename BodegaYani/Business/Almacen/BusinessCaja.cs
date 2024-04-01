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

        public List<ResponseCaja> GetAll()
        {
            List<Caja> cajas = _cajaRepository.GetAll();
            List<ResponseCaja> result = _mapper.Map<List<ResponseCaja>>(cajas);
            return result;
        }

        public ResponseCaja GetById(object id)
        {
            Caja caja = _cajaRepository.GetById(id);
            ResponseCaja result = _mapper.Map<ResponseCaja>(caja);
            return result;
        }

        public ResponseCaja Create(RequestCaja entity)
        {
            Caja caja = _mapper.Map<Caja>(entity);
            caja = _cajaRepository.Create(caja);
            ResponseCaja result = _mapper.Map<ResponseCaja>(caja);
            return result;
        }

        public List<ResponseCaja> CreateMultiple(List<RequestCaja> lista)
        {
            List<Caja> cajas = _mapper.Map<List<Caja>>(lista);
            cajas = _cajaRepository.CreateMultiple(cajas);
            List<ResponseCaja> result = _mapper.Map<List<ResponseCaja>>(cajas);
            return result;
        }

        public ResponseCaja Update(RequestCaja entity)
        {
            Caja caja = _mapper.Map<Caja>(entity);
            caja = _cajaRepository.Update(caja);
            ResponseCaja result = _mapper.Map<ResponseCaja>(caja);
            return result;
        }

        public List<ResponseCaja> UpdateMultiple(List<RequestCaja> lista)
        {
            List<Caja> cajas = _mapper.Map<List<Caja>>(lista);
            cajas = _cajaRepository.UpdateMultiple(cajas);
            List<ResponseCaja> response = _mapper.Map<List<ResponseCaja>>(cajas);
            return response;
        }

        public int Delete(object id)
        {
            int cantidad = _cajaRepository.Delete(id);
            return cantidad;
        }

        public int DeleteMultiple(List<RequestCaja> lista)
        {
            List<Caja> cajas = _mapper.Map<List<Caja>>(lista);
            int cantidad = _cajaRepository.DeleteMultiple(cajas);
            return cantidad;
        }

        public ResponseFilterGeneric<ResponseCaja> GetByFilter(RequestFilterGeneric request)
        {
            ResponseFilterGeneric<ResponseCaja> result = _mapper.Map<ResponseFilterGeneric<ResponseCaja>>(_cajaRepository.GetByFilter(request));
            return result;
        }

        #endregion CRUD METHODS

    }

}

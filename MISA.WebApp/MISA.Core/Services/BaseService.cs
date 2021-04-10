﻿using MISA.Core.Entities;
using MISA.Core.Enums;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {
        #region Declare
        IBaseRepository<T> _baseRepository;
        protected ServiceResult _serviceResult;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Method
        public ServiceResult Add(T t)
        {
            // validate trùng mã và dữ liệu bắt buộc nhập
            var isValid = Validate(t);

            if(isValid == true)
            {
                _serviceResult.devMsg = Resouces.Message.AddSuccess;
                _serviceResult.userMsg = Resouces.Message.AddSuccess;
                _serviceResult.Data = _baseRepository.Add(t);
                _serviceResult.MisaCode = MISACode.ISVALID;
            }

            else
            {
                _serviceResult.userMsg = Resouces.Message.AddError;
                _serviceResult.MisaCode = MISACode.NOTVALID;
            }
            return _serviceResult;
        }

        public ServiceResult Delete(Guid id)
        {
            var result = _baseRepository.Delete(id);
            if(result == 0)
            {
                _serviceResult.MisaCode = MISACode.NOTVALID;
                _serviceResult.userMsg = Resouces.Message.DeleteError;
            }
            else
            {
                _serviceResult.devMsg = Resouces.Message.DeleteSuccess;
                _serviceResult.userMsg = Resouces.Message.DeleteSuccess;
                _serviceResult.MisaCode = MISACode.SUCCESS;
                _serviceResult.Data = result;
            }

            return _serviceResult;
        }

        public IEnumerable<T> Get()
        {
            return _baseRepository.Get();
        }

        public T GetById(Guid id)
        {
            return _baseRepository.GetById(id);
        }

        public ServiceResult Update(T t, Guid id)
        {
            throw new NotImplementedException();
        }

        private bool BaseValidate(T entity)
        {
            var isValid = true;
            // Đọc các Properties 
            // GetType() -> trả về kiểu của entity
            // GetProperties() -> trả về các public properties (CustomerId là 1 properties)
            var properties = entity.GetType().GetProperties();

            foreach(var property in properties)
            {
                // Kiểm tra các Atribute của property
                if (property.IsDefined(typeof(Required), false))
                {
                    // Check bắt buộc nhập
                    var propertyValue = property.GetValue(entity);
                    if(propertyValue == null)
                    {
                        isValid = false;
                    }

                    // Check duplicate
                    
                }
            }



            return isValid;
        }

        /// <summary>
        /// Hàm validate dữ liệu
        /// </summary>
        /// <param name="t">Đối tượng cần validate</param>
        /// <returns></returns>
        public virtual bool Validate(T t)
        {
            return true;
        }
        #endregion
    }
}

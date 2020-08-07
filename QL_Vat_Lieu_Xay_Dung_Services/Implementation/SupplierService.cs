﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.Product;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services.Implementation
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Supplier, int> _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(IMapper mapper, IRepository<Supplier, int> supplierRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
            _unitOfWork = unitOfWork;
        }

        public List<SupplierViewModel> GetAll()
        {
            return _mapper.ProjectTo<SupplierViewModel>(_supplierRepository.FindAll()).ToList();
        }

        public GenericResult Add(SupplierViewModel supplierViewModel)
        {
            try
            {
                _supplierRepository.Add(_mapper.Map<SupplierViewModel, Supplier>(supplierViewModel));

                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Update(SupplierViewModel supplierViewModel)
        {
            try
            {
                _supplierRepository.Update(_mapper.Map<SupplierViewModel, Supplier>(supplierViewModel));
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }

        public GenericResult Delete(int id)
        {
            try
            {
                _supplierRepository.Remove(id);
                return new GenericResult(true, "Delete Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Delete Failed", "Error");
            }
        }

        public SupplierViewModel GetById(int id)
        {
            return _mapper.Map<Supplier, SupplierViewModel>(_supplierRepository.FindById(id));
        }

        public PagedResult<SupplierViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _supplierRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.FullName.Contains(keyword));
            }

            var totalRow = query.Count();
            query = query.OrderBy(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);
            var data = _mapper.ProjectTo<SupplierViewModel>(query).ToList();
            var paginationSet = new PagedResult<SupplierViewModel>()
            {
                ResultList = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
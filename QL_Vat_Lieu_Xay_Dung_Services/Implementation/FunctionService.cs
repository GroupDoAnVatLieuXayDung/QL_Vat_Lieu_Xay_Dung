using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QL_Vat_Lieu_Xay_Dung_Data.Entities;
using QL_Vat_Lieu_Xay_Dung_Data.Enums;
using QL_Vat_Lieu_Xay_Dung_Infrastructure.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.Interfaces;
using QL_Vat_Lieu_Xay_Dung_Services.ViewModels.System;
using QL_Vat_Lieu_Xay_Dung_Utilities.Dtos;

namespace QL_Vat_Lieu_Xay_Dung_Services
{
    public class FunctionService : IFunctionService
    {
        private readonly IRepository<Function, string> _functionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FunctionService(IRepository<Function, string> functionRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _functionRepository = functionRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public bool CheckExistedId(string id)
        {
            return _functionRepository.FindById(id) != null;
        }

        public GenericResult Add(FunctionViewModel functionViewModel)
        {
            try
            {
                var function = _mapper.Map<Function>(functionViewModel);
                _functionRepository.Add(function);
                return new GenericResult(true, "Add Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Add Failed", "Error");
            }
        }

        public GenericResult Delete(string id)
        {
            try
            {
                _functionRepository.Remove(id);
                return new GenericResult(true, "Delete Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Delete Failed", "Error");
            }
        }

        public FunctionViewModel GetById(string id)
        {
            var function = _functionRepository.FindSingle(x => x.Id == id);
            return _mapper.Map<Function, FunctionViewModel>(function);
        }
        public IQueryable<FunctionViewModel> GetAllWithParentId(string parentId)
        {
            return _mapper.ProjectTo<FunctionViewModel>(
                _functionRepository.FindAll(x => x.ParentId == parentId));
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public GenericResult Update(FunctionViewModel functionViewModel)
        {
            try
            {
                var function = _mapper.Map<FunctionViewModel, Function>(functionViewModel);
                _functionRepository.Update(function);
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }

        public GenericResult ReOrder(string sourceId, string targetId)
        {
            try
            {
                var source = _functionRepository.FindById(sourceId);
                var target = _functionRepository.FindById(targetId);

                var tempOrder = source.SortOrder;
                source.SortOrder = target.SortOrder;
                target.SortOrder = tempOrder;

                _functionRepository.Update(source);
                _functionRepository.Update(target);
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }

        public GenericResult UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items)
        {
            try
            {
                //Update parent id for source
                var category = _functionRepository.FindById(sourceId);
                category.ParentId = targetId;
                _functionRepository.Update(category);

                //Get all sibling
                var sibling = _functionRepository.FindAll(x => items.ContainsKey(x.Id));
                foreach (var child in sibling)
                {
                    child.SortOrder = items[child.Id];
                    _functionRepository.Update(child);
                }
                return new GenericResult(true, "Update Successful", "Successful");
            }
            catch (Exception)
            {
                return new GenericResult(false, "Update Failed", "Error");
            }
        }

        public Task<List<FunctionViewModel>> GetAll()
        {
            var query = _mapper.ProjectTo<FunctionViewModel>(_functionRepository.FindAll(x => x.Status == Status.Active));
            //if (!string.IsNullOrEmpty(filter))
            //     query = query.Where(x => x.ParentId.Contains(filter) && x.Id.Contains(filter));

            return query.OrderBy(x => x.SortOrder).ToListAsync();
        }


        //Hàm mới ở đây
        public List<FunctionViewModel> GetAll_List()
        {
            var query = _mapper.ProjectTo<FunctionViewModel>(_functionRepository.FindAll(x => x.Status == Status.Active));
            //if (!string.IsNullOrEmpty(filter))
            //     query = query.Where(x => x.ParentId.Contains(filter) && x.Id.Contains(filter));

            return query.OrderBy(x => x.SortOrder).ToList();
        }
    }
}

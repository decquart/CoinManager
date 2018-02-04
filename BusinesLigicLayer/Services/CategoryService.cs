using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessLogicLayer.Infrastructure;


namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategoryService
    {

        private IUnitOfWork db;
        private IMapper mapper;

        public CategoryService(IUnitOfWork uow, IMapper _mapper)
        {
            db = uow;
            mapper = _mapper;
        }
        
        //create       
        public void CreateExpenseCategory(string name)
        {
            var expCat = new ExpenseCategory { Name = name };
            db.ExpenseCategories.Create(expCat);
            db.Save();

        }

        public void CreateIncomeCategory(string name)
        {
            var incCat = new IncomeCategory{ Name = name };
            db.IncomeCategories.Create(incCat);
            db.Save();
        }

       
        //read
        public IEnumerable<ExpenseCategoryDTO> GetAllExpensesCategories()
        {
            return mapper.Map<IEnumerable<ExpenseCategory>, List<ExpenseCategoryDTO>>(db
                .ExpenseCategories.GetAll());
        }

        public IEnumerable<IncomeCategoryDTO> GetAllIncomesCategories()
        {
            return mapper.Map<IEnumerable<IncomeCategory>, List<IncomeCategoryDTO>>(db
                .IncomeCategories.GetAll());
        }

        //delete
        public void RemoveExpenseCategory(int categoryId)
        {
            var cat = db.ExpenseCategories.Get(categoryId);
            if (cat == null)
                throw new ValidationException("Expense category not found");

            db.ExpenseCategories.Delete(categoryId);
            db.Save();                
        }

        public void RemoveIncomeCategory(int categoryId)
        {
            var cat = db.IncomeCategories.Get(categoryId);
            if (cat == null)
                throw new ValidationException("Income category not found");

            db.IncomeCategories.Delete(categoryId);
            db.Save();
        }

        // update
        public void ChangeExpenseCategoryName(int catId, string name)
        {
            var expCat = db.ExpenseCategories.Get(catId);

            if (expCat == null)
                throw new ValidationException("Expense category not found");
            expCat.Name = name;
            db.ExpenseCategories.Update(expCat);
            db.Save();
        }

        public void ChangeIncomeCategoryName(int catId, string name)
        {
            var incCat = db.IncomeCategories.Get(catId);

            if (incCat == null)
                throw new ValidationException("Income category not found");

            incCat.Name = name;
            db.IncomeCategories.Update(incCat);
            db.Save();
        }


        public void Dispose()
        {
            db.Dispose();
        }

    }
}

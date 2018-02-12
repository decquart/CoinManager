using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.DTO;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICategoryService
    {
        //create
        void CreateIncomeCategory(IncomeCategoryDTO incomeCategory);
        void CreateExpenseCategory(ExpenseCategoryDTO expenseCategory);

        //read
        IEnumerable<ExpenseCategoryDTO> GetAllExpensesCategories();
        IEnumerable<IncomeCategoryDTO> GetAllIncomesCategories();

        //update
        void ChangeIncomeCategoryName(int catId, string name);
        void ChangeExpenseCategoryName(int catId, string name);

        //delete
        void RemoveIncomeCategory(int categoryId);
        void RemoveExpenseCategory(int categoryId);

        void Dispose();
    }
}

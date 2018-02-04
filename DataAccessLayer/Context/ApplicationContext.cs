using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using System;



namespace DataAccessLayer.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        static ApplicationContext()
        {
            Database.SetInitializer<ApplicationContext>(new WalletDbInitializer());
        }
        public ApplicationContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class WalletDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            
            db.Wallets.Add(new Wallet { Name = "Cash", Balance = 0 });
            
            //category  initialisation
            db.ExpenseCategories.Add(new ExpenseCategory { Name = "Food" });
            db.ExpenseCategories.Add(new ExpenseCategory { Name = "Leisure" });
            db.ExpenseCategories.Add(new ExpenseCategory { Name = "Health" });
            db.ExpenseCategories.Add(new ExpenseCategory { Name = "Transport" });
            db.ExpenseCategories.Add(new ExpenseCategory { Name = "Gifts" });
            db.ExpenseCategories.Add(new ExpenseCategory { Name = "Clothes" });
            db.ExpenseCategories.Add(new ExpenseCategory { Name = "Shopping" });

            db.IncomeCategories.Add(new IncomeCategory { Name = "Salary" });
            db.IncomeCategories.Add(new IncomeCategory { Name = "Additional income" });

            db.Expenses.Add(new Expense { Sum = 50, Comment = "this is test comment", OperationTime = DateTime.Now, ExpenseCategoryID = 1 });

            db.SaveChanges();
        }
    }
}

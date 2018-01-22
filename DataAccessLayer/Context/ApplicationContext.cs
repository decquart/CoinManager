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
            //db.ExpenseCategories.Add(new ExpenseCategory { Id = 1, Name = "Food"});
            //db.IncomeCategories.Add(new IncomeCategory { Id = 1, Name = "Salary" });
            //db.Incomes.Add(new Income {Id = 1, Sum = 100, category = db.IncomeCategories.Find(1), Comment = "Sale", OperationTime = DateTime.Now } );
            //db.Expenses.Add(new Expense { Id = 1, Sum = 200, category = db.ExpenseCategories.Find(1), Comment = "some food", OperationTime = DateTime.Now});
            db.Wallets.Add(new Wallet { Id = 1, Name = "Main Wallet", Balance = 0 });
            //var exp = db.Expenses.Find(1);
            //var inc = db.Incomes.Find(1);
            //db.Wallets.Find(1).Expenses.Add(exp);
            //db.Wallets.Find(1).Incomes.Add(inc);
            db.SaveChanges();
        }
    }
}

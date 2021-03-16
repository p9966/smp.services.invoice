/**********************************************************************
* FileName :      InvoiceDbContext
* Tables :        none
* Author :        韩超(Simple)
* CreateTime :    2021/3/9 11:38:57
* Description :   
* 
* Revision History
* Author           ModifyTime          Description
* 
**********************************************************************/


using smp.services.invoice.core.Invoice.Entities;
using Microsoft.EntityFrameworkCore;

namespace smp.services.invoice.core
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {

        }

        public DbSet<InvoiceOrder> InvoiceOrders { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        public DbSet<InvoiceOrderResult> InvoiceOrderResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceOrder>().HasMany(x => x.InvoiceDetails).WithOne(x => x.InvoiceOrder);
        }
    }
}

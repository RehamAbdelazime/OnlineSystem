using ECommerce.Domain.Entities.Category;
using ECommerce.Domain.Entities.Product;
using ECommerce.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        IRepository<Categories, int> Categories { get; }
        Task CommitAsync();
    }
}
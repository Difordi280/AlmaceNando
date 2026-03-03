using AlmaceNando.Data.Context;
using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Repositories;
using AlmaceNando.Logic.DoTS;
using AlmaceNando.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Logic.ServiceSales
{
    public class ServiceSales: IServiceSales
    {
        private StoreContext _db;
        
        private readonly IRepository<Sale> repository;
        
        public ServiceSales(StoreContext Db, IRepository<Sale> re)
        {
            _db = Db;
            repository = re;
        }

        public async Task ProccessSales(decimal Num, IEnumerable<SalesItem> CartItems)
        {
           

            //sacamos las direcciones 
            var LocalId = CartItems.Select(l => l.Id).ToHashSet();

            //MOVER EN UN FUTURO A .Data 
            //vemos que datos coinciden con esas direcciones
            var Candidates = await _db.Set<Product>()
                                .Where(bd => LocalId.Contains(bd.Id))
                                .ToListAsync();


            
            // buscamos los para hacer el cambio de los tados 
            var Result = Candidates
                            .Join(CartItems,
                            b => b.Id,
                            local => local.Id,
                            (b, local) => 
                            {
                                b.Id= b.Id;
                                b.Stock = b.Stock - local.Quantity;

                                return b;
                            }).ToList();

            // Segundo Parte

            var Time = DateTime.Now;
            var newSales = new Sale()
            {
                Id = Guid.NewGuid(),

                CreatedAt = Time,
                IsDeleted = false,
                SyncStatus = false,

                TotalAmount = Num,
                ClientId = null,
                //con el Select llenamos todos los datos que nos falta y Dejamos ordenado 
                //el codigo y legible
                SaleDetails = CartItems.Select(item => new SaleDetail
                {
                    Id = item.Id,
                    CreatedAt= Time,
                    IsDeleted = false,
                    SyncStatus = false,

                    productId = item.Id,
                    Quantity = item.Quantity,
                    UnitPrice= item.Price,

                }).ToList()


            };

            await repository.AddAnsy(newSales);


        }
    }
}

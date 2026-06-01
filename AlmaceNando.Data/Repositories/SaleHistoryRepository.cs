using AlmaceNando.Data.Context;
using AlmaceNando.Domain.IRepositories;
using AlmaceNando.Domain.Models.Inventory;
using AlmaceNando.Domain.Record;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlmaceNando.Data.Repositories
{

   
    public class SaleHistoryRepository: ISaleHistoryRepository
    {
        private readonly StoreContext _context;

        public SaleHistoryRepository(StoreContext context)
        {
            _context = context;
        }


        private IQueryable<Sale> Filtre(SaleSearchCriteria parametros)
        {
            IQueryable<Sale> query = _context.Set<Sale>()
                            .OrderByDescending(s => s.CreatedAt);

            // Encadenamos solo por grandes temáticas de negocio
            query = FilterByDateRange(query, parametros.StartDate, parametros.EndDate);
            query = FilterByStatus( query, parametros.Debtor );
            query = FilterByWithUser(query, parametros.ClientId);
            query = FilterByWithCustomer(query,parametros.CustomerId);
            

            return query;
        }

        // ===================================================================
        // MÉTODOS MODULARES POR TEMÁTICA
        // ===================================================================

        // Temática 1: Cliente / Usuario
        private IQueryable<Sale> FilterByWithUser(IQueryable<Sale> query, Guid? idUser)
        {
            return idUser.HasValue
                ? query.Where(i => i.UserId == idUser.Value)
                : query;
        }

        private IQueryable<Sale> FilterByWithCustomer(IQueryable<Sale> query, Guid? customerId)
        {
            return customerId.HasValue
                ? query.Where(i => i.CustomerId == customerId)
                : query;
        }

        // Temática 2: Rango de Tiempo (Agrupa inicio y fin porque pertenecen al mismo contexto)
        private IQueryable<Sale> FilterByDateRange(IQueryable<Sale> query, DateTime? startDate, DateTime? endDate)
        {
            // Aquí adentro manejamos de forma segura cada límite del rango de tiempo
            if (startDate.HasValue)
            {
                query = query.Where(i => startDate.Value < i.CreatedAt);
            }

            if (endDate.HasValue)
            {
                query = query.Where(i => i.CreatedAt < endDate.Value);
            }

            return query;
        }

        // Tematica 3: Deudores,Abonos a deuda
        private IQueryable<Sale> FilterByStatus(IQueryable<Sale> query , List<SaleStatus> statuses)
        {
            //Mediante Contains Ponemos Or en Db  
            if (statuses != null && statuses.Any())
                query.Where(i=> statuses.Contains(i.Debtor));
            
            return query;
        }



        // 1. Método para obtener el LISTADO de ventas
        public async Task<IEnumerable<Sale>> SalesListAsync(SaleSearchCriteria parametros)
        {
            // Llamamos a tu motor modular para obtener el plano de la consulta con los filtros
            IQueryable<Sale> query = Filtre(parametros);

            // Ejecutamos en la base de datos y devolvemos la lista
            return await query.ToListAsync(); // SQL ejecuta: SELECT * FROM Sales WHERE ...
        }

        // 2. Método para obtener la SUMA TOTAL de los precios de las ventas
        public async Task<decimal> SalesTotalSumAsync(SaleSearchCriteria parametros)
        {
            // Reutilizamos el mismo motor modular con los mismos filtros
            IQueryable<Sale> query = Filtre(parametros);

            // Sumamos directamente la propiedad TotalAmount de la tabla Sale.
            // Usamos el operador de condiciones por si la consulta no devuelve filas (evita errores de nulos)
            return await query.SumAsync(s => s.TotalAmount); // SQL ejecuta: SELECT SUM(TotalAmount) FROM Sales WHERE ...
        }



    }
}

using GNBApi.Model;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GNBApi.Services

{
    public interface IGNBService
    {
        Task<List<Transaction>> GetAllTransactions(string name);

        Task<List<Rate>> GetAllRates(string name);

        Task<List<Transaction>> GetSKUTransactions(string name, string SKU);
    }
}

using GNBApi.Model;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GNBApi.Services

{
    public interface IGNBService
    {
        Task<List<Transaction>> GetAllTransactions(string name);
    }
}

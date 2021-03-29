using System;
using System.Collections.Generic;
using TableBooker.Domain;

namespace TableBooker.Repositories
{
    public interface ITableRepository
    {
        List<Table> GetAvaliableTables(DateTime reservationDate);
    }
}

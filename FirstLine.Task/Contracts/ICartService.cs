using System;
using System.Collections.Generic;
using System.Text;

namespace FirstLine.Task.Contracts
{
    public interface ICartService
    {
        void Add(Item item);
        void Remove(Item item);
        decimal GetTotal();
    }
}

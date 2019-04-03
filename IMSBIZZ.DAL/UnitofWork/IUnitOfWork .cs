﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}

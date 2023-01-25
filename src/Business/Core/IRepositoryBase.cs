﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Core;

public interface IRepositoryBase : IDisposable
{
    Task CommitAsync();
}

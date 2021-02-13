using Core.Manager;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IManagerBase<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetail();

    }
}

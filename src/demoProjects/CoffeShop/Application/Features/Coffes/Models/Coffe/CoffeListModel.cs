using Application.Features.Coffes.Dtos.Coffes;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Coffes.Models.Coffe
{
    public class CoffeListModel : BasePageableModel
    {
        public IList<CoffeListDto> Items { get; set; }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Card :IEntity
    {
        public int Id { get; set; }
        public string CartOwner { get; set; }
        public string CartNumber { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }
        public int CCV { get; set; }
    }
}

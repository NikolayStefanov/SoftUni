using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IIdentifiable : IBirthable
    {
        public string Id { get; set; }
    }
}

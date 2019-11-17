using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class SupplierSaveDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ContactNo { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public bool BlackList { get; set; }

        public bool Active { get; set; }
    }
}

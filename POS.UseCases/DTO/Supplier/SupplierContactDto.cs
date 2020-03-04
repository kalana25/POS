using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO.Supplier
{
    public class SupplierContactDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public string ContactNumber { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

    }
}

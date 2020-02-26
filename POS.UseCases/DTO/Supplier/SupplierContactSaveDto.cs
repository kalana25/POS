using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.UseCases.DTO.Supplier
{
    public class SupplierContactSaveDto
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string FirstName { get; set; }

        [StringLength(150)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string Position { get; set; }

        [StringLength(15)]
        public string ContactNumber { get; set; }

        [StringLength(15)]
        public string Telephone { get; set; }

        [StringLength(15)]
        public string Mobile { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        public bool Active { get; set; }

        public int SupplierId { get; set; }
    }
}

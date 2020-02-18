using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace POS.UseCases.DTO
{
    public class PurchaseOrderUpdateDto
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Code { get; set; }

        public int UserId { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public int[] ItemsAdded { get; set; }

        public int[] ItemsDeleted { get; set; }

    }
}

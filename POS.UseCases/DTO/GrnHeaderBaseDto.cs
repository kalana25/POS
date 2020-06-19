﻿using System;
using System.Collections.Generic;
using System.Text;

namespace POS.UseCases.DTO
{
    public class GrnHeaderBaseDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime GrnDate { get; set; }
        public TimeSpan Time { get; set; }
        public int Comment { get; set; }
    }
}
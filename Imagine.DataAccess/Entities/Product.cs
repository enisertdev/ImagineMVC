﻿    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;

    namespace Imagine.DataAccess.Entities
    {
        public class Product
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public decimal Price { get; set; }
            public string? ImageUrl { get; set; }
            public int? CategoryId { get; set; }
        [Required]
            public Category? Category { get; set; }
            public string? Brand { get; set; }

        }
    }

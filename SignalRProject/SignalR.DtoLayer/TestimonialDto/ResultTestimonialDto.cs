﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.TestimonialDto
{
    public class ResultTestimonialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; } //yorum
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}

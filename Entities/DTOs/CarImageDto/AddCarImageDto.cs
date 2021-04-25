using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.CarImageDto
{
    public class AddCarImageDto : IDto
    {
        public int CarId { get; set; }
        public IFormFile File { get; set; }
    }
}

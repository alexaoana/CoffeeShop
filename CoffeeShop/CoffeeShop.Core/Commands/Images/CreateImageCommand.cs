using CoffeeShop.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Commands.Images
{
    public class CreateImageCommand : IRequest<ImageDTO>
    {
        public Product Product { get; set; }
        public string AzurePath { get; set; }
    }
}

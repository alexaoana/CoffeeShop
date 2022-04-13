using CoffeeShop.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.Commands.Addresses
{
    public class CreateAddressCommand : IRequest<AddressDTO>
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public User User { get; set; }
    }
}

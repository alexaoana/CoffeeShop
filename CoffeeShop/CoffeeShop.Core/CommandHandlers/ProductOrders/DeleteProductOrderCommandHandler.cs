using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.ProductOrders;
using CoffeeShop.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.CommandHandlers.ProductOrders
{
    public class DeleteProductOrderCommandHandler : IRequestHandler<DeleteProductOrderCommand, bool>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public DeleteProductOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(DeleteProductOrderCommand request, CancellationToken cancellationToken)
        {
            _unitOfWork.ProductOrderRepository.RemoveProductOrder(request.ProductOrderId);
            return true;
        }
    }
}

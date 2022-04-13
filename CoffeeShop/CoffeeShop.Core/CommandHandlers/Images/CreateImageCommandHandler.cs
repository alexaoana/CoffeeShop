using AutoMapper;
using CoffeeShop.Core.Abstract;
using CoffeeShop.Core.Commands.Images;
using CoffeeShop.Core.Domain;
using CoffeeShop.Core.DTOs;
using MediatR;

namespace CoffeeShop.Core.CommandHandlers.Images
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, ImageDTO>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public CreateImageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ImageDTO> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var image = new Image(request.AzurePath);
            image.Product = request.Product;
            _unitOfWork.ImageRepository.AddImage(image);
            return _mapper.Map<Image, ImageDTO>(image);
        }
    }
}

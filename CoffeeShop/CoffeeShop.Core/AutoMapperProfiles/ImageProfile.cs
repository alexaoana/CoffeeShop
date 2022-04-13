using AutoMapper;
using CoffeeShop.Core.Domain;
using CoffeeShop.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Core.AutoMapperProfiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDTO>();
            CreateMap<ImageDTO, Image>();
        }
    }
}

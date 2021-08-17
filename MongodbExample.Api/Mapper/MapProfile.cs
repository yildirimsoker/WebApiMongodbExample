using AutoMapper;
using MongoDB.Bson;
using MongodbExample.Api.ApiModel;
using MongodbExample.Api.MongoDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongodbExample.Api.Mapper
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductModel>()
                    .ForMember(src => src.Id, opt => opt.MapFrom(des => des.Id.ToString()));

            CreateMap<ProductModel, Product>()
                   .ForMember(src => src.Id, opt => opt.MapFrom(des => ObjectId.Parse(des.Id)));
        }
    }
}

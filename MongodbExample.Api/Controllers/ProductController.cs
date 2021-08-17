using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongodbExample.Api.ApiModel;
using MongodbExample.Api.MongoDb.Entities;
using MongodbExample.Api.MongoDb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongodbExample.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMongoRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IMongoRepository<Product> productRepository,
                                 IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _mapper.Map<IEnumerable<ProductModel>>(_productRepository.GetAll());
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var data = _mapper.Map<ProductModel>(_productRepository.FindById(id));
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductModel product)
        {
            Product entity = _mapper.Map<Product>(product);
            _productRepository.InsertOne(entity);
            return Ok(entity.Id.ToString());
        }

        [HttpPut]
        public IActionResult Update([FromBody] ProductModel product)
        {

            Product enity = _productRepository.FindById(product.Id);
            if (enity == null)
                return NotFound();
            else
            {
                enity = _mapper.Map<Product>(product);
                _productRepository.ReplaceOne(enity);
                return Ok(product.Id.ToString());
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _productRepository.DeleteById(id);
            return Ok();
        }
    }
}

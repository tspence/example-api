using AutoMapper;
using ExampleBusinessLayer.Models;
using ExampleDataLayer.Entities;

namespace ExampleBusinessLayer
{
    public class ModelEntityMapper : IModelEntityMapper
    {
        private IMapper _mapper;
        private MapperConfiguration _config;

        public ModelEntityMapper() 
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BlogEntity, BlogModel>();
                cfg.CreateMap<BlogModel, BlogEntity>();

                cfg.CreateMap<PostEntity, PostModel>();
                cfg.CreateMap<PostModel, PostEntity>();
            });
            _mapper = _config.CreateMapper();
        }

        public MapperConfiguration GetConfiguration()
        {
            return _config;
        }

        public IMapper GetMapper()
        {
            return _mapper;
        }
    }
}

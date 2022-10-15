using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
    public class AutoMapperEntity : IAutoMapperEntity
    {
        private  readonly IMapper _mapper;


        public async Task<ViewModelCliente> GetAutoMapperEntityAsync(Cliente model)
        {
            return  _mapper.Map<ViewModelCliente>(model);
        }

        public async Task<Cliente> GetAutoMapperEntityAsync(ViewModelCliente model)
        {
            var result =  _mapper.Map<Cliente>(model);
            return  result;
        }

        //public AutoMapperEntity(IMapper mapper)
        //{
        //    _mapper = mapper;
        //}

        //public T<> GetCliente(this ViewModelCliente model)
        //{
        //    return _mapper.Map<Cliente>(model);
        //}

        //public ViewModelCliente GetCliente(this Cliente model)
        //{
        //    return _mapper.Map<ViewModelCliente>(model);
        //}

        public MapperConfiguration ClienteMap()
        {
            var config = new MapperConfiguration(
                  conf =>
                  {
                      conf.CreateMap<Cliente, ViewModelCliente>().ForMember(dst => dst.Code,
                                                   map => map.MapFrom(src => src.Id));
                      conf.CreateMap<ViewModelCliente, Cliente>();
                  }
                );

            return config;
        }
    }
}

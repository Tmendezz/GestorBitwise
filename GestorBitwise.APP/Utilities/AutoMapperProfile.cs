using AutoMapper;
using GestorBitwise.APP.Models.ViewModels;
using GestorBitwise.ENTITY;

namespace GestorBitwise.APP.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Categoria

            CreateMap<Categoria, VMCategoria>()
                .ForMember(d => d.EsActivo,
                            opt => opt.MapFrom(o => o.EsActivo == true ? 1 : 0));

            CreateMap<VMCategoria, Categoria>()
                .ForMember(d => d.EsActivo,
                            opt => opt.MapFrom(o => o.EsActivo == 1 ? true : false));

            #endregion
        }
    }
}

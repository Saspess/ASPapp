using AutoMapper;

namespace Application.Services.Common
{
    public abstract class BaseService
    {
        protected IMapper mapper;

        public BaseService(IMapper mapper) => this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
}

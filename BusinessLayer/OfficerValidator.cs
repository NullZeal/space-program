using AutoMapper;

namespace SpaceProgram.BusinessLayer
{
    

    public class OfficerValidator
    {
        private IMapper Mapper { get; }
        
        public OfficerValidator(IMapper mapper)
        {
            this.Mapper = mapper;
        }
    }
}
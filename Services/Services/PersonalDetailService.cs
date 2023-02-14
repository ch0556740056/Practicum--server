using AutoMapper;
using Common.DTO_s;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PersonalDetailService : IDataService<PersonalDetailDto>
    {
        private readonly IDataRepository<PersonalDetail> dataRepository;
        private readonly IMapper mapper;
        public PersonalDetailService(IDataRepository<PersonalDetail> dataRepository, IMapper mapper)
        {
            this.dataRepository = dataRepository;
            this.mapper = mapper;
        }

        public async Task<PersonalDetailDto> AddAsync(PersonalDetailDto entity)
        {
            List<PersonalDetailDto> personals = await GetAllAsync();
            for (int i = 0; i < personals.Count; i++)
            {
                if (entity.Identity == personals[i].Identity)
                {
                    return null;
                }
            }
            PersonalDetail newPerson = mapper.Map<PersonalDetail>(entity);
            var n = await dataRepository.AddAsync(newPerson);
            var newOne = mapper.Map<PersonalDetailDto>(n);
            return newOne;
        }

        public async Task DeleteAsync(string id)
        {
            await dataRepository.DeleteAsync(id);
        }

        public async Task<List<PersonalDetailDto>> GetAllAsync()
        {
            return mapper.Map<List<PersonalDetailDto>>(await dataRepository.GetAllAsync());
        }

        public async Task<PersonalDetailDto> GetByIdAsync(string id)
        {
            return mapper.Map<PersonalDetailDto>(await dataRepository.GetByIdAsync(id));
        }

        public async Task<PersonalDetailDto> UpdateAsync(PersonalDetailDto entity)
        {
              var q = await dataRepository.UpdateAsync(mapper.Map<PersonalDetail>(entity));

            return mapper.Map<PersonalDetailDto>(q);
        }
    }
}

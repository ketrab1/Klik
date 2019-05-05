using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Memo.Datacontract;
using Memo.Domain.WordAggregate;
using Memo.Domain.WordsModel;

namespace Memo.Api.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Word, WordDtoSend>();
        }
    }
}

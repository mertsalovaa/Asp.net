using AutoMapper;
using GameesStore_client.Models;
using GamesStore_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameesStore_client.Utils
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            // Game => GameViewModel
            CreateMap<Game, GameViewModel>()
                .ForMember(x => x.Developer, opt => opt.MapFrom(z => z.Developer.Company))
                .ForMember(x => x.Genre, opt => opt.MapFrom(z => z.Genre.Name));

            CreateMap<GameViewModel, Game>()
                .ForMember(x => x.Developer, opt => opt.MapFrom(z => new Developer { Company = z.Developer }))
                .ForMember(x => x.Genre, opt => opt.MapFrom(z => new Genre { Name = z.Genre }));
        }
    }
}
using AutoMapper;
using SimulationInsight.ESMData.Entities;
using SimulationInsight.ESMData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Mappers
{
    public static class ModelMapper
    {
        public static IMapper Mapper { get; set; }

        static ModelMapper()
        {
            MapperConfiguration mapperConfiguration = new(cfg =>
            {
                cfg.CreateMap<Mission, MissionDTO>();
                cfg.CreateMap<MissionDTO, Mission>();
                cfg.CreateMap<Track, TrackDTO>();
                cfg.CreateMap<TrackDTO, Track>();
                cfg.CreateMap<PulseDescriptor, PulseDescriptorDTO>();
                cfg.CreateMap<PulseDescriptorDTO, PulseDescriptor>().ForMember(s => s.IQSamples, opt => opt.MapFrom(src => src.Signal.Samples)).ForMember(s => s.SpectrumSamples, opt => opt.MapFrom(src => src.Signal.SpectrumSamples));
                cfg.CreateMap<IQSample, IQSampleDTO>();
                cfg.CreateMap<IQSampleDTO, IQSample>();
                cfg.CreateMap<SpectrumSample, SpectrumSampleDTO>();
                cfg.CreateMap<SpectrumSampleDTO, SpectrumSample>();
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        public static TrackDTO ConvertToTrackDTO(Track track)
        {
            var result = Mapper.Map<TrackDTO>(track);

            return result;
        }

        public static Track ConvertToTrack(TrackDTO trackDTO)
        {
            var result = Mapper.Map<Track>(trackDTO);

            return result;
        }

        public static PulseDescriptorDTO ConvertToPulseDescriptorDTO(PulseDescriptor pulseDescriptor)
        {
            var result = Mapper.Map<PulseDescriptorDTO>(pulseDescriptor);

            return result;
        }

        public static PulseDescriptor ConvertToPulseDescriptor(PulseDescriptorDTO pulseDescriptorDTO)
        {
            var result = Mapper.Map<PulseDescriptor>(pulseDescriptorDTO);

            return result;
        }
    }
}

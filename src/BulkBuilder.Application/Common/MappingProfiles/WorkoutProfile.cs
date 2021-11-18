using AutoMapper;
using BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Models;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using BulkBuilder.Domain.Entities;

namespace BulkBuilder.Application.Common.MappingProfiles
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<Workout, WorkoutDto>()
                .ForMember(dto => dto.Exercises, opts => opts.MapFrom(we => we.Exercises));

            CreateMap<WorkoutCreateDto, Workout>()
                .ForMember(w => w.Exercises, opts => opts.MapFrom(dto => dto.Exercises));

            CreateMap<WorkoutUpdateDto, Workout>()
                .ForMember(w => w.Exercises, opts => opts.MapFrom(dto => dto.Exercises));
        }
    }
}
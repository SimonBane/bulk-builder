using AutoMapper;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using BulkBuilder.Domain.Entities;

namespace BulkBuilder.Application.Common.MappingProfiles
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<WorkoutExercise, WorkoutExerciseDto>()
                .ForMember(dto => dto.Name, opts => opts.MapFrom(we => we.Exercise.Name));

            CreateMap<Workout, WorkoutDto>()
                .ForMember(dto => dto.Exercises, opts => opts.MapFrom(we => we.Exercises));

            CreateMap<WorkoutCreateDto, Workout>()
                .ForMember(w => w.Exercises, opts => opts.MapFrom(dto => dto.Exercises));

            CreateMap<WorkoutExerciseCreateDto, WorkoutExercise>();
        }
    }
}

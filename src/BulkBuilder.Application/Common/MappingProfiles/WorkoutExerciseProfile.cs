using AutoMapper;
using BulkBuilder.Application.WorkoutBuilder.WorkoutExercises.Models;
using BulkBuilder.Domain.Entities;

namespace BulkBuilder.Application.Common.MappingProfiles
{
    public class WorkoutExerciseProfile : Profile
    {
        public WorkoutExerciseProfile()
        {
            CreateMap<WorkoutExercise, WorkoutExerciseDto>()
                .ForMember(dto => dto.Name, 
                    opts => opts.MapFrom(we => we.Exercise.Name));
            
            CreateMap<WorkoutExerciseCreateDto, WorkoutExercise>();
            
            CreateMap<WorkoutExerciseUpdateDto, WorkoutExercise>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
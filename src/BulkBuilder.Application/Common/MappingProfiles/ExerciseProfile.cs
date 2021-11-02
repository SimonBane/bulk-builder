using AutoMapper;
using BulkBuilder.Application.WorkoutBuilder.Exercises.Models;
using BulkBuilder.Domain.Entities;

namespace BulkBuilder.Application.Common.MappingProfiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseDto>();
            CreateMap<ExerciseCreateDto, Exercise>();
            CreateMap<ExerciseUpdateDto, Exercise>();
        }
    }
}

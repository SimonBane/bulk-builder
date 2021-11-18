using System.Collections.Generic;
using BulkBuilder.Application.Abstractions;
using BulkBuilder.Application.Users;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Requests
{
    public class CreateWorkout : IUserOwnedRequest<WorkoutDto>
    {
        public WorkoutCreateDto Model { get; set; }
        public int UserId { get; set; }
    }
}
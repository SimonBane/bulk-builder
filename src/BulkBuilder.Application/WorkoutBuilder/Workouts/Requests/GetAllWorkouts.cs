using System.Collections.Generic;
using BulkBuilder.Application.Users;
using BulkBuilder.Application.WorkoutBuilder.Workouts.Models;
using MediatR;

namespace BulkBuilder.Application.WorkoutBuilder.Workouts.Requests
{
    public class GetAllWorkouts : IUserOwnedRequest<IEnumerable<WorkoutDto>>
    {
        public int UserId { get; set; }
    }
}
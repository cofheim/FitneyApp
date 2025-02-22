using System;
using System.Collections.Generic;
using System.Linq;
using FitneyApp.BL.Model;

namespace FitneyApp.BL.Controller
{

    public class ExerciseController : ControllerBase
    {
        private readonly User user;

        private const string EXERCISES_FILE_NAME = "exercises.dat";
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        public List<Exercise> Exercises;
        public List<Activity> Activities;

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }

        public void Add(Activity activity, DateTime begin, DateTime finish)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, finish, activity, user);
                Exercises.Add(exercise);

            }
            else
            {
                var exercise = new Exercise(begin, finish, act, user);
                Exercises.Add(exercise);

            }
            Save();
        }

        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}

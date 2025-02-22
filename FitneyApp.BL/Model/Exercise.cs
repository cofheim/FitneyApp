using System;

namespace FitneyApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public User User { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
        public Activity Activity { get; }

        public Exercise(DateTime start, DateTime end, Activity activity, User user)
        {
            // Проверка
            Start = start;
            End = end;
            Activity = activity;
            User = user;
        }
    }
}

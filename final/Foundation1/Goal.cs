using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string name;
        protected string description;
        protected int points;
        protected bool isComplete;

        public Goal(string name, string description, int points)
        {
            this.name = name;
            this.description = description;
            this.points = points;
            isComplete = false;
        }

        public abstract int RecordEvent();

        public virtual string GetStatus()
        {
            return isComplete ? "[X]" : "[ ]";
        }

        public override string ToString()
        {
            return $"{GetStatus()} {name} ({description})";
        }

        public abstract string GetStringRepresentation();

        public static Goal CreateGoalFromString(string line)
        {
            string[] parts = line.Split(':');
            if (parts.Length != 2)
                return null;

            string type = parts[0];
            string data = parts[1];
            string[] fields = data.Split(',');

            switch (type)
            {
                case "SimpleGoal":
                    if (fields.Length < 4) return null;
                    var sg = new SimpleGoal(fields[0], fields[1], int.Parse(fields[2]));
                    sg.SetComplete(bool.Parse(fields[3]));
                    return sg;

                case "EternalGoal":
                    if (fields.Length < 3) return null;
                    return new EternalGoal(fields[0], fields[1], int.Parse(fields[2]));

                case "ChecklistGoal":
                    if (fields.Length < 7) return null;
                    var cg = new ChecklistGoal(fields[0], fields[1], int.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]));
                    cg.SetCurrentCount(int.Parse(fields[5]));
                    cg.SetComplete(bool.Parse(fields[6]));
                    return cg;

                default:
                    return null;
            }
        }
    }
}

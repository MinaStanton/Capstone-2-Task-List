using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone10_TaskList
{
    class TaskManager
    {
        //fields
        private string name;
        private string decription;
        private DateTime due;
        private bool completed; 

        //properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return decription; }
            set { decription = value; }
        }
        public DateTime Due
        {
            get { return due; }
            set { due = value; }
        }
        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        //constructors
        public TaskManager() { }

        public TaskManager(string _name, string _description, DateTime _due, bool _completed = false)
        {
            name = _name;
            decription = _description;
            due = _due;
            completed = _completed;
        }

        //methods

        public static void PrintListTask(List<TaskManager> taskManagers)
        {
            Console.WriteLine($"\nList Task:");
            for(int i = 0; i < taskManagers.Count; i++)
            {
                
                Console.WriteLine($"Task {i + 1}: \n\tTeam Member Name: {taskManagers[i].name} \n\tTask Description: {taskManagers[i].decription} \n\tDue Date:\t  {taskManagers[i].due} \n\tCompleted:\t  {taskManagers[i].completed}   ");
            }

        }

       





    }
   

}

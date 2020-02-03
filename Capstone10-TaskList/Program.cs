//Mina Stanton
//January 31, 2020
//Program Description: This program will manager tasks through a menu system utilizing class and lists.

using System;
using System.Collections.Generic;

namespace Capstone10_TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and weclome to Task Manager!");//greeting the user

            List<string> MenuList = new List<string>//list of strings to contain the menu options
            {
                "List task", "Add task", "Delete task", "Mark task complete", "Quit"
            };


            List<TaskManager> TaskMembers = new List<TaskManager>//list of classes to contain task information
            {
                new TaskManager("Karen", "Brings the chips and dip", DateTime.Parse("02/02/2020").ToLocalTime()),
                new TaskManager("Peter", "Brings the wings", DateTime.Parse("02/02/2020").ToLocalTime()),
            };

            bool userContinue = true;
            while (userContinue)
            {
                PrintMenu(MenuList);
                //prompting user to make a selection
                //Console.WriteLine(MenuSelection("Please enter the number of your selection:", TaskMembers));
                string userOutput = MenuSelection("Please enter the number of your selection:", TaskMembers);
                if(userOutput == "Quit")
                {
                    break;
                }
               // TaskManager.PrintListTask(TaskMembers);

                //prompting user to continue or not
                Console.WriteLine();
                userContinue = UserContinue("Would you like to continue? (y/n)", "y", "n");
            }

            Console.WriteLine("Ok, thanks for using the Task Manager!");
        }

        public static void PrintMenu(List<string> listMenu)//prints the menu list
        {
            for(int i = 0; i < listMenu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {listMenu[i]}");
            }
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static bool UserContinue(string message, string option1_true, string option2_false)
        {
            string choice = GetUserInput(message).ToLower(); 
            if(choice == "y")
            {
                return true; 
            }
            else if (choice == "n")
            {
                return false;
            }
            else
            {
                return UserContinue("Invalid selection! " + message, option1_true, option2_false);
            }
        }
        
        //adding a new task to the task list
        public static void AddTask(List<TaskManager> addMember)
        {
            String newName = GetUserInput("Please enter the Team Member Name: ");
            String newDescription = GetUserInput("Please enter the description of the task: ");
            DateTime newDate = DateTime.Parse(GetUserInput("Please enter the due date: (mm/dd/yyy) "));

            addMember.Add(new TaskManager(newName, newDescription, newDate.ToLocalTime()));
        }
        //select a task from the menu list and sends to the method to execute
        public static string MenuSelection(string message, List<TaskManager> TaskMembersList)
        {
            string selection = GetUserInput(message);
            try
            {
                int numberSelect = int.Parse(selection);
                if((numberSelect -1) == 0)
                {
                    TaskManager.PrintListTask(TaskMembersList);
                    return "";
                }
                else if ((numberSelect - 1) == 1)
                {
                    AddTask(TaskMembersList);
                    return "";
                }
                else if((numberSelect -1) == 2)
                {
                    string deletedMethodOutput = DeleteTask("Which task would you like to delete?", TaskMembersList);
                    if(deletedMethodOutput == "Main Menu")
                    {
                        TaskManager.PrintListTask(TaskMembersList);
                        return "";
                    }
                    else
                    {
                        Console.WriteLine(deletedMethodOutput);
                        return "";
                    }
                }
                else if ((numberSelect - 1) == 3)
                {
                    string markTaskOutput = MarkTaskComplete("Which task would you like to mark as completed?", TaskMembersList);
                    if (markTaskOutput == "Main Menu")
                    {
                        TaskManager.PrintListTask(TaskMembersList);
                        return "";
                    }
                    else
                    {
                        Console.WriteLine(markTaskOutput);
                        return "";
                    }
                }
                else if ((numberSelect -1) == 4)
                {
                    
                    return "Quit";
                }
                else
                {
                    return MenuSelection("Invalid Entry! " + message, TaskMembersList);
                }
            }
            catch(IndexOutOfRangeException)
            {
                return MenuSelection("Invalid Numeric Entry! " + message, TaskMembersList);
            }
            catch (FormatException)
            {
                return MenuSelection("Invalid Entry! " + message, TaskMembersList);
            }
        }
        //delete the task if selected from the menu
        public static string DeleteTask(string message, List<TaskManager> taskMembertoDelete)
        {
            TaskManager.PrintListTask(taskMembertoDelete);
            string taskToDelete = GetUserInput(message);

            bool confirmSelection = UserContinue($"You have selected Task {taskToDelete}, are you sure you want to delete? (y/n)", "y", "n");

            if (confirmSelection == true)
            {
                try
                {
                    int numOfTaskToDelete = int.Parse(taskToDelete);
                    taskMembertoDelete.RemoveRange(numOfTaskToDelete-1, 1);
                    return "The task has been deleted!";
                }
                catch (IndexOutOfRangeException)
                {
                    return DeleteTask("Invalid Numeric Entry! " + message, taskMembertoDelete);
                }
                catch (FormatException)
                {
                    return DeleteTask("Invalid Entry! " + message, taskMembertoDelete);
                }
            }
            else
            {
                return "Main Menu"; 
            }
        }
        //mark a task as complete
        public static string MarkTaskComplete(string message, List<TaskManager> taskMemberToComplete)
        {
            TaskManager.PrintListTask(taskMemberToComplete);
            string taskToMarkComplete = GetUserInput(message);

            bool confirmSelection = UserContinue($"You have selected Task {taskToMarkComplete}, are you sure you want to mark it as complete? (y/n)", "y", "n");

            if (confirmSelection == true)
            {
                try
                {
                    int numOfTaskToComplete = int.Parse(taskToMarkComplete);
                    taskMemberToComplete[numOfTaskToComplete-1].Completed = true;
                    return "The task has been marked completed!";
                }
                catch (IndexOutOfRangeException)
                {
                    return MarkTaskComplete("Invalid Numeric Entry! " + message, taskMemberToComplete);
                }
                catch (FormatException)
                {
                    return MarkTaskComplete("Invalid Entry! " + message, taskMemberToComplete);
                }
            }
            else
            {
                return "Main Menu";
            }
        }




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    //70/100
    public class Engine
    {
        private List<Department> departments;
        private List<Doctor> doctors;

        public Engine()
        {
            this.departments = new List<Department>();
            this.doctors = new List<Doctor>();
        }

        public void Run()
        {
            List<string> command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (command[0] != "Output")
            {
                string departmentName = command[0];
                string doctorFirstName = command[1];
                string doctorLastName = command[2];
                string patient = command[3];
                string doctorFullName = doctorFirstName + doctorLastName;
                if (!doctors.Any(d => d.FistName == doctorFirstName && d.LastName == doctorLastName))
                {
                    doctors.Add(new Doctor(doctorFirstName, doctorLastName));
                }
                if (!departments.Any(d => d.Name == departmentName))
                {
                    departments.Add(new Department(departmentName));
                }
                Department currentDepartment = departments.FirstOrDefault(x => x.Name == departmentName);
                bool isFree = currentDepartment.Rooms.Any(d => d.Count < 3);
                Doctor doctor = doctors.FirstOrDefault(d => d.FullName == doctorFullName);
                if (isFree)
                {
                    Room freeRoom = currentDepartment.GetFirstFreeRoom();
                    freeRoom.AddPatient(new Patient(patient));
                    doctor.AddPatientToDoctor(new Patient(patient));
                }
                command = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            }

            string secondInput = Console.ReadLine();

            while (secondInput != "End")
            {
                string[] args = secondInput.Split();

                if (args.Length == 1)
                {
                    var rooms = 
                         this.departments.FirstOrDefault(d => d.Name == secondInput)
                         .Rooms;
                    foreach (var room in rooms)
                    {
                        Console.WriteLine(room);
                    }

                }
                else if (args.Length == 2 && int.TryParse(args[1], out int roomNum))
                {
                    Room room = this.departments.FirstOrDefault(d => d.Name == args[0])
                         .Rooms
                         .FirstOrDefault(x => x.RoomNum == roomNum);
                    string[] output = room.ToString().Split(Environment.NewLine).OrderBy(r => r).ToArray();
                    foreach (var pat in output)
                    {
                        Console.WriteLine(pat);
                    }
                }
                else
                {
                    string fullName = args[0] + args[1];
                    Doctor doctor = this.doctors.FirstOrDefault(x => x.FullName==fullName);
                    
                    string[] output = doctor.ToString().Split(Environment.NewLine).OrderBy(r => r).ToArray();
                    foreach (var pat in output)
                    {
                        Console.WriteLine(pat);
                    }
                }
                secondInput = Console.ReadLine();
            }
        }

    }
}

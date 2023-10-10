namespace BankAccount
{
    public class Program
    {
        static void Main()
        {
            List<Person> persons = new List<Person>();
            int selected_person = persons.Count-1;
            float sum;
            while (true)
            {
                try
                {
                    Console.Clear();
                    if (persons.Count == 0)
                    {
                        Console.WriteLine("Now you haven't persons");
                    } else
                    {
                        Console.Write($"Now selected person №{selected_person+1} ||| ");
                        for (int i = 0; i < persons.Count; i++)
                        {
                            if (selected_person == i)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            Console.Write($"Person №{i+1}");
                            Console.ForegroundColor = ConsoleColor.White;
                            if (i != persons.Count - 1)
                            {
                                Console.Write(" | ");
                            }
                            
                        } 
                    }
                    Console.WriteLine("\nQ - Create new Person\nW - change selected_person\nE - Show person info\n"
                        + "R - add money\nT - take money\nY - take all money\nU - Transfer to another person");
                    ConsoleKey pressed_key = Console.ReadKey().Key;
                    Console.WriteLine("\n");
                    switch (pressed_key)
                    {
                        case ConsoleKey.Q:
                            Console.WriteLine("Enter fio of new person: ");
                            string fio = Console.ReadLine();
                            Console.WriteLine("Enter start sum on deposit: ");
                            sum = float.Parse(Console.ReadLine());
                            persons.Add(new Person(fio, sum));
                            if (sum < 0)
                            {
                                Console.WriteLine($"Can take only positive digits! Press any key to continue: ");
                                Console.ReadKey();
                                break;
                            }
                            
                            if (selected_person == -1)
                            {
                                selected_person = 0;
                            }
                            break;

                        case ConsoleKey.W:
                            Console.WriteLine("Input new selected person!");
                            int new_selected_pers = int.Parse(Console.ReadLine()) - 1;
                            if (new_selected_pers >= persons.Count)
                            {
                                Console.WriteLine($"Now you have only {persons.Count} persons! Press any key to continue: ");
                                Console.ReadKey();
                                break;
                            } 
                            if (new_selected_pers < 0)
                            {
                                Console.WriteLine($"Can take only positive digits! Press any key to continue: ");
                                Console.ReadKey();
                                break;
                            }

                            selected_person = new_selected_pers;
                            break;

                        case ConsoleKey.E:
                            persons[selected_person].show_info();
                            Console.WriteLine("Press any key to continue: ");
                            Console.ReadKey();
                            break;

                        case ConsoleKey.R:
                            Console.WriteLine("Enter how much money you want to add: ");
                            persons[selected_person].dob(float.Parse(Console.ReadLine()));
                            break;

                        case ConsoleKey.T:
                            Console.WriteLine("Enter how much money you want to take: ");
                            sum = float.Parse(Console.ReadLine());
                            if (persons[selected_person].getDeposit() < sum)
                            {
                                Console.WriteLine($"You have no {sum} to take! Press any key to continue: ");
                                Console.ReadKey();
                                break;
                            }
                            persons[selected_person].umen(sum);
                            break;

                        case ConsoleKey.Y:
                            persons[selected_person].obnul();
                            break;

                        case ConsoleKey.U:
                            Console.WriteLine("Enter number of person whom you want to transfer money: ");
                            int n_of_person = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter how much money you want to transfer: ");
                            sum = float.Parse(Console.ReadLine());
                            persons[selected_person].TransferToAnotherPerson(n_of_person, sum);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Something went wrong! Press any key to continue");
                    Console.ReadKey();
                }
            }
        }
    }
};



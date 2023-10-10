namespace BankAccount
{
    public class Person
    {
        static private List<Person> persons = new List<Person>();
        static private int counter_of_persons = 0;
        private int number_of_person;
        private string fio;
        private float deposit = 0; 

        public Person(string fio, float sum)
        {
            this.fio = fio;
            counter_of_persons++;
            number_of_person = counter_of_persons;
            deposit += sum;
            persons.Add(this);
        }
        
        public void show_info()
        {
            Console.WriteLine($"number of person - {number_of_person}\n{fio}\nNow have {deposit}");
        }

        public void dob(float sum)
        {
            deposit += sum;
        }

        public void umen(float sum)
        {
            deposit -= sum;
        }

        public float getDeposit()
        {
            return deposit;
        }

        public void obnul()
        {
            deposit = 0;
        }

        public void TransferToAnotherPerson(int n_of_person, float sum)
        {
            if (deposit < sum)
            {
                Console.WriteLine($"You have no {sum} to transfer to another person! Press any key to continue: ");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].number_of_person == n_of_person)
                {
                    deposit -= sum;
                    persons[i].dob(sum);
                    return;
                }
            }
            Console.WriteLine($"Sorry, but in our bank we haven't person with number {n_of_person}! Press any key to continue: ");
            Console.ReadKey();
        }
    }
};



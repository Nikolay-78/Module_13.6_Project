using System;

namespace Module_13._6_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            
            AGR();

            Console.ReadKey();
        }

        // Метод который принимает кортеж и показывает на экран данные
        static void AGR()
        {
            Console.WriteLine();
            (string Name, string LastName, int Age, bool HasPet, int NumPet, string[] ANP, int NumCol, string [] ANC) = Anketa();

            Console.WriteLine("Данные анкетирования пользователя: \n");
            Console.WriteLine(" Ваше имя: {0} \n Ваша Фамилия: {1} \n Ваш Возраст: {2}", Name, LastName, Age);

            if (HasPet == true)
            {
                Console.WriteLine(" Количество ваших питомцев: {0}", NumPet);
                int num1 = 1;
                foreach (string PetName in ANP)
                {
                    Console.WriteLine(" Кличка питомца №" + num1 + ": " + PetName);
                    num1++;

                }
            }
            else 
            {
                Console.WriteLine(" Питомцы отсутствуют");
            }
            
            Console.WriteLine(" Количество ваших любимых цветов: {0}", NumCol);
            int num2 = 1;
            foreach (string ColName in ANC)
            {
                Console.WriteLine(" Любимый цвет №" + num2 + ": " + ColName);
                num2++;

            }
        }
        

        // Метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж);
        static (string Name, string LastName, int Age, bool HasPet, int NumPet, string [] ANP, int NumCol, string [] ANC) Anketa()
        {
            (string Name, string LastName, int Age, bool HasPet, int NumPet, string [] ANP, int NumCol, string [] ANC) User;

            Console.WriteLine("Введите Ваше имя: ");
            User.Name = Console.ReadLine();

            Console.WriteLine("Введите Вашу Фамилию: ");
            User.LastName = Console.ReadLine();

            string age;
            int intage;
            do
            {
                Console.WriteLine("Введите возраст цифрами: ");
                age = Console.ReadLine();
            }
            while (CheckNum(age, out intage));

            User.Age = intage;

            Console.WriteLine("Есть ли у вас животные? Введите Да или Нет ");

            var result1 = Console.ReadLine();
            var result2 = result1.ToLower();                       
                                    
            if (result2 == "да")
            {
                User.HasPet = true;
                string npet;
                int intpet;
                do
                {
                    Console.WriteLine("Введите кол-во питомцев цифрами: ");
                    npet = Console.ReadLine();
                }
                while (CheckNum(npet, out intpet));

                User.NumPet = intpet;

                PetNames(intpet, out string[] AP);
                
                User.ANP = AP;
            }

            else
            {
                User.HasPet = false;
                User.NumPet = 0;
                
                PetNames(0, out string[] AP);
                
                User.ANP = AP;
            }
                        
            string ncol;
            int intcol;
            do
            {
                Console.WriteLine("Введите кол-во любимых цветов цифрами, укажите как минимум один цвет: ");
                ncol = Console.ReadLine();
            }
            while (CheckNum(ncol, out intcol));

            User.NumCol = intcol;

            Color(intcol, out string[] AC);

            User.ANC = AC;

            
            
            return User;
            
        }

        
        //Метод, принимающий на вход кол-во питомцев и возвращающий массив их кличек (заполнение с клавиатуры);
        static string [] PetNames(int NumbP, out string [] AP)
        {
            string[] ArrPetName = new string[NumbP];
            for (int i = 0; i < NumbP; i++)
            {
                Console.WriteLine("Введите имя питомца №{0}: ", i + 1);
                ArrPetName[i] = Console.ReadLine();                
            }
            AP = ArrPetName;
            return AP;

        }


        //Метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры);
        static string[] Color(int NumbС, out string[] AC)
        {
            string[] ArrColorName = new string[NumbС];
            for (int i = 0; i < NumbС; i++)
            {
                Console.WriteLine("Введите название любимого цвета №{0}: ", i + 1);
                ArrColorName[i] = Console.ReadLine();
            }
            AC = ArrColorName;
            return AC;

        }                              
                               
                      
        //Метод проверяющий корректность вводимых с клавиатуры значений;
        static bool CheckNum(string number, out int corrnumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    corrnumber = intnum;
                    return false;
                }

            }
            {
                corrnumber = 0;
                Console.WriteLine("Ввод не корректен, введите правильное значение повторно! ");
                return true;
            }
        }
    }
}

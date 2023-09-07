using System;

namespace Uppdrag_3___Bussen
{
    class Bus
    {
        int adding = 0; // Hur många ska kliva på bussen
        int passengerCount = 0;  // För att veta hur många som är på bussen

        Passenger[] passengers = new Passenger[25]; // deklarerar vår array som representerar bussen        

        public void AddPassenger()  //METOD - Här lägger vi till passagerare i vår array, användaren förser oss med name, age, gender
        {
            bool loop = false;

            while (!loop)
            {
                Console.WriteLine("Hur många passagerare vill du lägga till: ");
                loop = int.TryParse(Console.ReadLine(), out adding);    //hur många passagerare ska kliva på
                if (!loop)
                {
                    Console.WriteLine("Skriv in ett nummer, försök igen");  //använder TryParse och loopar vid fel inmatning

                }

            }

            if (passengerCount == passengers.Length) // är det exakt 25 personer i bussen är bussen full
            {
                Console.WriteLine("Bussen är full!");
            }
            else if (adding + passengerCount > passengers.Length) // vill vi lägga till fler än det finns plats för får vi veta hur många platser det finns
            {
                Console.WriteLine("Bussen har plats för 25 passagerare. Det finns " + (passengers.Length - passengerCount) + " lediga platser.");
            }
            else  // när det finns plats på bussen ber vi användaren mata in info om passagerarna
            {
                for (int i = 0; i < adding; i++)  // Loopar och ber användaren fylla i uppgifter om objektet
                {
                    passengers[passengerCount] = new Passenger();  //skapar ny passagerare
                    Console.WriteLine($"\nAnge namn på passagerare {i + 1}:");
                    passengers[passengerCount].Name = Console.ReadLine();

                    Console.WriteLine("Ange ålder:");
                    string age = Console.ReadLine();   // sparar ålder i en string som vi genom TryParse konverterar till int.
                    int element;
                    if (!int.TryParse(age, out element))
                    {
                        Console.WriteLine("Skriv endast siffror, försök igen");
                        i--;
                        continue;
                    }
                    passengers[passengerCount].Age = element;

                    Console.WriteLine("Ange kön, M-för man, K-för kvinna");
                    string str = Console.ReadLine().ToUpper();     // Vi sparar svaret i en string, använder ToUpper och tar index 0 som en char
                    char gender = str[0];
                    if (gender != 'M' && gender != 'K')
                    {
                        Console.WriteLine("Skriv endast in \"M\" eller \"K\"");
                        i--;
                        continue;
                    }


                    passengers[passengerCount].Gender = gender;
                    passengerCount++;



                }

            }



        }
        public void PrintBus() // METOD - Skriv ut passagerarna på bussen
        {
            Console.Clear();
            for (int i = 0; i < passengerCount; i++)  // Loopar igenom vår array och skriver ut objekten
            {
                Console.WriteLine($"Plats {i + 1} " + passengers[i].Name + " " + passengers[i].Age + " " + passengers[i].Gender);
            }
        }

        public int CalcTotalAge() // METOD - Räkna ut total ålder på passagerarna på bussen. Returnerar int sum
        {
            int sum = 0;
            Console.Clear();

            foreach (Passenger passenger in passengers)
            {
                if (passenger == null) continue;   //om vår array inte är full så får vi nullexception så lägger till detta
                sum += passenger.Age;
            }
            return sum;
        }

        public double CalcAverageAge() // METOD - Räkna ut medelåldern av passagerarna på bussen. Returnerar average
        {
            int sum = 0;

            for (int i = 0; i < passengerCount; i++)
            {
                sum += passengers[i].Age;
            }

            double sumNum = sum;
            double average = sumNum / passengerCount;

            return average;
        }

        public int MaxAge()  //METOD  Sök efter äldsta passgeraren på bussen. Returnerar int oldest 
        {
            int oldest = 0;  // initierar variabel oldest till värdet 0

            for (int i = 0; i < passengerCount; ++i)
            {
                if (passengers[i].Age > oldest) //om array är större än oldest,
                    oldest = passengers[i].Age; // tilldelar vi det värdet till oldest, när vi gått igenom hela arrayen är oldest högsta värdet
            }
            return oldest;

        }

        public void FindAge()   //METOD Gör en sökning inom olika ålderspann. Användaren matar in högsta o lägsta ålder.
        {                       // användaren får även söka på kön om dom vill
            int low = 0;
            int high = 0;
            bool loop1 = false;
            bool loop2 = false;
            bool loop3 = false;
            bool loop4 = false;
            char question = ' ';
            char gender = ' ';
            bool foundPassenger = false;
            int j = 0;
            Console.Clear();

            while (!loop1)
            {
                Console.WriteLine("Ange lägsta åldern i din sökning:");      //skriver in lägsta ålder
                loop1 = int.TryParse(Console.ReadLine(), out low);
                if (!loop1)
                {
                    Console.WriteLine("Skriv endast in nummer, försök igen.");
                }
            }
            while (!loop2)
            {
                Console.WriteLine("Ange högsta åldern i din sökning:");      //skriver in högsta ålder
                loop2 = int.TryParse(Console.ReadLine(), out high);           // Vi säkrar att inmatningen blir siffror med loop och TryParse
                if (!loop2)
                {
                    Console.WriteLine("Skriv endast in nummer, försök igen.");
                }
            }


            while (!loop3)
            {
                Console.WriteLine("Vill du även söka efter kön?  J/N");  // Vi kan här utöka sökningen att även gälla kön
                string str = Console.ReadLine().ToUpper();               //sparat svaret i string och gör om till Upper
                question = str[0];                               //Tar första bokstaven i str

                if (question != 'J' && question != 'N')                    //säkerställer att användaren bara kan skriva J eller N
                {
                    Console.WriteLine("Skriv endast in \"J\" eller \"N\"");
                }
                else { loop3 = true; }
            }

            if (question == 'J')
            {
                while (!loop4)
                {
                    Console.WriteLine("Vill du söka efter man eller kvinna  M/K");
                    string str2 = Console.ReadLine().ToUpper();
                    gender = str2[0];


                    if (gender != 'M' && gender != 'K')
                    {
                        Console.WriteLine("Skriv endast in \"M\" eller \"K\"");
                    }
                    else { loop4 = true; }
                }

                int i = 0;
                foreach (Passenger search in passengers)        // Loopar genom vår array och söker efter age inom vår sökning och även kön
                {
                    if (search != null && search.Age >= low && search.Age <= high && search.Gender == gender)
                    {
                        Console.WriteLine("Plats " + i + search.Name + " " + search.Age + " " + search.Gender);
                        i++;
                        foundPassenger = true;
                    }
                }
                if (!foundPassenger)
                {
                    Console.WriteLine("Kunde tyvärr inte hitta någon passagerare som stämde med din sökning.");  // om ingen passagerare finns inom sökta värden
                }
            }
            else


                foreach (Passenger search in passengers)        // Loopar genom vår array och söker efter age inom vår sökning utan kön
                {
                    if (search != null && search.Age >= low && search.Age <= high)
                    {
                        Console.WriteLine("Passagerare " + search.Name + " " + search.Age + " " + search.Gender);
                        j++;
                        foundPassenger = true;
                    }
                }
            if (!foundPassenger)
            {
                Console.WriteLine("Kunde tyvärr inte hitta någon passagerare som stämde med din sökning.");
            }
        }

        public void SortBus()  // METOD - Sorterar passagerarna efter ålder med bubble
        {


            for (int i = 0; i < passengers.Length; i++)
            {
                for (int j = 0; j < passengers.Length - 1; j++)
                {
                    if (passengers[j] == null || passengers[j + 1] == null) // Om vi har tomma platser i vår array (null) går vi nu förbi det
                    {
                        continue;
                    }

                    if (passengers[j].Age > passengers[j + 1].Age)
                    {
                        Passenger temp = passengers[j];
                        passengers[j] = passengers[j + 1];
                        passengers[j + 1] = temp;
                    }
                }
            }
            foreach (var temp in passengers)   // Loopar genon array och skriver ut efter sortering
            {
                Console.WriteLine(temp);
            }

        }

        public void RemovePassenger() //METOD - Ta bort passagerare. Vi hittar först vilket index passageraren har. användaren skriver in namn.
        {                                         // vi skriver över passageraren med null. Sedan flyttar vi fram resterande passagerare 
            Console.WriteLine("Vad heter passageraren som ska stiga av");  // inte perfekt, stavar dom fel kraschar programmet
            string input = Console.ReadLine();

            int index = -1;
            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i] != null && passengers[i].Name == input)
                {
                    index = i;
                    break;
                }
            }
            passengers[index] = null;  // sätter in null på efterfrågat index
            passengerCount--;   // minskar passengerCount för att hålla koll på antal passagerare. 
                                // Annars blir det fel om vi sedan lägger till fler passagerare, nu skriver vi över värdet null

            for (int i = 0; i < passengers.Length; i++)  // loopar genom vår array
            {
                if (passengers[i] == null) // om vi hittar null
                {
                    for (int j = i + 1; j < passengers.Length; j++) //vi börjar loopa index efter vi hittade null
                    {
                        if (passengers[j] != null)
                        {
                            Passenger temp = passengers[i];
                            passengers[i] = passengers[j];
                            passengers[j] = temp;
                            break;
                        }
                    }
                }
            }

            foreach (Passenger var in passengers) //skriver ut bussen
            {
                Console.WriteLine(var);
            }


        }



    }
    class Passenger  //Klass Passenger
    {
        private int age;
        private string name;   //field
        private char gender;

        public int Age   // property
        {
            get { return age; }    // METOD - Get/set för att komma åt och ändra age
            set { age = value; }

        }
        public string Name
        {
            get { return name; }    // METOD - Get/set för att komma åt och ändra name
            set { name = value; }
        }

        public char Gender
        {
            get { return gender; } // METOD - Get/set för att komma åt och ändra gender
            set { gender = value; }

        }

        public override string ToString() // Metod - Skriver ut
        {
            return String.Format("Namn: {0}, Ålder: {1}, Kön: {2}", Name, Age, Gender);
        }



    }

    class Program
    {


        static void Main()
        {
            Bus myBus = new Bus(); //Skapar ett nytt objekt, en ny buss. 
            int meny = 0;
            Console.WriteLine("---------------Välkommen till bussen--------------\n");
            do
            {


                Console.WriteLine("                      Meny                        ");
                Console.WriteLine("**************************************************");
                Console.WriteLine("* 1. Lägg till passagerare                       *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("* 2. Skriv ut bussen                             *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("* 3. Räkna ut total ålder                        *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("* 4. Räkna ut genomsnittsåldern                  *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("* 5. Äldsta passageraren                         *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("* 6. Sök efter ålder                             *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("* 7. Sortera                                     *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("* 8. Ta bort passagerare                         *");
                Console.WriteLine("**************************************************");
                Console.WriteLine("* 9. Avsluta programmet                          *");
                Console.WriteLine("**************************************************");


                try
                {
                    meny = int.Parse(Console.ReadLine());  //använder try catch om användaren skriver in fel format
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }


                switch (meny)  // Menyn byggs upp med switch, varje val anropar en metod
                {
                    case 1:
                        myBus.AddPassenger();
                        break;

                    case 2:
                        myBus.PrintBus();
                        break;

                    case 3:
                        int sum = myBus.CalcTotalAge();

                        Console.WriteLine("Den totala åldern på alla passagerare är " + sum + " år.");

                        break;

                    case 4:
                        double average = myBus.CalcAverageAge();
                        Console.Clear();
                        Console.WriteLine("Medelåldern på bussen är " + Math.Round(average, 2) + " år."); // avrundar till två decimaler

                        break;

                    case 5:
                        int oldest = myBus.MaxAge();
                        Console.Clear();
                        Console.WriteLine("Den äldsta passageraren är " + oldest + " år gammal.");

                        break;

                    case 6:
                        myBus.FindAge();
                        break;

                    case 7:
                        myBus.SortBus();
                        break;

                    case 8:
                        myBus.RemovePassenger();
                        break;

                    case 9:
                        Console.WriteLine("Avslutar programmet, press Enter ");
                        break;


                    default:
                        Console.WriteLine("Välj ett nummer mellan 1-9");
                        break;
                }

            }
            while (meny != 9);


            Console.ReadLine();

        }
    }

}

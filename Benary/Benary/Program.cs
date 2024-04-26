while (true)
{
    int Totaled = 0;
    int[] Finished = { 0, 0, 0, 0, 0, 0, 0, 0 };
    Console.WriteLine("1. Denary -> Binary \n2. Binary -> Denary");
    bool DenorBin = Convert.ToBoolean(Convert.ToInt16(Console.ReadLine())-1);
    Console.WriteLine("1. Two's Complement \n2. Sign and Magnitude ");
    bool TwoORSign = Convert.ToBoolean(Convert.ToInt16(Console.ReadLine()) - 1);
    Console.WriteLine("Enter your number");
    if (!DenorBin) 
    { 
        int Numbar = Convert.ToInt32(Console.ReadLine()); 
        if (TwoORSign) 
        {
            //sign and mag
            if (Numbar < 0 ) { Finished[0] = 1;Numbar *= -1; }
            for (int i = 1; i < 8; i++)
            {
                if ((Numbar - 2^(7-i))>0 ) { Finished[i] = 1; Numbar -= 2 ^ (7 - i); }
            }
        }
        else
        {
            //two's
            if (Numbar < 0) { Finished[0] = 1; Numbar += 128; }
            for (int i = 1; i < 8; i++)
            {
                if ((Numbar - 2 ^( 7 - i)) > 0) { Finished[i] = 1; Numbar -= 2 ^ (7 - i); }
            }
        }
        
        for (int i = 0; i < 8; i++) { Console.Write(Finished[i]); }Console.WriteLine("");
    }
    else 
    { 
        string? Number = Console.ReadLine();
        if (Number != null)
        {
            if (Number.Length > 8) { Console.WriteLine("Too Long"); }
            else if (TwoORSign)
            {
                //sign and mag
                for (int i = 1; i < 8; i++)
                { if (Number[i] == '1') { Totaled += (2 ^ (7 - i)); } }
                if (Number[0] == '1') { Totaled = Totaled * -1; }
            }
            else
            {
                //two's
                if (Number[0] == '1') { Totaled += -128; }
                for (int i = 1; i < 8; i++)
                { if (Number[i] == '1') { Totaled += 2 ^ (7 - i); } }
            }
            Console.WriteLine(Totaled);
        }
    }
}

using System;

namespace Homework0702
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group[] groups = new Group[0];
            string opt;




            do
            {
                Console.WriteLine("=======MENU=======");
                Console.WriteLine("1.Yeni qrup yarat :");
                Console.WriteLine("2.Qruplara bax :");
                Console.WriteLine("3.Type deyerine gore bax :");             
                Console.WriteLine("4.Bugunedek baslamis qruplara bax :");
                Console.WriteLine("5.Son 2 ayda baslamis qruplara bax :");
                Console.WriteLine("6.Bu ayin sonunadek yeni başlayacaq olan qruplara bax :");
                Console.WriteLine("7.Verilmiş 2 tarix araliğinda başlamiş olan qruplara bax :");
                Console.WriteLine("0.Menudan cix.");
                Console.WriteLine("==================");


                opt =Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.WriteLine("No:");
                        string no=Console.ReadLine();
                        Console.WriteLine("Type:");
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");

                        string typeStr;
                        byte typeByte;                    
                        {
                           typeStr = Console.ReadLine();
                           typeByte = Convert.ToByte(typeStr);

                        } while (!Enum.IsDefined(typeof(GroupType), typeByte));

                        GroupType type = (GroupType)typeByte;


                        Console.WriteLine("StarTime:");
                        string startDatestr=Console.ReadLine();
                        DateTime startDate=Convert.ToDateTime(startDatestr);


                        Group group = new Group {

                            No = no,
                            Type = type,
                            StartDate = startDate
                        };

                        Array.Resize(ref groups, groups.Length + 1);
                        groups[groups.Length - 1] = group;
                        break;

                    case "2":
                        foreach (var gr in groups)
                        {
                            Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd.MM.yyyy HH.mm")}");
                        }
                        break;

                        case"3":
                        foreach (var item in Enum.GetValues(typeof(GroupType)))
                            Console.WriteLine($"{(byte)item} - {item}");
                                            
                        Console.WriteLine("Type:");
                        typeStr =Console.ReadLine();
                        typeByte = Convert.ToByte(typeStr);
                        type = (GroupType)typeByte;
                        foreach (var gr in groups)
                        {
                            if(gr.Type == type)
                            {
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type} - StartDate: {gr.StartDate.ToString("dd.MM.yyyy HH.mm")}");
                            }
                        }
                        break; 
                    
                    case "4":

                        int count = 0;
                        foreach (var gr in groups)
                        {
                            if (gr.StartDate < DateTime.Now)
                            {
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type}  - StartDate:  {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            Console.WriteLine("Bele bir qruplar yoxdur.");
                        }
                        break; 
                    case "5":
                        int count1 = 0;
                        foreach (var gr in groups)
                        {
                            if (gr.StartDate > DateTime.Now.AddMonths(-2) && gr.StartDate < DateTime.Now)
                            {
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type}  - StartDate:  {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                count1++;
                            }
                        }
                        if (count1 == 0)
                        {
                            Console.WriteLine("Bele bir qruplar yoxdur.");
                        }
                        break;
                        case "6":
                        int count2 = 0;
                        foreach (var gr in groups)
                        {
                            if (gr.StartDate.Year >= DateTime.Now.Year && gr.StartDate.Month >= DateTime.Now.Month && gr.StartDate.Day >= DateTime.Now.Day)
                            {
                                Console.WriteLine($"No: {gr.No} - Type: {gr.Type}  - StartDate:  {gr.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                count2++;
                            }
                        }
                        if (count2 == 0)
                        {
                            Console.WriteLine("Bele bir qruplar yoxdur.");
                        }
                        break;
                    case "7":
                        Console.WriteLine("Birinci tarixi daxil edin :");
                        string firstDate = Console.ReadLine();
                        DateTime FirstDate = Convert.ToDateTime(firstDate);

                        Console.WriteLine("Ikinci tarixi daxil edin :");
                        string secondDate = Console.ReadLine();
                        DateTime SecondDate = Convert.ToDateTime(secondDate);
                        int count3 = 0;
                        foreach (var group1 in groups)
                        {
                            if (group1.StartDate >= FirstDate && group1.StartDate <= SecondDate)
                            {
                                Console.WriteLine($"No: {group1.No} - Type: {group1.Type}  - StartDate:  {group1.StartDate.ToString("dd-MM-yyyy HH:mm")}");
                                count3++;
                            }
                        }
                        if (count3 == 0)
                        {
                            Console.WriteLine("Bele bir qruplar yoxdur.");
                        }
                        break;
                    case "0":
                        Console.WriteLine("Program bitdi.");
                        break;

                    default:
                        Console.WriteLine("Seciminiz yanlisdir");
                        break;


                }

            } while (opt != "0");

            
                       

        }
    }
}

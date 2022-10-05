using System;
using System.Data;
using System.Diagnostics;//used for Stopwatch class

using MySql.Data;
using MySql.Data.MySqlClient;

using MySqlAccess;
using BusinessLogic;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using BusinessEntities;
using System.Runtime.ConstrainedExecution;
using Org.BouncyCastle.Crypto.Agreement.JPake;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Runtime.Intrinsics;
using System.Numerics;
using Org.BouncyCastle.Math;
using System.Reflection.Metadata.Ecma335;
// See https://aka.ms/new-console-template for more information

class PresentaionLayer
{
    static void Main(string[] args)
    {
        int userInput = 0;
        bool firstime = true; //bishvil lakoah rishon
        int orderId = 0, ballsID = 0, decorateID = 0, icecreamID = 0, coonsID = 0, ownerID = 0, VUseId = 0;
        //do { // for manager
        do //bishvil amzana haabaa if worker choose -1 then will finish the program and everything will be deleted
        {
            Console.WriteLine("_____________________");
            Console.WriteLine("Welcome to our icecreamshop");
            Console.WriteLine("Do you want to take a order?:");
            Console.WriteLine("1 - yes");
            Console.WriteLine("2 - no");
            //Console.WriteLine("3 - print values of a table");
            // Console.WriteLine("");
            Console.WriteLine("(-1) - for exit");
            orderId += 1;
            ballsID += 1;
            decorateID += 1;
            icecreamID += 1;
            coonsID += 1;
            ownerID += 1;
            VUseId += 1;
            // ownerID += 1;
            userInput = Int32.Parse(Console.ReadLine());
            // Logic l = new Logic();
            switch (userInput)
            {
                case 1: //roze lakahat azmana
                    
                        Console.WriteLine("iam at first switchcase");
                        // int[] cons_price = []
                        if (firstime) //lakoah rishon she poteah database mazmin kodem gviim o kufsa
                        {
                            BusinessLogic.Logic.createTables();
                            Console.WriteLine("iam at if");
                            userInput = controler(orderId, ballsID, decorateID, icecreamID, coonsID, ownerID, VUseId);




                            firstime = false;



                        }




                        else //not first time
                        {
                            //BusinessLogic.Logic.createTables();
                            Console.WriteLine("iam at else:");
                            userInput = controler(orderId, ballsID, decorateID, icecreamID, coonsID, ownerID, VUseId);

                        }



                        //we create table

                        break;

                      //  goto case 2;

            case 2: //here its can be adminstrator
                    Console.WriteLine("iam at second switchcase");
                    userInput = -1;
                    //Console.WriteLine("fill should be called");
                    // BusinessLogic.Logic.fillTables(3);
                    break;
                    // case 3:
                    //    Console.WriteLine("Enter table name (Owners/Tasks/Vehicles)");
                    //    string tableName = Console.ReadLine();
                    //     ArrayList results = BusinessLogic.Logic.getTableData(tableName);
                    //      foreach (Object obj in results)
                    //          Console.WriteLine("   {0}", obj);
                    //     Console.WriteLine();
                    //      break;

            }

            } while (userInput != -1) ;
        }


    //int orderId = 0, ballsID = 0, decorateID = 0, icecreamID = 0, coonsID = 0, ownerID = 0, VUseId = 0;
    static int controler(int orderId, int ballsID, int decorateID, int icecreamID, int coonsID, int ownerID, int VUseId)
    {
        //zarih gam po do while

        DateTime day2 = DateTime.Now;

        string day = day2.ToString();
        Console.WriteLine("sdate = {0}", day);


        string[] balls = BusinessLogic.Logic.get_balls_type();
        Coons c;
        Balls b;
        Icecream I;
        Decorate de;
        VUse v;
        Owner o;
        Order or; //salles 
                  //instaction_logic();
                  // view_balls_display_logic(balls);
        Console.WriteLine("how many balls you want?:");
        int amount_balls = Int32.Parse(Console.ReadLine());
        int price = BusinessLogic.Logic.get_balls_price(amount_balls);
        //Console.WriteLine("iam at line 58");
        int[] type_of_ball = new int[amount_balls]; //le ze zarih tavla hadasha she bollz yazbia lefi hukei 1nf

        Console.WriteLine("what type of balls you want:");
        for (int i = 0; i < balls.Length; i++)
        {
            Console.WriteLine("{0}-{1}", i, balls[i]);
        }
        Console.WriteLine("choose type of balls you want?:");

        
        for (int i = 0; i < amount_balls; i++)
        {
            type_of_ball[i] = Int32.Parse(Console.ReadLine());
        }
        //youter im hu haya boher kufsa kodem
        
        Console.WriteLine("or -1 to get out?:");
        b = new Balls(type_of_ball, type_of_ball.Length, price);//neadken ereh aharon price kshenaavor et coons
                                                            //gam im hu rak mazmin kadurim ve over halaa ani roze et hareshuma hazot 
        c = new Coons(icecreamID,null, price);
        de = new Decorate(null, price);
        o = new Owner(ownerID, null, null, null); //i can add price to him and ask him if hem to return
        I = new Icecream(icecreamID, ballsID, coonsID, decorateID, price); //maby i should add coonsID field
        v = new VUse(ownerID, icecreamID);
        or = new Order(icecreamID, 0, day, day, 0); //et day2 hasmali zarih leadken laasot funkzia she osa zot
        int dada = 5;
        int complete = 0;
        int pay = 0;
        //updating all evin if he going to exit iam going to update 
        //Logic.createSalle(or);
        update_all(b, c, de, o, I, v, or); //creating the tables
       
        //I.setPrice(price);
  
        Console.WriteLine("Checkaut what we have to put under:");
        string[] a = BusinessLogic.Logic.get_Coons_type();
        view_cons_view(a);


        Console.WriteLine("what you want top put under?:");
        Console.WriteLine("(-1) - for exit");


        int[] first = new int[2]; //arni roze maakav al hamehir
                                  //cons + balls logic 
                                  //ani zarih leadken gam be dal 
         //price 
        int tavnit = Int32.Parse(Console.ReadLine());//naniah bahar kufsa 
        if (tavnit == -1) //zarih leadken order object roze lazet legamreii
        {
            day2 = DateTime.Now;
            day = day2.ToString();
            or.update_complete_date(day);
            BusinessLogic.Logic.update(or, icecreamID);
            return -1;
        }
        int userInput = 1;                                  //type_ball ze maarah        
        do //le zarih 
        {
            //ahshav kufsa
            //
             first = Logic.createFirst2step(tavnit, amount_balls, first); //do we going to continue?
                Console.WriteLine("IAM AT CON FIRST IF");
                if (first[0] == 1)
                {
                    price += first[1];
                Console.Write("the price is = {0}", price);
                    I.setPrice(price);

                   
                Logic.update(I, icecreamID);
                break; //ize mi lulaa
                }
     


            else if (userInput == -1) //le or zarih laasot update shel sium gam
            {
                or.update_completed_payed(complete, pay);
                day2 = DateTime.Now;
                day = day2.ToString();
                or.update_complete_date(day);
                BusinessLogic.Logic.update(or, icecreamID);
                return -1;
            }
            else if (first[0] == 0) //naniah ivhar shuv ve ze izkor ki user input bahar 1 
            {
                Console.WriteLine("choose other type of cone"); //nimas le ve le ba lo youter
                view_cons_view(a);
                Console.WriteLine("or you head enought? choose= -1");
                tavnit = Int32.Parse(Console.ReadLine()); //im hu yoze eshli object kodmim shmurim
                                                          //shneihem ihiu false ve az nize 
                if (tavnit == -1)
                {
                    break;
                }
                    
                //1 order completed 0 not completed
                //1 order payed 0 not payed
            }
        } while (first[0] == 0 || userInput == 1);//im ihie true nize  //ilu first[1] siman she peula hezliha ve nize 


        Console.WriteLine("iam outside2");
        //po ze decorate logic
        // Coons con;
        //Balls b; //tov eshalu object balls she mahzik mehir at ko cons + balls 
        //no i will create the be in bl now i going to send first filtered to bl
        var user_tapping = new ArrayList();
        //price = first[1];
       // I.setPrice(price);
        if (first[0] == 1) //avarnu sinun rishoni kaet kishut
        {
            //zot omeret hu bahar tavnit
            //i need to themm setters
            Console.WriteLine("price till now =  {0}", price);
            //I.setPrice(price);
            c.setType(a[tavnit]); //
            c.setPrice(first[1]);
            Logic.update(c, icecreamID); //updateing coons
            or.update_completed_payed(complete, price);

             BusinessLogic.Logic.update(I,icecreamID);


            tapping_view_logic();

            var tapping = Logic.get_decorate_type();

            //price = first[1];

       
            //balls[1] => price till now after ward will going to do objects
           // string s = ""; //zarih livdok she input takin
                           //type_of_ball maarah strings bhirot shelo
                           //ani roze lihiot be maakav aharei mehir
            Console.WriteLine("each tapping cost 2 Nis");
            Console.WriteLine("please choose typing");
            Console.WriteLine("There might be some logical constrains");
            int[] validator2 = new int[2];
            userInput = 1;
            int go_out = 0;
            do
            {
                Console.WriteLine("please choose typing");
                for (int i = 0; i < tapping.Length; i++)
                {
                    Console.WriteLine("{0}-{1}", i, tapping[i]);
                }
                userInput = Int32.Parse(Console.ReadLine()); //it could my my tapping variable
                                                             //ani roze she yaavor et ze lifnei she ani mahnis oto 
                validator2 = BusinessLogic.Logic.CreateThirdStep(userInput, type_of_ball, price);
                if (validator2[0] == 0)
                {
                    Console.WriteLine("1-choose again");
                    Console.WriteLine("2-exit");
                    userInput = Int32.Parse(Console.ReadLine());
                    if (userInput == -1) //zarih leahnis datetime be kol makom
                    {
                        or.update_completed_payed(0, 0);
                        day2 = DateTime.Now;
                        day = day2.ToString();
                        or.update_complete_date(day);
                        BusinessLogic.Logic.update(or, icecreamID);
                        return 1;
                    }

                }
                //
                //if i return 
                user_tapping.Add(tapping[userInput]);
                Console.WriteLine("do you want more ?");
                Console.WriteLine("1-yes ?");
                Console.WriteLine("2-no ?");
                userInput = Int32.Parse(Console.ReadLine());
                if (userInput == 1)
                {
                    continue;
                }
                if (userInput == 2)
                {
                    //price += 2;
                    break; // break from while
                }
                //Console.WriteLine("Line {0}: {1}", ctr, s);
            } while (validator2[0] == 0 || userInput == 1); //kaasher validor[0] = 1 ze ize 
                                                            //ahshav zarih lirot she kol hakompozia matima
                                                            //de is decorator
            if (validator2[0] == 1) //avar bdika
            {
                string[] tapping2 = (string[])user_tapping.ToArray(typeof(string));
                foreach (string t in tapping2)
                {
                    Console.WriteLine(t);
                }
                de.updateTapping(tapping2);
                price += 2 * (validator2.Length - 1);
                I.setPrice(price);
                Console.WriteLine("the price is = {0}", price);
                // Logic.createIceCream(I);
                Logic.update(de, icecreamID);
                BusinessLogic.Logic.update(I, icecreamID);
               BusinessLogic.Logic.update(c, icecreamID);
                or.update_completed_payed(0, 0);
                day2 = DateTime.Now;
                day = day2.ToString();
                or.update_complete_date(day);
                BusinessLogic.Logic.update(or, icecreamID);
               // Logic.update(or, icecreamID);
            }
        }

       
        //Logic.createTapping(de);
        //Logic.update(de, icecreamID);
        Console.WriteLine("please add you name");
        string name = Console.ReadLine();
        Console.WriteLine("your phone");
        string phone = Console.ReadLine();
        Console.WriteLine("your address");
        string addres = Console.ReadLine();


        o.setALLwithoutID(name, phone, addres);//updating all of user object
        Logic.update(o, icecreamID);

        //// pay_view(name, price);

        //Logic.createBuyer(o);
        Console.WriteLine("the price is = {0} now", price); ;
        Console.WriteLine("do you want to pay now yes ? 1 ");    
        Console.WriteLine("do you want to pay now no ? 2 exit ");
        or.update_completed_payed(0, 0);
        Logic.update(or, icecreamID);
        //Logic.createSalle(or);
        userInput = Int32.Parse(Console.ReadLine());

        if (userInput == 2)
        {
            or.update_completed_payed(0, 0);
            day2 = DateTime.Now;
            day = day2.ToString();
            or.update_complete_date(day);
            BusinessLogic.Logic.update(or, icecreamID);
            return 1;
        }
        int completed = 0;
        int payed = 0;
        DateTime end = DateTime.MinValue;
        if (userInput == 1)
        {
            end = DateTime.Now; //le misaemim
            completed = 1;
            payed = 1;
            or.update_completed_payed(completed, payed);
            day2 = DateTime.Now;
            day = day2.ToString();
            or.update_complete_date(day);
            BusinessLogic.Logic.update(or, icecreamID);
            //Logic.createSalle(or);
        }

        return 0;

    }






    static void update_all(Balls b, Coons c, Decorate d, Owner o, Icecream i, VUse v, Order or)
    {
        Logic.createBalls(b); //naase et kulam po ve az neadken 
        Logic.createTapping(d);
        Logic.createCons(c);
        Logic.createBuyer(o);
        Logic.createIceCream(i);
        Logic.createVuse(v);
        Logic.createSalle(or);
    }



    static void pay_view(string name, int price)
    {
        Console.WriteLine("hey {0} do you want to pay now? = {1}", name, price); //naniah ze le tashlum mi rosh
        Console.WriteLine("1 -yes ");//if he pays ani yahol lesaem azmana? => ledaati ken
        Console.WriteLine("0 -no");
        Console.WriteLine("-1 -exit");
    }

    static void tapping_view_logic()
    {
        Console.WriteLine("please choose tapping!");
        Console.WriteLine("tapping cost 2 Nis!");
        Console.WriteLine("for con you only choose one tapping!");
        Console.WriteLine("for special con you got unlimited tapping!");
        Console.WriteLine("for Box theres unlimited tapping!");
        Console.WriteLine("please choose tapping!");
    }

    static void view_cons_view(string[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            Console.WriteLine("{0}-{1}", i, a[i]);
        }
    }

    static void instaction_logic()
    {
        Console.WriteLine("Hello what to put in your order?:");
        Console.WriteLine("if you choose regular con its can have 1-3 balls only you can eat and add more:");
        Console.WriteLine("if you chose spesial con you have to pay 2 nis more:");
        Console.WriteLine("if you choose regular con you dont pay extra for box you pay 5 nis more:");
        Console.WriteLine("if you choose 1 balls its 7 nis 2  balls 12 nis and 3 its 18 nis for more its 6 more");
        Console.WriteLine("if you choose box then you have to pay 5 nis more but you can put a lot tapping and balls:");
        //eshlah kol paam ve izor shura be tavla ve eadken ota be oto zman


    }

    static void view_balls_display_logic(string[] balls)
    {
        Console.WriteLine("what type of balls you want:");
        for (int i = 0; i < balls.Length; i++)
        {
            Console.WriteLine("{0}-{1}", i, balls[i]);
        }
    }




}


//Console.WriteLine("Hello, World!");
//Console.WriteLine("The current time is " + DateTime.Now);

//Stopwatch stopwatch = new Stopwatch();
//case 3 its adminitstrator who takes info



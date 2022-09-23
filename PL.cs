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
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("The current time is " + DateTime.Now);

Stopwatch stopwatch = new Stopwatch();

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
    userInput = Int32.Parse(Console.ReadLine());
        // Logic l = new Logic();
        switch (userInput)
        {
            case 1: //roze lakahat azmana
                Console.WriteLine("iam at first switchcase");
            // int[] cons_price = []
            if (firstime) //lakoah rishon she poteah database mazmin kodem gviim o kufsa
            {
                Console.WriteLine("iam at if");

                //increacseCaunt(orderId, ballsID, decorateID, icecreamID, coonsID, OwnerID, VUseId);
                //efshar leahnis et ze le funkzia viewer
                //Console.WriteLine("{0},{1}",orderId,ballsID);
                DateTime day = DateTime.Now;
                BusinessLogic.Logic.createTables();
                string[] balls = BusinessLogic.Logic.get_balls_type();

                //instaction_logic();
                // view_balls_display_logic(balls);
                Console.WriteLine("how many balls you want?:");
                int amount_balls = Int32.Parse(Console.ReadLine());

                Console.WriteLine("iam at line 58");
                int[] type_of_ball = new int[amount_balls];

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
                Balls b = new Balls(ballsID, type_of_ball, type_of_ball.Length, 0);//neadken ereh aharon price kshenaavor et coons
                                                                                   //gam im hu rak mazmin kadurim ve over halaa ani roze et hareshuma hazot 
                Logic.createBalls(b);
                //Console.WriteLine("Checkaut what we have to put under:");
                string[] a = BusinessLogic.Logic.get_Coons_type();
                view_cons_view(a);


                Console.WriteLine("what you want top put under?:");
                Console.WriteLine("(-1) - for exit");

                int tavnit = Int32.Parse(Console.ReadLine());//naniah bahar kufsa 
                                                             //type_ball ze maarah                                    //ahshav taam
                                                             //
                int[] first = new int[2]; //arni roze maakav al hamehir
                                          //cons + balls logic 
                                          //ani zarih leadken gam be dal 
                do //price will be for cons object beyaham im hakadurim
                {
                    first = Logic.createFirst2step(tavnit, amount_balls, first); //do we going to continue?
                    if (first[0] == 1)
                    {
                        break;
                    }
                    Console.WriteLine("do you want to try again? choose = 1"); //nimas le ve le ba lo youter
                    Console.WriteLine("or you head enought? choose= -1");
                    userInput = Int32.Parse(Console.ReadLine());
                    //shneihem ihiu false ve az nize
                } while (first[0] == 0 || userInput == 1);//im ihie true nize  //ilu first[1] siman she peula hezliha ve nize 

                Console.WriteLine("iam outside2");
                Coons con;
                //Balls b; //tov eshalu object balls she mahzik mehir at ko cons + balls 
                //no i will create the be in bl now i going to send first filtered to bl
                if (first[0] == 1) //avarnu sinun rishoni kaet kishut
                {
                    con = new Coons(coonsID, a[tavnit], first[1]); //
                    Console.WriteLine("coonsID {0}", coonsID);
                    Console.WriteLine("a[tavnit]= {0}", a[tavnit]);
                    Console.WriteLine("first[1] {0}", first[1]);

                    Logic.createCons(con); //creates con table
                                           //now we can make coons object and balls object
                    int price = first[1];

                    tapping_view_logic();

                    var tapping = BusinessLogic.Logic.get_decorate_type();

                    price = first[1];

                    for (int i = 0; i < tapping.Length; i++)
                    {
                        Console.WriteLine("{0}", tapping[i]);
                    }

                    //    //cons+balls+tapping

                    var user_tapping = new ArrayList();
                    //balls[1] => price till now after ward will going to do objects
                    string s = ""; //zarih livdok she input takin
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

                        s = Console.ReadLine(); //it could my my tapping variable
                                                //ani roze she yaavor et ze lifnei she ani mahnis oto 
                        validator2 = BusinessLogic.Logic.CreateThirdStep(s, type_of_ball, price);
                        if (validator2[0] == 0)
                        {
                            Console.WriteLine("1-choose again");
                            Console.WriteLine("-1-exit");
                            userInput = Int32.Parse(Console.ReadLine());

                        }
                        user_tapping.Add(s);

                        //Console.WriteLine("Line {0}: {1}", ctr, s);
                    } while (validator2[0] == 0 || userInput == 1); //kaasher validor[0] = 1 ze ize 
                                                                    //ahshav zarih lirot she kol hakompozia matima

                    if (validator2[0] == 1) //avar bdika
                    {
                        price = 2 * (validator2.Length - 1);
                    }
                    string[] tapping2 = (string[])user_tapping.ToArray();
                    //tov kol hashlavim po
                    Decorate d = new Decorate(decorateID, tapping2, tapping2.Length);
                    Logic.createTapping(d);
                    Console.WriteLine("please add you name");
                    string name = Console.ReadLine();
                    Console.WriteLine("your phone");
                    string phone = Console.ReadLine();
                    Console.WriteLine("your address");
                    string addres = Console.ReadLine();
                    Random r = new Random(); //for yes and no
                    int id_owner = r.Next(0, 1000);
                    Owner o = new Owner(id_owner, name, phone, addres);

                    Logic.createBuyer(o);
                    pay_view(name, price);

                    userInput = Int32.Parse(Console.ReadLine());



                    DateTime finish = DateTime.MinValue;
                    if (userInput == 1)
                    {
                        finish = DateTime.Now; //le misaemim
                    }
                    else if (userInput == 0)
                    {
                        finish = DateTime.MinValue;//azmana le istaima
                    }
                    //else while is kicking off
                    int completed = 1; //
                    ////Logic.GenerateConnections(orderId, tavnit, type_of_ball, user_tapping, price, o, userInput, day, finish, completed);



                    firstime = false;
                }
            }






            else
            {
                //BusinessLogic.Logic.createTables();
                Console.WriteLine("iam at else:");
                Console.WriteLine("What type you want under icecream?:");
                Console.WriteLine("Checkaut what we have to put under:");

                for (int i = 0; i < BusinessLogic.Logic.get_Coons_type().Length; i++)
                {
                    Console.WriteLine("{0}-{1}", i, ((string[]?)BusinessLogic.Logic.get_Coons_type())[i]);
                }
                userInput = Int32.Parse(Console.ReadLine());
                Console.WriteLine("(-1) - for exit");

            }

                //we create table

                break;
            
             
            case 2:
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

    } while (userInput != -1);
    //Console.WriteLine("if you worker -2 to get out  or other stay");
    //userInput = -2;
//}while (userInput != -2); //for manager to exit mishmeret


void increacseCaunt(int orderId, int ballsID, int decorateID, int icecreamID, int coonsID, int ownerID, int vUseId)
{
    orderId += 1;
    ballsID += 1;
    decorateID += 1;
    icecreamID += 1;
    coonsID += 1;
    ownerID += 1;
    vUseId += 1;
}



void pay_view(string name, int price)
{
    Console.WriteLine("hey {0} do you want to pay now? = {1}", name, price); //naniah ze le tashlum mi rosh
    Console.WriteLine("1 -yes ");//if he pays ani yahol lesaem azmana? => ledaati ken
    Console.WriteLine("0 -no");
    Console.WriteLine("-1 -exit");
}

void tapping_view_logic()
{
    Console.WriteLine("please choose tapping!");
    Console.WriteLine("tapping cost 2 Nis!");
    Console.WriteLine("for con you only choose one tapping!");
    Console.WriteLine("for special con you got unlimited tapping!");
    Console.WriteLine("for Box theres unlimited tapping!");
    Console.WriteLine("please choose tapping!");
}

void view_cons_view(string[] a)
{
    for (int i = 0; i < a.Length; i++)
    {
        Console.WriteLine("{0}-{1}", i, a[i]);
    }
}

void instaction_logic()
{
    Console.WriteLine("Hello what to put in your order?:");
    Console.WriteLine("if you choose regular con its can have 1-3 balls only you can eat and add more:");
    Console.WriteLine("if you chose spesial con you have to pay 2 nis more:");
    Console.WriteLine("if you choose regular con you dont pay extra for box you pay 5 nis more:");
    Console.WriteLine("if you choose 1 balls its 7 nis 2  balls 12 nis and 3 its 18 nis for more its 6 more");
    Console.WriteLine("if you choose box then you have to pay 5 nis more but you can put a lot tapping and balls:");
    //eshlah kol paam ve izor shura be tavla ve eadken ota be oto zman


}

void view_balls_display_logic(string[] balls)
{
    Console.WriteLine("what type of balls you want:");
    for (int i = 0; i < balls.Length; i++)
    {
        Console.WriteLine("{0}-{1}", i, balls[i]);
    }
}

Console.WriteLine("Thank you for your time");

    
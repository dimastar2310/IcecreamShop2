using System;
using System.Collections;

using BusinessEntities;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Asn1.X509;

namespace BusinessLogic
{
    public class Logic
    {
        //all of them are private
        static string[] balls_type = { "Mekupelet", "Chocolate", "Strawberry", "Vanilla", "Mint", "Lemon", "Orange", "Mango", "Blueberry", "Cherry", "Coffe" };
        static string[] Coons_type = { "Normal Coon", "Special Coon", "Box" };
        static string[] decorate_type = { "Hot Chocolate", "Peanuts", "Maple" };
        static string[] desc = { "Replace filets of oil,gasoline,air contidioner", "Change 4 tires", "fix scratchs" };

        static string[] names = { "Arkady", "Aharon", "Zeev", "Yehonatan" };
        static string[] cities = { "Jerusalem", "Tel Aviv", "Beeh Sheva", "Ariel" };
        public static string[] get_decorate_type()
        {
            return decorate_type;
        }
        public static string[] get_Coons_type()
        {
            return Coons_type;
        }

        public static string[] get_balls_type()
        {
            return balls_type;
        }

        public static void createTables()
        {
            MySqlAccess.MySqlAccess.createTables();
        }


        //public static void fillTables(int num)
        //{
        //    Random r = new Random();

        //    //generate random values for owners
        //    for (int i = 0; i < num; i++)
        //    {
        //        int rName = r.Next(0, names.Length);
        //        int rPhone = r.Next(0, 1000);
        //        int rCity = r.Next(0, names.Length);

        //        Owner o = new Owner(names[rName], "" + rPhone, cities[rCity]);
        //        MySqlAccess.MySqlAccess.insertObject(o);
        //    }

        //    //generate random values for balls
        //    for (int i = 0; i < num; i++)
        //    {
        //        int rballs = r.Next(0, balls_type.Length);
        //        int rAmount = r.Next(1, 4);
        //        int rPrice = rAmount * 6;


        //        Balls o = new Balls(balls_type[rballs], rAmount, rPrice);
        //        MySqlAccess.MySqlAccess.insertObject(o);
        //    }

        //    //generate random values for coons
        //    for (int i = 0; i < num; i++)
        //    {
        //        int rPrice = 0;
        //        int rCoons = r.Next(0, Coons_type.Length);
        //        if (rCoons == 0)
        //            rPrice = 1;
        //        if (rCoons == 1)
        //            rPrice = 3;
        //        if (rCoons == 2)
        //            rPrice = 6;

        //        Coons o = new Coons(Coons_type[rCoons], rPrice);
        //        MySqlAccess.MySqlAccess.insertObject(o);
        //    }

        //    //generate random values for decorate
        //    for (int i = 0; i < num; i++)
        //    {
        //        int rPrice = 0;
        //        int rdecorate = r.Next(0, decorate_type.Length);
        //        if (rdecorate == 0)
        //            rPrice = 1;
        //        if (rdecorate == 1)
        //            rPrice = 3;
        //        if (rdecorate == 2)
        //            rPrice = 6;
        //        int ramount = 0;

        //        Decorate o = new Decorate(decorate_type[rdecorate], ramount, rPrice);
        //        MySqlAccess.MySqlAccess.insertObject(o);
        //    }

        //    //generate random values for icecream
        //    for (int i = 0; i < num; i++)
        //    {
        //        int rIdBalls = r.Next(1, num);
        //        int rIdCoons = r.Next(1, num);
        //        int rIdDecorate = r.Next(1, num);
        //        int price = 5; //need to be changed
        //        Icecream o = new Icecream(rIdBalls, rIdCoons, rIdDecorate, price);
        //        MySqlAccess.MySqlAccess.insertObject(o);
        //    }

        //    //generate random values for vuse
        //    for (int i = 0; i < num; i++)
        //    {
        //        int rIdOwner = r.Next(1, num);
        //        int rIdIcecream = r.Next(1, num);
        //        VUse o = new VUse(rIdOwner, rIdIcecream);
        //        MySqlAccess.MySqlAccess.insertObject(o);
        //    }



        //    //generate random values for orders
        //    for (int i = 0; i < num; i++)
        //    {
        //        int rIdIcecream = r.Next(1, num);


        //        //generate date string
        //        int rYear = r.Next(1990, 2020);
        //        int rMonth = r.Next(1, 13);
        //        int rDate = r.Next(1, 29);
        //        string orderDate = "" + rYear + "-" + rMonth + "-" + rDate;

        //        //generate date string               
        //        rDate = rDate + r.Next(1, 29);
        //        if (rDate > 29)
        //        {
        //            rDate = rDate % 29;
        //            rMonth = rMonth + 1;
        //        }

        //        if (rMonth > 12)
        //        {
        //            rMonth = 1;
        //            rYear = rYear + 1;
        //        }


        //        string completedDate = "" + rYear + "-" + rMonth + "-" + rDate;

        //        int rCompleted = r.Next(0, 2);
        //        int rPayed = r.Next(0, 2);

        //        Order o = new Order(rIdIcecream, orderDate, completedDate, rCompleted, rPayed);
        //        MySqlAccess.MySqlAccess.insertObject(o);
        //    }

      // 

        public static ArrayList getTableData(string tableName)
        {
            ArrayList all = MySqlAccess.MySqlAccess.readAll(tableName);
            ArrayList results = new ArrayList();

            if (tableName == "Owners")
            {
                foreach (Object[] row in all)
                {
                    Owner o = new Owner((int)row[1],(string)row[2], "" + row[3], (string)row[4]);
                    results.Add(o);
                }
            }

            if (tableName == "Balls")
            {
                foreach (Object[] row in all)
                {
                    Balls o = new Balls((int)row[1], (int[])row[2], (int)row[3], (int)row[4]);
                    results.Add(o);
                }
            }

            if (tableName == "Coons")
            {
                foreach (Object[] row in all)
                {
                    Coons o = new((int)row[1],(string)row[2], (int)row[3]);
                    results.Add(o);
                }
            }
            if (tableName == "Decorate")
            {
                foreach (Object[] row in all)
                {
                    Decorate o = new Decorate((int)row[1], (string[])row[2], (int)row[3]);
                    results.Add(o);
                }
            }
            if (tableName == "VUse")
            {
                foreach (Object[] row in all)
                {
                    VUse o = new VUse((int)row[1], (int)row[2], (int)row[3]);
                    results.Add(o);
                }
            }
            if (tableName == "Order")
            {
                foreach (Object[] row in all)
                {
                    Order o = new Order((int)row[1], (int)row[2],(DateTime)row[3], (DateTime)row[4], (int)row[5]);
                    results.Add(o);
                }
            }

            return results;
        }
        //first validator

        //type_ball = ze maarah misparim
        //kinda boolean array 
        //first index is true or false
        public static int ballslogic(int amount_balls)
        {
            int price = 0;
            if (amount_balls == 1)
            {
                price = 7;
            }
            else if (amount_balls == 2)
            {
                price = 12;
            }
            else if (amount_balls == 3)
            {
                price = 18;
            }
            else //amount_balls>3
            {
                price = 6 * amount_balls + 18 + 5; //+5 mehir kufsa 


            }
            return price;

        }
        //haya zarih leahzir po object
        public static int[] createFirst2step(int tavnit, int amount_balls, int[] first)//lets create balls object and tavnit
        { //ani ivne mehir po kvar 
          //tavnit => 0 normal cone 1 speacial cone 2 box
          //
            Console.WriteLine("amount balls  = {0}", amount_balls);
            Console.WriteLine("tavnit =  {0}", tavnit);
            int price = 0;
            if (tavnit == 2) //po ani bone bdkika
            {
                if (amount_balls <= 3)
                {
                    price = ballslogic(amount_balls);
                }
                else //amount_balls>3
                {
                    price = 6 * amount_balls + 18 + 5; //+5 mehir kufsa 


                }
                first[0] = 1; //mehira hezliha
                first[1] = price;                  //
                return first;
            }
            else if (tavnit == 1 && amount_balls >= 3)
            {
                Console.WriteLine("you choose normal con and too many balls must be < 3");
                return first;

            }
            else if (tavnit == 0 && amount_balls <= 3)
            {
                //Console.WriteLine("iam at second else if");
                price = ballslogic(amount_balls);

                first[0] = 1;
                first[1] = price;
                return first;

            }
            else if (tavnit == 1 && amount_balls <= 3)
            {
               // Console.WriteLine("you choose special con and too many balls must be < 3");
                Console.WriteLine("iam at third else if");

                price = ballslogic(amount_balls);
                first[0] = 1;
                first[1] = price + 2; //biglal she hu meuhad
                return first;

            }

            Console.WriteLine("something wrong choose again please");
            return first;


        }
        //static string[] decorate_type = { "Hot Chocolate", "Peanuts", "Maple" };

        //price hu shamur ezli
        //yaliot kfiluet be ball
        //
        public static int[] CreateThirdStep(string? deco, int[] type_of_ball, int price)// string tavnit
        {
            //{{0,1},{price}
            int zeroOne = 0;
            int[] res = new int[2];
            if (type_of_ball.Length < 2)
            {
                Console.WriteLine("you need more balls for this");
                res[0] = 0; //not good
                res[1] = price;
                return res;
            }
            else if (deco == "Hot Chocolate" || deco == "Maple")
            {
                for (int i = 0; i < type_of_ball.Length; i++)
                {
                    for (int j = 0; j < balls_type.Length; j++)
                    {
                        //type_of_ball mahzik index
                        if (type_of_ball[i] == j)
                        {
                            zeroOne = 0;//not valid
                        }
                    }
                }
            }
            res[0] = 0;
            res[1] = price;

            return res;
        }
                   
          
        


        internal static void GenerateConnections(string tavnit, string[] type_of_ball, ArrayList user_tapping, int price, Owner o, int userInput, DateTime day, DateTime finish, int completed)
        {


        }

        internal static void GenerateConnections(int orderId, string tavnit, string[] type_of_ball, ArrayList user_tapping, int price, Owner o, int userInput, DateTime day, DateTime finish, int completed)
        {
            throw new NotImplementedException();
        }

        internal static void createBalls(Balls b)
        {
            MySqlAccess.MySqlAccess.insertObject(b);

        }

        internal static void createCons(Coons con)
        {
            MySqlAccess.MySqlAccess.insertObject(con);
        }

        internal static void createTapping(Decorate d)
        {
            MySqlAccess.MySqlAccess.insertObject(d); 
        }

        internal static void createBuyer(Owner o)
        {
            MySqlAccess.MySqlAccess.insertObject(o);
        }
    }
}
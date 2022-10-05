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



        public static ArrayList getTableData(string tableName)
        {
            ArrayList all = MySqlAccess.MySqlAccess.readAll(tableName);
            ArrayList results = new ArrayList();

            if (tableName == "Owners")
            {
                foreach (Object[] row in all)
                {
                    Owner o = new Owner((int)row[1], (string)row[2], "" + row[3], (string)row[4]);
                    results.Add(o);
                }
            }

            if (tableName == "Balls")
            {
                foreach (Object[] row in all)
                {
                    Balls o = new Balls((int[])row[2], (int)row[3], (int)row[1]);
                    results.Add(o);
                }
            }

            if (tableName == "Coons")
            {
                foreach (Object[] row in all)
                {
                    Coons o = new Coons((int)row[1], (string)row[2], (int)row[3]);
                    results.Add(o);
                }
            }
            if (tableName == "Decorate")
            {
                foreach (Object[] row in all)
                {
                    Decorate o = new Decorate((string[])row[2], (int)row[3]);
                    results.Add(o);
                }
            }
            if (tableName == "VUse")
            {
                foreach (Object[] row in all)
                {
                    VUse o = new VUse((int)row[1], (int)row[2]);
                    results.Add(o);
                }
            }
            if (tableName == "Order")
            {
                foreach (Object[] row in all)
                {
                    Order o = new Order((int)row[1], (int)row[2], (string)row[3], (string)row[4], (int)row[5]);
                    results.Add(o);
                }
            }

            return results;
        }
        //first validator

        //type_ball = ze maarah misparim
        //kinda boolean array 
        //first index is true or false
        internal static void update(object o, int _id)
        {
            MySqlAccess.MySqlAccess.Update(o, _id);
        }
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
        //nahzir rak mehir kufsa 
        //static string[] Coons_type = { "Normal Coon", "Special Coon", "Box" };

        //ZE BETAHLES KUFSA MEHIR GLIDA YADUA
        public static int[] createFirst2step(int tavnit, int amount_balls, int[] first)//lets create balls object and tavnit
        { //ani ivne mehir po kvar 
          //tavnit => 0 normal cone 1 speacial cone 2 box
          //
            Console.WriteLine("amount balls  = {0}", amount_balls);
            Console.WriteLine("tavnit =  {0}", tavnit);
            int price = 0;
            if (tavnit == 0) //po ani bone bdkika avur gavia ragil
            {
                int validator = 0;
                if (amount_balls <= 3)
                {
                    validator = 1;//mehira hezliha
                    price = 0;
                }
                else //amount_balls>3
                {
                    //+5 mehir kufsa 
                    validator = 0;
                    price = 0;
                    Console.WriteLine("you choose regular con and too many balls must be < 3");

                }
                first[0] = validator; //mehira hezliha
                first[1] = price;                  //
                return first;
            }
            else if (tavnit == 1 && amount_balls > 3) //speacial con
            {
                Console.WriteLine("you choose special con and too many balls must be < 3");
                return first;

            }
            else if (tavnit == 2) //special cone
            {
                //Console.WriteLine("iam at second else if");
                // price = ballslogic(amount_balls);
                price = 5;
                first[0] = 1;
                first[1] = price;
                return first;

            }
            //else if (tavnit == 1 && amount_balls <= 3)
            //{
            //    // Console.WriteLine("you choose special con and too many balls must be < 3");
            //    Console.WriteLine("iam at third else if");

            //    price = ballslogic(amount_balls);
            //    first[0] = 1;
            //    first[1] = price + 2; //biglal she hu meuhad
            //    return first;

            //}

            //Console.WriteLine("something wrong choose again please");
            //return first;

            return first;
        }
        //static string[] decorate_type = { "Hot Chocolate", "Peanuts", "Maple" };

        //price hu shamur ezli
        //yaliot kfiluet be ball
        //static string[] decorate_type = { "Hot Chocolate", "Peanuts", "Maple" };
        //static string[] balls_type = { "Mekupelet", "Chocolate", "Strawberry", "Vanilla", "Mint", "Lemon", "Orange", "Mango", "Blueberry", "Cherry", "Coffe" };
        public static int[] CreateThirdStep(int deco, int[] type_of_ball, int price)// string tavnit
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
            }//(deco == "Hot Chocolate" || deco == "Maple")
            else if (deco == 0)
            {
                Console.WriteLine("iam at else if 1 ");
                for (int i = 0; i < type_of_ball.Length; i++)
                {

                    //type_of_ball mahzik index
                    if (balls_type[type_of_ball[i]] == "Chocolate" || balls_type[type_of_ball[i]] == "Mekupelet")
                    {
                        res[0] = 0;//not valid
                        res[1] = price;
                        Console.WriteLine("you cant choose Hot Chocolate  with meku or chocho balls");
                        return res;

                    }
                }
            }

            else if (deco == 2) //maple 
            {
                Console.WriteLine("iam at else if 2 ");
                for (int i = 0; i < type_of_ball.Length; i++)
                {

                    //type_of_ball mahzik index
                    if (balls_type[type_of_ball[i]] == "Vanilla")
                    {
                        res[0] = 0;//not valid
                        res[1] = price;
                        Console.WriteLine("you cant choose Maple  tapping with vanila");
                        return res;

                    }
                }
            }
            Console.WriteLine("passed tapping");
            res[0] = 1;
            res[1] = price;

            return res;
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

        internal static void createIceCream(Icecream i)
        {
            MySqlAccess.MySqlAccess.insertObject(i);
        }

        internal static void createVuse(VUse v)
        {
            MySqlAccess.MySqlAccess.insertObject(v);
        }

        internal static void createSalle(Order or)
        {
            MySqlAccess.MySqlAccess.insertObject(or);
        }

        internal static int get_balls_price(int v)
        {
            int price = 0;
            if (v < 0)
            {
                Console.WriteLine("please choose positive amount");
            }
            else if (v == 0)
            {
                price = 0;
            }
            else if (v == 1)
            {
                price = 7;
            }
            else if (v == 2)
            {
                price = 12;
            }
            else if (v == 3)
            {
                price = 18;

            }
            else
            {
                price = 18 + (v - 3) * 6;
            }

            return price;
        }

    }
}

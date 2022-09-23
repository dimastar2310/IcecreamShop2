using MySql.Data;
using MySql.Data.MySqlClient;

using BusinessEntities;
using BusinessLogic;
using System.Collections;
using System;
using System.Runtime.InteropServices;

namespace MySqlAccess
{
    class MySqlAccess
    {

        static string connStr = "server=localhost;user=root;port=3306;password=Dimasan2310";

        /*
        this call will represent CRUD operation
        CRUD stands for Create,Read,Update,Delete
        */
        public static void createTables()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                string sql = "DROP DATABASE IF EXISTS Icecream_Shop;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create vehicles
                //sql = "CREATE SCHEMA `Icecream_Shop`";
                sql = "CREATE DATABASE Icecream_Shop;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create Balls
                sql = "CREATE TABLE `Icecream_Shop`.`Balls` (" +
                    "`idBalls` INT NOT NULL AUTO_INCREMENT, " +
                    "`_id` INT NOT NULL, " +
                    "`balls_type` VARCHAR(45) NULL," +
                    "`amount` INT NULL," +
                    "`price` INT NULL," +
                    "PRIMARY KEY (`idBalls`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create Coons
                sql = "CREATE TABLE `Icecream_Shop`.`Coons` (" +
                    "`idCoons` INT NOT NULL AUTO_INCREMENT, " +
                    "`_id` INT NOT NULL, " +
                    "`coons_type` VARCHAR(45) NULL," +
                    "`price` INT NULL," +
                    "PRIMARY KEY (`idCoons`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create Decorate
                sql = "CREATE TABLE `Icecream_Shop`.`Decorate` (" +
                    "`idDecorate` INT NOT NULL AUTO_INCREMENT, " +
                    "`decorate_type` VARCHAR(45) NULL," +
                    "`amount` VARCHAR(45) NULL," +
                    "`price` INT NULL," +
                    "PRIMARY KEY (`idDecorate`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create owners
                sql = "CREATE TABLE `Icecream_Shop`.`Owners` (" +
                    "`idOwner` INT NOT NULL AUTO_INCREMENT, " +
                    "`Name` VARCHAR(45) NOT NULL," +
                    "`Phone` VARCHAR(45) NOT NULL," +
                    "`Address` VARCHAR(45) NULL," +
                    "PRIMARY KEY (`idOwner`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create connection balls - coons - decorate
                sql = "CREATE TABLE `Icecream_Shop`.`Icecream` (" +
                    "`idIcecream` INT NOT NULL AUTO_INCREMENT," +
                    "`idBalls` INT NOT NULL," +
                    "`idCoons` INT NOT NULL," +
                    "`idDecorate` INT NOT NULL," +
                    "`total_price` INT NOT NULL," +
                    "PRIMARY KEY (`idIcecream`)," +
                    "FOREIGN KEY (idBalls) REFERENCES Balls(idBalls)," +
                    "FOREIGN KEY (idCoons) REFERENCES Coons(idCoons)," +
                    "FOREIGN KEY (idDecorate) REFERENCES Decorate(idDecorate));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                // create connection owner - icecream
                sql = "CREATE TABLE `Icecream_Shop`.`VUse` (" +
                    "`idVuse` INT NOT NULL AUTO_INCREMENT, " +
                    "`idOwner` INT NOT NULL," +
                    "`idIcecream` INT NOT NULL," +
                    "PRIMARY KEY (`idVuse`)," +
                    "FOREIGN KEY (idIcecream) REFERENCES Icecream(idIcecream)," +
                    "FOREIGN KEY (idOwner) REFERENCES Owners(idOwner));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();



               
                // create connection task - vehicle
                sql = "CREATE TABLE `Icecream_Shop`.`Orders` (" +
                    "`idOrder` INT NOT NULL AUTO_INCREMENT," +
                    "`idIcecream` INT NOT NULL," +
                    "`OrderDate` DATETIME DEFAULT NOW()," +
                    "`CompleteDate` DATETIME," +
                    "`Completed` INT NOT NULL DEFAULT 0," +
                    "`Payed` INT NOT NULL DEFAULT 0," +
                    "PRIMARY KEY (`idOrder`)," +
                    "FOREIGN KEY (idIcecream) REFERENCES Icecream(idIcecream));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void insertObject(Object obj) //memape obiekt matim le makom matim
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = null;

                if (obj is Owner)
                {
                    Owner owner = (Owner)obj;
                    sql = "INSERT INTO `Icecream_Shop`.`Owners` (`_id`,`Name`, `Phone`, `Address`) " +
                    "VALUES ('" + owner.getName() + "', '" + owner.getPhone() + "', '" + owner.getAddress() + "');";
                }

                if (obj is Balls)
                {
                    Balls balls = (Balls)obj;
                    sql = "INSERT INTO `Icecream_Shop`.`Balls` (`_id`,`balls_type`, `amount`, `price`) " +
                    "VALUES ('" + balls.get_id() + "', '" + balls.getBalls_type()  + "', '" + balls.getAmount() + "', '" + balls.getPrice() +"');";
                }
                
                if (obj is Coons) //i dont ty
                {
                    Coons coons = (Coons)obj;
                    sql = "INSERT INTO `Icecream_Shop`.`Coons` (`_id`,`coons_type`, `price`) " +
                    "VALUES ('" + coons.getId() + "', '" + coons.getCoons_type() + coons.getPrice() + "');";



                    if (obj is Decorate)
                {
                    Decorate decorate = (Decorate)obj;
                    sql = "INSERT INTO `Icecream_Shop`.`Decorate` (`_id`,`decorate_type`, `amount`) " +
                    "VALUES ('" + decorate.getId() + "', '" + decorate.getDecorate_type() + "', '" + decorate.getAmount() +  "');";
                }

                if (obj is Icecream)
                {
                    Icecream icecream = (Icecream)obj;
                    sql = "INSERT INTO `Icecream_Shop`.`Icecream` (`_id`,`idBalls`, `idCoons`, `idDecorate`, `total_price`) " +
                    "VALUES ('" + icecream.getId() + "', '" + icecream.getIdBalls() + "', '" + icecream.getIdCoons() + "', '" + icecream.getIdDecorate() + "', '" + icecream.getTotalPrice() + "');";
                }

                if (obj is VUse)
                {
                    VUse vuse = (VUse)obj;
                    sql = "INSERT INTO `Icecream_Shop`.`VUse` (`_id`,`idOwner`, `idIcecream`) " +
                    "VALUES ('" + vuse.getId() + "', ,'" + vuse.getIdUser() + "', '" + vuse.getIdIcecream() + "');";
                }

                if (obj is Order)
                {
                    Order order = (Order)obj;
                    sql = "INSERT INTO `Icecream_Shop`.`Orders` (`idIcecream`, `Completed`, `OrderDate`, `completeDate`, `Payed`) " +  
                    "VALUES ('" + order.getIdIcecream() + "', '" +
                     order.getOrderDate() + "', '" + order.getCompleteDate() + "', '" + order.getCompleted() + "', '" + order.getPayed() + "');";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static ArrayList readAll(string tableName)
        {
            ArrayList all = new ArrayList();

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM `Garage`." + tableName;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                    Object[] numb = new Object[rdr.FieldCount];
                    rdr.GetValues(numb);
                    //Array.ForEach(numb, Console.WriteLine);
                    all.Add(numb);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return all;
        }
    }

}
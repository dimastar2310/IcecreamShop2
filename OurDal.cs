using MySql.Data;
using MySql.Data.MySqlClient;

using BusinessEntities;
using BusinessLogic;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.ComponentModel;

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
                //"`_id` INT NOT NULL, " +
                //"`balls_type` INT NOT NULL," +
                sql = "CREATE TABLE `Icecream_Shop`.`Balls` (" +
                    "`idBalls` INT NOT NULL AUTO_INCREMENT, " +
                    "`my_balls` VARCHAR(200) NULL," +
                    "`amount` INT NULL," +
                    "`price` INT NULL," +
                    "PRIMARY KEY (`idBalls`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create Coons
                // 
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
                    "`decorate_type` VARCHAR(200) NULL," +
                    "`amount` VARCHAR(45) NULL," +
                    "`price` INT NULL," +
                    "PRIMARY KEY (`idDecorate`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create owners
                sql = "CREATE TABLE `Icecream_Shop`.`Owners` (" +
                    "`idOwner` INT NOT NULL AUTO_INCREMENT, " +
                    "`_id` INT NOT NULL, " +
                    "`Name` VARCHAR(45) NULL ," +
                    "`Phone` VARCHAR(45)  NULL," +
                    "`Address` VARCHAR(45) NULL," +
                    "PRIMARY KEY (`idOwner`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create connection balls - coons - decorate
                sql = "CREATE TABLE `Icecream_Shop`.`Icecream` (" +
                    "`idIcecream` INT NOT NULL AUTO_INCREMENT," +
                    "`_id` INT NOT NULL, " +
                    "`idBalls` INT  NULL," +
                    "`idCoons` INT  NULL," +
                    "`idDecorate` INT  NULL," +
                    "`total_price` INT  NULL," +
                    "PRIMARY KEY (`idIcecream`)," +
                    "FOREIGN KEY (idBalls) REFERENCES Balls(idBalls)," +
                    "FOREIGN KEY (idCoons) REFERENCES Coons(idCoons)," +
                    "FOREIGN KEY (idDecorate) REFERENCES Decorate(idDecorate));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();


                // create connection owner - icecream
                //`idVuse` given to the table by default
                sql = "CREATE TABLE `Icecream_Shop`.`VUse` (" +
                    "`idVuse` INT NOT NULL AUTO_INCREMENT, " +
                    "`idOwner` INT  NULL," +
                    "`idIcecream` INT  NULL," +
                    "PRIMARY KEY (`idVuse`)," +
                    "FOREIGN KEY (idIcecream) REFERENCES Icecream(idIcecream)," +
                    "FOREIGN KEY (idOwner) REFERENCES Owners(idOwner));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();



               
                // create connection task - vehicle
                //need to change it to sales
                sql = "CREATE TABLE `Icecream_Shop`.`Orders` (" +
                    "`idOrder` INT NOT NULL AUTO_INCREMENT," +
                    "`idIcecream` INT NULL," +
                    "`Completed` INT NULL DEFAULT 0," +
                    "`OrderDate` VARCHAR(45)  NULL," +
                    "`CompleteDate` VARCHAR(45)  NULL," + 
                    "`Payed` INT  NULL DEFAULT 0," +
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
        //insert and update
        // i thing i need to do update function
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
                    Console.WriteLine("iam at owner");
                    Owner owner = (Owner)obj;
                    sql = "INSERT  INTO `Icecream_Shop`.`Owners` (`_id`,`Name`, `Phone`, `Address`) " +
                    "VALUES ('"+owner.getId() +"', '"+ owner.getName() + "', '" + owner.getPhone() + "', '" + owner.getAddress() + "');";
                }

                if (obj is Balls)
                {
                    Console.WriteLine("iam at ballls");
                    Balls balls = (Balls)obj;
                    sql = "INSERT INTO `Icecream_Shop`.`Balls` (`my_balls`, `amount`, `price`) " +
                    "VALUES ('" + balls.getBalls_type()  + "', '" + balls.getAmount() + "', '" + balls.getPrice() +"');";
                    
                }

                if (obj is Coons) //i dont ty
                {
                    Coons coons = (Coons)obj;
                    sql = "INSERT  INTO `Icecream_Shop`.`Coons` (`_id`,`coons_type`, `price`) " +
                    "VALUES ('"+coons.getId() + "', '"+ coons.getCoons_type() + "', '" + coons.getPrice() + "');";

                }

                    if (obj is Decorate)
                {
                    Console.WriteLine("iam at decorate");
                    Decorate decorate = (Decorate)obj;
                    sql = "INSERT  INTO `Icecream_Shop`.`Decorate` (`decorate_type`, `amount`) " +
                    "VALUES ('" + decorate.getDecorate_type() + "', '" + decorate.getAmount() +  "');";
                }

                if (obj is Icecream)
                {
                    Icecream icecream = (Icecream)obj;
                    sql = "INSERT  INTO `Icecream_Shop`.`Icecream` (`_id`,`idBalls`, `idCoons`, `idDecorate`, `total_price`) " +
                    "VALUES ('" + icecream.getId() + "', '" + icecream.getIdBalls() + "', '" + icecream.getIdCoons() + "', '" + icecream.getIdDecorate() + "', '" + icecream.getTotalPrice() + "');";
                }

                if (obj is VUse)
                {
                    VUse vuse = (VUse)obj;
                    sql = "INSERT  INTO `Icecream_Shop`.`VUse` (`idOwner`, `idIcecream`) " +
                    "VALUES ('" + vuse.getIdUser() + "', '" + vuse.getIdIcecream() + "');";
                }

                if (obj is Order)
                {
                    Order order = (Order)obj;
                    sql = "INSERT  INTO `Icecream_Shop`.`Orders` (`idIcecream`, `Completed`, `OrderDate`, `completeDate`, `Payed`) " +  
                    "VALUES ('" + order.getIdIcecream() +
                    "', '" + order.getCompleted() + "', '" + order.getOrderDate() + "', '" + order.getCompleteDate() + "', '"  + order.getPayed() + "');";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(obj.ToString());
                //Console.WriteLine("iam at ballls error");
                Console.WriteLine(ex.ToString());
            }
        }
        public static void Update(object obj,int id)
        {
            
            try
            {
                string n;
                string p;
                string a;
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = null;

                if (obj is Owner)
                {
                    Console.WriteLine("iam at owner");
                    Owner owner = (Owner)obj;
                     n = owner.getName();
                     p = owner.getPhone();
                     a = owner.getAddress();
                    //idOwner
                    sql = "UPDATE Icecream_Shop.Owners SET Name='" + n + "',Phone='"+p+ "',Address='" + a+ "'WHERE idOwner='" + id + "'";
                  //  sql = $"Update Icecream_Shop.Owners SET Name={n},Phone={p},Address={a} WHERE = {id}";
                   // sql = "INSERT  INTO `Icecream_Shop`.`Owners` (`_id`,`Name`, `Phone`, `Address`) " +
                   // "VALUES ('" + owner.getId() + "', '" + owner.getName() + "', '" + owner.getPhone() + "', '" + owner.getAddress() + "');";
                }

                if (obj is Balls)
                {
                    Console.WriteLine("iam at ballls");
                    Balls balls = (Balls)obj;
                    n = balls.getBalls_type();
                    int amount = balls.getAmount();
                    int price = balls.getPrice(); //le batuah ze tov ulai laafoh le string 
                    
                    sql = $"Update Icecream_Shop.Balls SET my_balls ={n},amount={amount},price={price} WHERE id = {id}";
                    //sql = "INSERT INTO `Icecream_Shop`.`Balls` (`my_balls`, `amount`, `price`) " +
                    //"VALUES ('" + balls.getBalls_type() + "', '" + balls.getAmount() + "', '" + balls.getPrice() + "');";

                }

                if (obj is Coons) //i dont ty
                {
                    //"UPDATE tbl_employee SET FIRSTNAME='" + this.FIRSTNAME.Text + "',MI='" + this.MI.Text +
                    //"',LASTNAME='" + this.LASTNAME.Text + "',GENDER='" + this.GENDER.Text + "',POSITION='"
                    //+ this.POSITION.Text + "' WHERE EMPID='"+ this.EMPID.Text + "'";
                    Coons coons = (Coons)obj;
                    string np = coons.getCoons_type();//n is string 
                    int price = coons.getPrice();
                    //sql = "UPDATE Coons SET coons_type='"+np+'",price='"+price+'"WHERE  idCoons = id";
                    sql = "UPDATE Icecream_Shop.Coons SET coons_type='" + np + "',price='"+price+ "'WHERE idCoons='" + id + "'";
                   //  sql = "INSERT  INTO `Icecream_Shop`.`Coons` (`coons_type`, `price`) " +
                   //   "VALUES ('" + coons.getCoons_type() + "', '" + coons.getPrice() + "');";

                }

                if (obj is Decorate)
                {
                    Console.WriteLine("iam at decorate");
                    Decorate decorate = (Decorate)obj;
                    n = decorate.getDecorate_type();
                    int amount = decorate.getAmount();
                    //sql = "UPDATE Icecream_Shop.Coons SET coons_type='" + np + "',price='"+price+ "'WHERE idCoons='" + id + "'";
                    //idDecorate
                    sql = "Update Icecream_Shop.Decorate SET decorate_type='"+n+"',amount='"+amount+ "'WHERE idDecorate ='"+ id+"'";
                   // sql = "INSERT  INTO `Icecream_Shop`.`Decorate` (`decorate_type`, `amount`) " +
                   // "VALUES ('" + decorate.getDecorate_type() + "', '" + decorate.getAmount() + "');";
                }

                if (obj is Icecream)
                {

                    Icecream icecream = (Icecream)obj;

                    //int idBalls = icecream.getIdBalls();
                   // int idCons = icecream.getIdCoons();
                   // int idDecorate = icecream.getIdDecorate();
                    int t_p = icecream.getTotalPrice();
                    //"UPDATE Customers SET Name='Bill Gates' WHERE Id=1"
                    sql = $"UPDATE Icecream_Shop.Icecream SET total_price= {t_p} WHERE _id = {id}";
                    //sql = $"UPDATE Icecream_Shop.Icecream SET total_price={total_price} WHERE _id == {id}";
                   // sql = "INSERT  INTO `Icecream_Shop`.`Icecream` (`_id`,`idBalls`, `idCoons`, `idDecorate`, `total_price`) " +
                  //  "VALUES ('" + icecream.getId() + "', '" + icecream.getIdBalls() + "', '" + icecream.getIdCoons() + "', '" + icecream.getIdDecorate() + "', '" + icecream.getTotalPrice() + "');";
                }

                if (obj is VUse)
                {
                    VUse vuse = (VUse)obj;
                    int id_u = vuse.getIdUser();
                    int ind_i = vuse.getIdIcecream();
                    sql = $"UPDATE Icecream_Shop.VUse SET idOwner= {id_u},idIcecream={ind_i} WHERE _id = {id}";
                    sql = "INSERT  INTO `Icecream_Shop`.`VUse` (`idOwner`, `idIcecream`) " +
                    "VALUES ('" + vuse.getIdUser() + "', '" + vuse.getIdIcecream() + "');";
                }

                if (obj is Order)
                {
                    Order order = (Order)obj;
                    int id_icecream = order.getIdIcecream();
                    int completed = order.getCompleted();
                    int payed = order.getPayed();
                    string orderdate= order.getOrderDate();
                    string comdate = order.getCompleteDate();
                    //idOrder
                    sql = "Update Icecream_Shop.Orders SET Completed='" +completed+ "',OrderDate='" + orderdate+ "',completeDate='" + comdate + "',Payed='" + payed + "' WHERE idIcecream ='" + id + "'";
                   // sql = "UPDATE Icecream_Shop.Orders SET Completed='"+completed+"',OrderDate='"+orderdate+"',CompleteDate='"+comdate+"'+,Payed='"+payed+"'WHERE idOrder ='"+id+"'";
                  //  sql = "INSERT  INTO `Icecream_Shop`.`Orders` (`idIcecream`, `Completed`, `OrderDate`, `completeDate`, `Payed`) " +
                   // "VALUES ('" + order.getIdIcecream() +
                   // "', '" + order.getCompleted() + "', '" + order.getOrderDate() + "', '" + order.getCompleteDate() + "', '" + order.getPayed() + "');";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                Console.WriteLine(obj.ToString() + "update"+"succesfull");
            }
            catch (Exception ex)
            {
                Console.WriteLine(obj.ToString());
                //Console.WriteLine("iam at ballls error");
                Console.WriteLine(ex.ToString());
            }
        }

        public static ArrayList readAll(string tableName) //po heshbonit le lakoah zarih liet
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
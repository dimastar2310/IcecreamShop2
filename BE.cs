using System.Collections;
using System.ComponentModel;

namespace BusinessEntities
{

    // data holder classes (theoreticaly may be a struct ?)
    //Owner = buyer
    class Owner
    {
        int _id;
        string name;
        string phone;
        string address;
        //buyer 
        public Owner(int _id,string name, string phone, string address)
        {
            this._id = _id;
            this.name = name;
            this.phone = phone;
            this.address = address;
        }
        public int getId() { return _id; }
        public string getName() { return name; }
        public string getPhone() { return phone; }
        public string getAddress() { return address; }

        public override string ToString()
        {
            return base.ToString() + ": " + name + " , " + phone + " , " + address;
        }

        internal void setALLwithoutID(string? name, string? phone, string? addres)
        {
            this.name = name;
            this.phone = phone;
            this.address = addres;
        }
    }
    class Icecream
    {
        int _id;
        int idBalls;
        int idCoons;
        int idDecorate;
        int total_price;

        public Icecream(int _id,int idBalls, int idCoons, int idDecorate, int total_price)
        {
            this._id = _id;
            this.idBalls = idBalls;
            this.idCoons = idCoons;
            this.idDecorate = idDecorate;
            this.total_price = total_price;
        }
        public int getId() { return _id; }

        public int getIdBalls() { return idBalls; }
        public int getIdCoons() { return idCoons; }
        public int getIdDecorate() { return idDecorate; }
        public int getTotalPrice() { return total_price; }

        public override string ToString()
        {
            return base.ToString() + ": " + idBalls + " , " + idCoons + " , " + idDecorate + " , " + total_price;
        }

        internal void setPrice(int price)
        {
            this.total_price = price;
        }

      
    }
    class Balls
    {
        //int _id;
        int [] balls_type;
        int amount;
        int price;
        string my_balls;
        string[] balls = { "Mekupelet", "Chocolate", "Strawberry", "Vanilla", "Mint", "Lemon", "Orange", "Mango", "Blueberry", "Cherry", "Coffe" };
        public Balls(int []balls_type, int amount, int price)//int _id,
        {
            this.balls_type = balls_type;
            this.amount = amount;
            this.price = price;
            for (int i = 0; i < balls_type.Length; i++)
            {
                my_balls+=" ,"+balls[balls_type[i]];
            }
            //this._id = _id;
        }
        // public int get_id() { return _id; }
        public string getBalls_type() { return my_balls; }
       // public int[] getBalls_type() { return balls_type; }
        public int getAmount() { return amount; }
        public int getPrice() { return price; }
        public int SetPrice(int price) => this.price = price;
        public override string ToString()
        {
            return base.ToString() + ": " + balls_type + " , " + amount + " , " + price;
        }
    }

    class Coons
    {
       int _id;
        string coons_type;
        int price;
        //i thing i get default _id and thats finde
        public Coons(int _id,string coons_type,int price) //, int price int priceprice for one?
        {
            this._id   = _id;
            this.coons_type = coons_type;
            this.price = price;
        }
        public int getId() { return _id; }
        public string getCoons_type() { return coons_type; }
        public int getPrice() { return price; } //cons object will hold me the price 

        public override string ToString()
        {
            return base.ToString() + ": " + coons_type+ " , " + price;
        }

        internal void setPrice(int v)
        {
            price = v;
        }

        internal void setType(string v)
        {
            coons_type = v;
        }
    }


    class Decorate
    {

        string[] decorate_type;
        int amount;
        // int price;
        string[] my_decorate = { "Hot Chocolate", "Peanuts", "Maple" };
        string my_decorate2;
        public Decorate(string[] decorate_type, int amount) //int price 
        {
            this.decorate_type = decorate_type;
            this.amount = amount;
            if (decorate_type == null)
            {
                my_decorate2 = "";
            }
            else
            {
                for (int i = 0; i < decorate_type.Length; i++)
                {
                    my_decorate2 = my_decorate2 + "," + decorate_type[i];
                }
                Console.WriteLine("iam at constructor my_decroate2 ={0}", my_decorate2);
            }
            //this.price = price;
        }
       // public int getId() { return _id; }
       public string getDecorate_type() { return my_decorate2; }
      //  public string[] getDecorate_type() { return decorate_type; }
        public int getAmount() { return amount; }
      //  public int getPrice() { return price; }

        public override string ToString()
        {
            return base.ToString() + ": " + decorate_type + " , " + amount;// + " , " + price;
        }

        internal void setAll(object value2, object value3)
        {
            decorate_type = (string[])value2;
            amount = (int)value3;
        }

        internal void updateTapping(string[] decorate_type)
        {
            Console.WriteLine("iam at update tapping my_decroate2 ={0}", my_decorate2);
            Console.WriteLine("iam at update decorate_type we got  ={0}", decorate_type);

            if (decorate_type == null)
            {
                return;
            }
            else
            {
                for (int i = 0; i < decorate_type.Length; i++)
                {
                    my_decorate2 = my_decorate2 + "," + decorate_type[i];
                }
            }
        }
    }

    class VUse //mehaber bein kone le icecream
    {
        
        int idUser;
        int idIcecream;

        public VUse(int idUser, int idIcecream)
        {
            
            this.idUser = idUser;
            this.idIcecream = idIcecream;
        }
       // public int getId() { return _id; }
        public int getIdUser() { return idUser; }
        public int getIdIcecream() { return idIcecream; }

        public override string ToString()
        {
            return base.ToString() + ": " + idUser + " , " + idIcecream;
        }
    }
    //po ihie mehir sofi
    class Order //neshane le sales = order
    {
     
        int idIcecream;
        string orderDate;
        string completeDate;
        int completed;
        int payed;
        //string orderDate need to be changes to obj date
        //completed is 1/0 //if datetime == Datetime.min = az le siem azmana
        public Order(int idIcecream,int completed, string orderDate, string completeDate, int payed)//, int completed//lets not make it
        {
            this.idIcecream = idIcecream;
            this.completed = completed;
            this.orderDate = orderDate;
            this.completeDate = completeDate;
            this.payed = payed;
            
        }
       

        public int getIdIcecream() { return idIcecream; }

        public string getOrderDate() { return orderDate; }
        public string getCompleteDate() { return completeDate; }
        public int getCompleted() { return completed; }
        public int getPayed() { return payed; }

        public override string ToString()
        {
            return base.ToString() + ": " + idIcecream + " , " +", "+completed+" ,"+ orderDate + " , " + completeDate + " , "  + payed;//+ completed + " , "
        }

 
        internal void update_completed_payed(int v1, int v2)
        {
            completed = v1;
            payed = v2;
        }

        internal void update_complete_date(string day)
        {
           completeDate = day;
        }
    }
}
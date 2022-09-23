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
    }
    class Balls
    {
        int _id;
        int [] balls_type;
        int amount;
        int price;

        public Balls(int _id,int []balls_type, int amount, int price)
        {
            this.balls_type = balls_type;
            this.amount = amount;
            this.price = price;
            this._id = _id;
        }
        public int get_id() { return _id; }
        public int[] getBalls_type() { return balls_type; }
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
    }


    class Decorate
    {
        int _id;
        string[] decorate_type;
        int amount;
       // int price;

        public Decorate(int _id,string[] decorate_type, int amount) //int price 
        {
            this.decorate_type = decorate_type;
            this.amount = amount;
            //this.price = price;
        }
        public int getId() { return _id; }
        public string[] getDecorate_type() { return decorate_type; }
        public int getAmount() { return amount; }
      //  public int getPrice() { return price; }

        public override string ToString()
        {
            return base.ToString() + ": " + decorate_type + " , " + amount;// + " , " + price;
        }
    }

    class VUse //mehaber bein kone le icecream
    {
        int _id;
        int idUser;
        int idIcecream;

        public VUse(int _id,int idUser, int idIcecream)
        {
            this._id = _id;
            this.idUser = idUser;
            this.idIcecream = idIcecream;
        }
        public int getId() { return _id; }
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
        DateTime orderDate;
        DateTime completeDate;
        int completed;
        int payed;
        //string orderDate need to be changes to obj date
        //completed is 1/0 //if datetime == Datetime.min = az le siem azmana
        public Order(int idIcecream,int completed, DateTime orderDate, DateTime completeDate, int payed)//, int completed//lets not make it
        {
            this.idIcecream = idIcecream;
            this.orderDate = orderDate;
            this.completeDate = completeDate;
            this.completed = completed;
            this.payed = payed;
            
        }
       

        public int getIdIcecream() { return idIcecream; }

        public DateTime getOrderDate() { return orderDate; }
        public DateTime getCompleteDate() { return completeDate; }
        public int getCompleted() { return completed; }
        public int getPayed() { return payed; }

        public override string ToString()
        {
            return base.ToString() + ": " + idIcecream + " , " + orderDate + " , " + completeDate + " , "  + payed;//+ completed + " , "
        }
    }
}
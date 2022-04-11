using System;

namespace OrderBot
{
    public class Session
    {
        
        int input= 0;
        string phn;
        private registerDriver dDriver;//object of registerDriver class
        private Session()
        {
        this.dDriver= new registerDriver();
        }



    //I am not using session(string sPhone) constructor  or Order class object in program
        private Order oOrder;
        public Session(string sPhone){
            this.oOrder = new Order();
            this.oOrder.Phone = sPhone;
        }
    //

        public String OnMessage(String sInMessage)
        {
            String sMessage = "Enter 1 to login as Admin.\nEnter 2 to login as Driver.\nEnter exit to logout";
           if(sInMessage=="exit")
           {
             sMessage = "Enter 1 to login as Admin.\nEnter 2 to login as Driver";
             input=0;
           }
           switch(input)
            {

            //Login case
                case 0:
                if(sInMessage=="1")//choose 1 to login as Admin
                {
                    //login as admin
                    input=1;
                    sMessage="Enter phone number";
                    //default phone number is 12345
                }
                else if(sInMessage=="2")//Choose 2 to login as Driver
                {
                    //login as driver
                    sMessage="Enter phone number";
                    input=20;
                }
                break;


            //Admin verify Phone number
                case 1:
                if(sInMessage=="123")//phone number is 123456
                {
                    input=2;
                    sMessage="Enter password";
                  //default password is sukhvir
                }
                break;


            //Admin verify password
                case 2:
                if(sInMessage=="sukhvir")//sukhvir is password
                {
                    input= 3;
                    sMessage="Enter 1 for Register Driver.\nEnter 2 for Truck's Odometer.\nEnter 3 for Truck's Delivery History";
                }
                break;



            //Admin menu
                case 3:
                if(sInMessage=="1")//Register Driver
                {
                    input=4;
                    sMessage="Enter Driver name";
                }
                else if(sInMessage=="2")//Trucks Odometer
                {
                    //sMessage=this.dDriver.D_Odometer_pic;
                }
                else if(sInMessage=="3")//Trucks Delivery History
                {
                   // sMessage=this.dDriver.D_history;
                }
                else{
                    input=0;
                    sMessage="Invalid option.\n Enter Exit to login Again.";
                }
                break;


            //Admin Register Driver
                case 4:
               this.dDriver.DName=sInMessage;//Driver name
                input=5;
                sMessage="Enter phone number of driver";
                break;
                case 5:
               this.dDriver.DPhone=sInMessage;//Driver phone number
                input=6;
                sMessage="Assign password to driver";
                break;
                case 6:
                this.dDriver.DPassword=sInMessage;//Driver Password
                this.dDriver.D_register();
                break;


            //verify phone number and password of driver
                case 20:    
                    phn=sInMessage;
                    sMessage="Enter password";
                    input=21;
                break;    
                case 21:

                string pass= sInMessage;
                var a=this.dDriver.D_login(phn,pass);   
               if(a >= 1)
                {
                    input=22;
                    sMessage= "Enter 1 to check Truck's Delivery History.\nEnter 2 for Save Odometer picture.\nEnter 3 for QA Support ";
                }
                else{
                   // sMessage="Enter phone number and password is not registred\n"+phn+"\n"+pass+"\n"+this.dDriver.loginDriver(phn,pass)+"\n";
                   // input="Exit";
                }
                break;

            //Driver menu
                case 22:
                if(sInMessage=="1")//Truck's Delivery History.
                {
                    //get data from database of Truck's Delivery History
                    sMessage=this.dDriver.D_history();
                }
                else if(sInMessage=="2")//Save odometer picture
                {
                    input=23;
                    sMessage ="upload picture"; 
                }
                else if(sInMessage=="3")//QA support Questions
                {
                    sMessage= "get pre saved qus/ ans from database.";
                }
                else{
                    input=0;
                    sMessage="Invalid option.\n Enter Exit to login Again.";
                }
                break;
                case 23:
                this.dDriver.D_Odometer_pic(sInMessage);
                sMessage="picture saved";
                break;


            }
            System.Diagnostics.Debug.WriteLine(sMessage);
            return sMessage;
        }

    }
}

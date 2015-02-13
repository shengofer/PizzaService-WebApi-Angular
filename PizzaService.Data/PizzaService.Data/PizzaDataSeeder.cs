using PizzaService.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace PizzaService.Data
{
    
    class PizzaDataSeeder
    {
        PizzaContext _ctx;
        public PizzaDataSeeder(PizzaContext ctx)
        {
            _ctx = ctx;
        }

        public void Seed()
        {

          /*  for (int i = 0; i < customerNames.Length-1; i++)
            {
                var nameGenderMail = SplitValue(customerNames[i]);
                var customer = new Customer()
                {

                    username = String.Format("{0}{1}", nameGenderMail[0], nameGenderMail[1]),
                    email = String.Format("{0}.{1}@{2}", nameGenderMail[0], nameGenderMail[1]),
                    password = RandomString(8),
                    role = 0
                };

                _ctx.Customers.Add(customer);
            }*/
            Image img = Image.FromFile("/Images/HamAndMushrooms.png");
            for (int i = 0; i < pizzaNames.Length; i++)
            {
                var pizza = new Pizza()
                {
                    name = pizzaNames[i],
                    description = pizzaNames[i]+" desctipion",
                    price = new Random().Next(20,50) ,
                    //image = converterDemo(Image.FromFile("Images/Margarita.png"))
                    //image = imageToByteArray(Image.FromFile("Images/Margarita.png"))
                   // image = ImageToByte(img),

                };
                _ctx.Pizzas.Add(pizza);
            }
            var cust1 = new Customer
            {
                username = "Vasyz",
                email = "Vasyz@gmail.com",
                password = RandomString(8),
                role = 0,

            };
            var cust2 = new Customer
            {
                username = "Vasyz3",
                email = "Vasyz@gmail.com",
                password = RandomString(8),
                role = 0,

            };
            var cust3 = new Customer
            {
                username = "Vasyz3",
                email = "Vasyz3@gmail.com",
                password = RandomString(8),
                role = 0,

            };

            _ctx.Customers.Add(cust1);
            _ctx.Customers.Add(cust2);
            _ctx.Customers.Add(cust3);

            var ord1 = new Order
            {
                activeStatus = 1,
                customer = cust2,
                pizza = _ctx.Pizzas.Find(1),
            };
            var ord2 = new Order
            {
                activeStatus = 1,
                customer = cust2,
                pizza = _ctx.Pizzas.Find(2),
            };
            var ord3 = new Order
            {
                activeStatus = 1,
                customer = cust3,
                pizza = _ctx.Pizzas.Find(2),
            };
            _ctx.Orders.Add(ord1);
            _ctx.Orders.Add(ord2);
            _ctx.Orders.Add(ord3);

           
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public static byte[] converterDemo(Image x)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
      /*  public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        */
        

        private string RandomString(int size)
        {
            Random _rng = new Random((int)DateTime.Now.Ticks);
            string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }

        static string[] customerNames = 
        { 
            "Taiseer,Joudeh,hotmail.com", 
            "Hasan,Ahmad,mymail.com", 
            "Moatasem,Ahmad,outlook.com", 
            "Salma,Tamer,outlook.com", 
            "Ahmad,Radi,gmail.com", 
            "Bill,Gates,yahoo.com", 
            "Shareef,Khaled,gmail.com", 
            "Aram,Naser,gmail.com", 
            "Layla,Ibrahim,mymail.com", 
            "Rema,Oday,hotmail.com",
            "Fikri,Husein,gmail.com",
            "Zakari,Husein,outlook.com",
            "Taher,Waleed,mymail.com",
            "Tamer,Wesam,yahoo.com",
            "Khaled,Hasaan,gmail.com",
            "Asaad,Ibrahim,hotmail.com",
            "Tareq,Nassar,outlook.com",
            "Diana,Lutfi,outlook.com",
            "Tamara,Malek,gmail.com",
            "Arwa,Kamal,yahoo.com",
            "Jana,Ahmad,yahoo.com",
            "Nisreen,Tamer,gmail.com",
            "Noura,Ahmad,outlook.com"
        };

        private static string[] SplitValue(string val)
        {
            return val.Split(',');
        }

        static string[] pizzaNames = 
        {
            "Pizza1",
            "Pizza2",
            "Pizza3"
        };

    }
}

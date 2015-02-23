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
            if (_ctx.Pizzas.Count() > 0)
            {
                return;
            }

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
            //Image img = Image.FromFile("/Images/HamAndMushrooms.png");
            try
            {
                    for (int i = 0; i < pizzaNames.Length; i++)
                    {

                        var pizzaInfo = SplitValue(pizzaNames[i]);

                        var image = new PizzaImage
                             {
                                 path = pizzaInfo[3]
                             };
                        _ctx.PizzaImages.Add(image);
                        _ctx.SaveChanges();
                         image = _ctx.PizzaImages.Find(i+1);
                        var pizza = new Pizza()
                        {
                            name = pizzaInfo[0],
                            description = pizzaInfo[1],
                            price = new Random().Next(20,50),
                            weight = Convert.ToDouble(pizzaInfo[2]),
                            imageID = image.id,
                            image = image
                           /* image = new PizzaImage
                            {
                                path=pizzaInfo[3]
                            }*/
                            //image = converterDemo(Image.FromFile("Images/Margarita.png"))
                            //image = imageToByteArray(Image.FromFile("Images/Margarita.png"))
                           // image = ImageToByte(img),

                        };
                        _ctx.Pizzas.Add(pizza);
                        _ctx.SaveChanges();
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
                    _ctx.SaveChanges();
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
                    _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.ToString();
                throw ex;
            }
        }

        /*  public static byte[] ImageToByte(PizzaImage img)
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
        
            public static byte[] converterDemo(PizzaImage x)
            {
                ImageConverter _imageConverter = new ImageConverter();
                byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
                return xByte;
            }*/

     /*   public PizzaImage byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            PizzaImage returnImage = PizzaImage.FromStream(ms);
            return returnImage;
        }*/
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

    /*    static string[] customerNames = 
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
        };*/

        private static string[] SplitValue(string val)
        {
            return val.Split(':');
        }

        static string[] pizzaNames = 
        {
            "Margarita:Tomatoes, Souce, Mozzarella:445:Margarita",
            "Pepperoni with tomatoes:Tomatoes, Barbecue souce, Mozzarella,Pepperoni:380:PepperoniWithTomatoes",
            "Ham and Mushrooms:Ham, Mushrooms, sauce, Mozzarella:406:HamAndMushrooms",
            "Pizza Texas:Corn, Onion, Mozzarella, Mushrooms, Bavarian sausages, Barbecue sauce:425:PizzaTexas",
            "Pizza BBQ:Bacon, Chicken, Onion, Mozzarella, Mushrooms, Barbecue sauce:395:PizzaBBQ",
            "Pizza Hawaiian:Pineapple, Ham, Domino's sauce, Mozzarella:430:PizzaHawaiian",
            "Pizza Chikenita:Domino's sauce, Chicken, Onion, Mozzarella, Pepper, Tomatoes:445:PizzaChikenita",
            "Pizza Carbonara: Bacon, Ham, Onion, Mozzarella, Mushrooms, Alfredo sauce:380:PizzaCarbonara",
            "Pizza Tony Pepperoni:sauce, Mozzarella, Pepperoni:380:PizzaTonyPepperoni",
            "Pizza Veggie Feast: sauce, Onion, Mozzarella, Pepper, Mushrooms, Tomatoes, Olives:450:PizzaVeggieFeast",
            "Pizza Mexicana:sauce, Beef, Jalapenos, Onion, Mozzarella, Pepper:483:PizzaMexicana",
            "Pizza Cantri: Bacon, Ham, Onion, Mozzarella, Mushrooms, Pickled cucumber, Garlic sauce:400:PizzaCantri",
            "Pizza Tuna: sauce, Onion, Tuna, Mozzarella, Pepper, Tomatoes, Olives:449:PizzaTuna",
            "Pizza Bavarian:Parmesan, Barbecue sauce, Bavarian sausages, Mozzarella:381:PizzaBavarian",
            "Pizza PaparaZZi: Mozzarella, Pepperoni, Tomatoes, Olives, Alfredo sauce:395:PizzaPaparaZZi",
            "Pizza Dzhamaykan Bombastic: Pineapple,  sauce, Chicken, Jalapenos, Corn, Mozzarella, Pepper, Mushrooms:443:PizzaDzhamaykanBombastic",
            "Pizza Spinach and Feta: Feta, Mozzarella, Pepper, Mushrooms, Tomatoes, Spinach, Olives, Alfredo sauce:406:PizzaSpinachandFeta",
            "Pizza Americana: Bacon, Ham, sauce, Mozzarella, Pepperoni:422:PizzaAmericana",
            "Pizza Provence: Ham, Danish Blue, Mozzarella, Pepperoni, Tomatoes, Alfredo sauce:388:PizzaProvence",
            "Pizza MitZZa: sauce, Bacon, Ham, Parmesan, Mozzarella, Pepperoni, Bavarian sausages:435:PizzaMitZZa",
            "Pizza BBQ Delux: Italian sausages, Parmesan, Onion, Mozzarella, Pepperoni, Pepper, Mushrooms, Barbecue sauce:435:PizzaBBQDelux",
            "Pizza ExtravaganZZa: Domino's sauce, Ham, Beef, Italian sausages, Onion, Mozzarella, Pepperoni, Pepper, Mushrooms, Olives:538:PizzaExtravaganZZa",
            "Pizza Five Cheeses:Alfredo sauce, Parmesan, Cheddar, Feta, Mozzarella, Danish Blue:406:PizzaFiveCheeses",

        };

    }
}

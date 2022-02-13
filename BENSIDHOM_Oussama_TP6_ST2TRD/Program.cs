using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BENSIDHOM_Oussama_TP6_ST2TRD
{
    public interface Pizza
    {
        void Addchampignon();

        void Addjambon();

        void Addoignon();

        void Addsauce();
    }
    public class ConcreteBuilder : Pizza
    {
        private Product _product = new Product();

        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }
        public void Addsauce()
        {
            this._product.Add("sauce");
        }
        public void Addchampignon()
        {
            this._product.Add("champignon");
        }

        public void Addjambon()
        {
            this._product.Add("jambon");
        }

        public void Addoignon()
        {
            this._product.Add("oignon");
        }        
        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }

    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); 

            return "Product parts: " + str + "\n";
        }
    }

    public class Director
    {
        private Pizza _pizza;

        public Pizza Builder
        {
            set { _pizza = value; }
        }

        public void BuildMinimalViableProduct()
        {
            this._pizza.Addsauce();
        }

        public void BuildFullFeaturedProduct()
        {
            this._pizza.Addsauce();
            this._pizza.Addchampignon();
            this._pizza.Addjambon();
            this._pizza.Addoignon();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var builder = new ConcreteBuilder();
            director.Builder = builder;

            Console.WriteLine("Standard basic pizza:");
            director.BuildMinimalViableProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Standard full featured pizza:");
            director.BuildFullFeaturedProduct();
            Console.WriteLine(builder.GetProduct().ListParts());

            Console.WriteLine("Custom pizza:");
            builder.Addsauce();
            builder.Addchampignon();
            builder.Addoignon();
            Console.Write(builder.GetProduct().ListParts());
            Console.ReadLine();
        }
    }
}

using Accounting.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Accounting.Service.Infrastructure
{
    public class ProductXmlFileGenericRepository<T> : IProductGenericRepository<T> where T : class
    {
        const string FilePath = @"../../Resources/ServerStorage.xml";

        private List<T> _products = new List<T>();

        private XmlSerializer formatter = new XmlSerializer(typeof(List<T>));

        public ProductXmlFileGenericRepository()
        {
            this.GetAll();
        }

        public void Add(T product)
        {
            _products.Add(product);
            this.Save();
        }

        public void Delete(T product)
        {
            _products.Remove(product);
            this.Save();
        }

        public IEnumerable<T> GetAll()
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0) {
                    _products = (List<T>)formatter.Deserialize(fs);
                }
            }

            return _products;
        }

        public T GetProduct(Predicate<T> predicate)
        {
            return _products.Find(predicate);
        }

        public void Save()
        {
            using (FileStream fs = new FileStream(FilePath, FileMode.Create))
            {
                formatter.Serialize(fs, _products);
            }
        }

        public void Update(T product)
        {
            throw new NotImplementedException();
        }
    }
}

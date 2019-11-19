namespace Lab2.Server.Interfaces
{
    using Accounting.Service.Infrastructure;
    using Accounting.Service.Interfaces;

    using Lab2.Models;

    public abstract class FuelRowRequestHandler : IRequestCommand
    {
        protected readonly IProductGenericRepository<FuelRow> _repository = new ProductXmlFileGenericRepository<FuelRow>();

        public abstract object Process(Message message);
    }
}

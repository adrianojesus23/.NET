using DeskBooker.Core.DataInterface;
using DeskBooker.Core.Domain;
using DeskBooker.Core.Tests.Domain;

namespace DeskBooker.Core.Processor
{
    public class DeskBookerRequestProcessor
    {
        private readonly IDeskBookingRepository _deskBookingRepository;
        private readonly IDeskRepository _deskRepository;

        public DeskBookerRequestProcessor(IDeskBookingRepository deskBookingRepository, IDeskRepository deskRepository)
        {
            _deskBookingRepository = deskBookingRepository ?? throw new ArgumentNullException(nameof(deskBookingRepository));
            _deskRepository = deskRepository;
        }

        public DeskBookingResult BookDesk(DeskBookerRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));

            var availableDesks = _deskRepository.GetAvailableDesks(request.Date);

            _deskRepository.GetBook();

            var result = Create<DeskBookingResult>(request);

            if (availableDesks.FirstOrDefault() is Desk availableDesk) //.Count() > 0 Any()
            {
                //var availableDesk = availableDesks.First();
                var deskBooking = Create<DeskBooking>(request);
                deskBooking.DeskId = availableDesk.Id;

                _deskBookingRepository.Save(deskBooking);

                result.DeskBookingId = availableDesk.Id;
                result.Code = DeskBookingResultCode.Success;
            }
            else
            {
                result.Code = DeskBookingResultCode.NoDeskAvailable;
            }
            return result;
        }

        private static T Create<T>(DeskBookerRequest request) where T : DeskBookingBase, new()
        {
            return new T
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Date = request.Date,
                Email = request.Email
            };
        }


        private static IEnumerable<Customer> GetCustomers()
        {
            var lines = File.ReadAllLines("./customer.csv");

            return lines.Select(x =>
            {
                var splict = x.Split(',');
                return new Customer(splict[0], int.Parse(splict[1]));
            });
        }

        record Customer(string name, int age);
    }
}
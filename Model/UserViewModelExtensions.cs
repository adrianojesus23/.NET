using System.Diagnostics;

namespace Model
{
    public static class UserViewModelExtensions
    {
        public static UserModel ToModel(this UserViewModel model)
        {
            if (model is null) return new();

            return new UserModel
            {
                UserId = model.UserId,
                UserName = model.UserName
            };
        }

        public static UserViewModel ToViewModel(this UserModel model)
        {
            if (model is null) return new();

            return new UserViewModel
            {
                UserId = model.UserId,

                UserName = model.UserName
            };
        }

        public static DateTimeOffset Get(DateTime dateTime)
        {
            var dOffSet = DateTimeOffset.UtcNow;
            var dOnSet = DateTimeOffset.UtcNow;
  

          return dOnSet;
        }

        static decimal GetFuelCost(SuperheroBase hero) => hero.MaxSpeed switch
        {
            < 1000 => 10.00m,
            <= 10000 => 7.00m,
            _ => 12.00m
        };

        private static bool GreaterThan(DateTimeOffset left, DateTimeOffset right)
        {
            var isBool = left switch
            {
                DateTimeOffset when left < right => true,
                DateTimeOffset when left > right => true,
                DateTimeOffset when left <= right => true,
                DateTimeOffset when left >= right => true,
                _ => false
            };
            
            return isBool;
        }
    }

    public class SuperheroBase
    {
        public int MaxSpeed { get; set; }

        private int _MaxSpeed { get => this.MaxSpeed; set => value = MaxSpeed; }

        public SuperheroBase(int maxSpeed)
        {
            _MaxSpeed = maxSpeed;
        }
         
        public int Get()=> _MaxSpeed;
    }

    public class Superhero : SuperheroBase
    {
        public Superhero(int maxSpeed) : base(maxSpeed)
        {
        }
        public int Id { get; set; }

        public new int Get() => base.Get();
    }


}

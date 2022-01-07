using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Runtime.Serialization.Formatters.Binary;

namespace FrameworkChallenge.Domain
{
    public class CalculatorDividers
    {
        private readonly IDistributedCache _distributedCache;
        private const string CalculatorDividersCacheKey = "CalculatorDividers";

        //public CalculatorDividers(IDistributedCache distributedCache)
        //{
        //    _distributedCache = distributedCache;
        //}

        public DividersDTO Calculate(int Number)
        {
            //var dividersObject = _distributedCache.GetString(CalculatorDividersCacheKey);

            DividersDTO dividers = new DividersDTO();
            dividers.NumberDividers = new List<int>();
            dividers.NumberDividersPrime = new List<int>();

            for (int i = 1; i <= Number; i++)
            {
                if (Number % i == 0)
                {
                    dividers.NumberDividers.Add(i);
                }
            }

            for (int y = 0; y < dividers.NumberDividers.Count; y++)
            {
                int cont = 0;
                for (int i = dividers.NumberDividers[y]; i > 0; i--)
                {
                    if (dividers.NumberDividers[y] % i == 0)
                    {
                        cont++;
                    }
                }
                if (cont == 2)
                {
                    dividers.NumberDividersPrime.Add(dividers.NumberDividers[y]);
                }
            }

            //_distributedCache.SetString(CalculatorDividersCacheKey, "Teste Framework");

            return dividers;
        }
    }
}
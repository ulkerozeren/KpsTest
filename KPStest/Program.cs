using KPStest.Service_Adapters;
using ServiceReference1;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace KPStest
{
    class Program
    {
        
        public Program()
        {
           
        }
        static void Main(string[] args)
        {
            Member member = new Member() { Name = "ÜLKER", Surname = "ÖZEREN", Birtday = 1984, TCKN = 17824667944 };

            BasicHttpsBinding binding = new BasicHttpsBinding();
            EndpointAddress address = new EndpointAddress("https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx?WSDL");

            KPSPublicSoapClient client = new KPSPublicSoapClient(binding, address);
            var result=client.TCKimlikNoDogrulaAsync(member.TCKN, member.Name, member.Surname, member.Birtday);
            var sonuc=result.Result.Body.TCKimlikNoDogrulaResult;

            if (sonuc==false)
            {
                Console.WriteLine("geçersiz kullanıcı");
            }
            else
            {
                Console.WriteLine("geçerli kullanıcı");
            }

            Console.ReadLine();
        }
    }
}

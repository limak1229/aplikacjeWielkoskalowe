using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataBaseContext;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories
{
    public class CalculatedRoutesRepository : ICalculatedRoutesRepository
    {
        public CalculatedRoutes GetCalculatedRoute(Guid token)
        {
            using (var db = new AplikacjeWielkoskaloweContext())
            {
                return db.CalculatedRoutes.LastOrDefault(cr => cr.Token == token);
            }
        }

        public bool AddNewCalculatedRoute(string version, Guid token, string data)
        {
            try
            {
                using (var db = new AplikacjeWielkoskaloweContext())
                {
                    db.CalculatedRoutes.Add(new CalculatedRoutes()
                    {
                        DataVersion = version,
                        Data = data,
                        Token = token
                    });

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
            return true;
        }
    }
}

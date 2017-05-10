using System;
using DataAccessLayer.DataBaseContext;

namespace DataAccessLayer.Interfaces
{
    public interface ICalculatedRoutesRepository
    {
        CalculatedRoutes GetCalculatedRoute(Guid token);
        bool AddNewCalculatedRoute(string version, Guid token, string data);
    }
}
using System.Collections.Generic;
using DAL.Entites;

namespace BAL.Interfaces
{
   public interface IPageService
   {
       bool DeletePage(int id);

       Page GetPage(int id);

       List<Page> GetAccountPageList(int accId);

       List<Page> GetAllPages();

       List<Page> SearchPages(string search);
   }
}

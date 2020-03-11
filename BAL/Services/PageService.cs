using System.Collections.Generic;
using System.Linq;
using BAL.Interfaces;
using DAL.Entites;
using DAL.Repository;
using System;

namespace BAL.Services
{
   public class PageService :IPageService
   {
       private readonly IPageRepository _pageRepository;

       public PageService(IPageRepository pageRepository)
       {
           _pageRepository = pageRepository;
       }
       public bool DeletePage(int id)
       {
           return _pageRepository.Delete(id);
       }

        public Page GetPage(int id)
        {
            return _pageRepository.Get(id);
        }

        public List<Page> GetAccountPageList(int accId)
        {
            return _pageRepository.GetList().Where(x => x.AccountId == accId).ToList();
        }

        public List<Page> GetAllPages()
        {
            return _pageRepository.GetList().ToList();
        }

        public List<Page> SearchPages(string search)
        {
          
            return _pageRepository.GetList().Where(x => x.Description.Contains(search.Trim())|| x.PageAddress.Contains(search)).ToList();
        }

    }
}

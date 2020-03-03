
namespace AddBuzz.Helpers
{
  public interface ICookieHelper
    {
        void SetCookie(string key, object value, int expireDays);
        void DeleteCookie(string key);
        object GetCookie(string key);
    }
}

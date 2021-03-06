using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Cache
{
    public interface ICacheManager
    {
        T Get<T>(string key); //T döndüren (liste) T tipinde verileri çekmek için
        object Get(string key); //üsttekinin alternatifi ama tip dönüşümlü olan daha işlevsel olur
        void Add(string key, object value, int duration); //duration - süre 
        bool IsAdd(string key);// cache de çağırılan metod var mı kontrol et
        void Remove(string key);//süre dolduğunda cachede olan keyi temizle
        void RemoveByPattern(string pattern);//örneğin "get" le başlayanları temizle  
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key);
        void Remove(string key);       
        /// <summary>
        /// Verdiğimiz Regex'e göre silme işlemi yapar.
        /// </summary>
        /// <param name="pattern"></param>
        void RemoveByPattern(string pattern);
    }
}

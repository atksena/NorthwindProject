using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //T hangi tipi döndüreceğini söyler 
    public interface IDataResult<T> : IResult
    {
        //İçinde mesaj ve işlem sonucu haricinde T türünde bir data olmalı
        //T yapmamızın sebebi ürün dödürebilir kategory veya mişteriler tablosu gibi..
        T Data { get; }
    }
}
 
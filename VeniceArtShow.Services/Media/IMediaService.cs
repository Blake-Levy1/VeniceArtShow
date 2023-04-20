using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public interface IMediaService
{
    Task<bool> CreateMediaAsync(MediaCreate model);

    Task<bool> UpdateMediaAsync(MediaUpdate model);

    Task<bool> DeleteMediaAsync(int id);
}

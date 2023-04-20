using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class MediaService : IMediaService
{
    private readonly ApplicationDbContext _context;
    public MediaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateMediaAsync(MediaCreate model)
    {
        var entity = new MediaEntity
        {
            MediaType = model.MediaType
        };

        _context.Medias.Add(entity);
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }

// NOT FINISHED YET
    // public async Task<bool> UpdateMediaAsync(MediaUpdate model)
    // {
    //     var entity = await _context.Medias.FindAsync(model.MediaType);

    //     if(MediaEntity?.Id !=)
    // }


    public async Task<bool> DeleteMediaAsync(int id)
    {
        //Find by MediaId
        var mediaEntity = await _context.Medias.FindAsync(id);

        //Remove MediaType 
        _context.Medias.Remove(mediaEntity);
        return await _context.SaveChangesAsync() == 1;
    }

    public Task<bool> UpdateMediaAsync(MediaUpdate model)
    {
        throw new NotImplementedException();
    }
}

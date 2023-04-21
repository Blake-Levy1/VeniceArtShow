using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class MediaService : IMediaService
{
    private readonly ApplicationDbContext _dbContext;
    public MediaService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateMediaAsync(MediaCreate model)
    {
        var entity = new MediaEntity
        {
            MediaType = model.MediaType
        };

        _dbContext.Medias.Add(entity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        return numberOfChanges == 1;
    }

    public async Task<IEnumerable<MediaList>> GetAllMediaAsync()
    {
        var medias = await _dbContext.Medias
        .Select(medias => new MediaList
        {
            Id = medias.Id,
            MediaType = medias.MediaType
        })
        .ToListAsync();
        return medias;
    }

    public async Task<bool> UpdateMediaAsync(MediaUpdate model)
    {
        var entity = await _dbContext.Medias.FindAsync(model.Id);
        if (entity is null) 
        {
            return false;
        }
        entity.MediaType = model.MediaType;
        
        return (await _dbContext.SaveChangesAsync() == 1);
    }


    public async Task<bool> DeleteMediaAsync(int id)
    {
        //Find by MediaId
        var mediaEntity = await _dbContext.Medias.FindAsync(id);

        //Remove MediaType 
        _dbContext.Medias.Remove(mediaEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }

}
